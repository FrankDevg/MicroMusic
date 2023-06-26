using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using MediatR;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.Domain.Core.Commands;
using MicroBroker.Domain.Core.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace MicroBroker.Infra.Bus
{
    public sealed class AzureServicesBus : IEventBus
    {
        private readonly IMediator _mediator;
        //se implemente la interface IEventBus
        //para implementar el publish y el subscribe necesito registrar dos propiedades adicionales
        //diccionario hacer un handle de todos los eventos que suceden en el bus
        //tambien una lista que almacene rtodos los eventtypes
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly AzureServicesBusSettings _settings;

        public AzureServicesBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory,
                                IOptions<AzureServicesBusSettings> settings)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _serviceScopeFactory = serviceScopeFactory;

            _eventTypes = new List<Type>();
            _settings = settings.Value;
        }

        public async void Publish<T>(T @event) where T : Event
        {
            var connectionString= _settings.ConnectionString;

            var queueName = @event.GetType().Name;
            
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            ServiceBusMessage messageSend = new ServiceBusMessage(body);
            var clientAdmind = new ServiceBusAdministrationClient(connectionString);
            ServiceBusClient clientSender = new ServiceBusClient(connectionString);
            //await clientAdmind.CreateQueueAsync(queueName);

            await clientSender.CreateSender(queueName).SendMessageAsync(messageSend);
            //primera parte del await es mi channel.
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            //Comunicar dos componentes dentro de mi bus.
            return _mediator.Send(command);

        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            //es invocado por un programa para poder leer los mensajes que contienen uun queue
            //tambien necesito saber los manejadores de ese evento.
            //t representa el mensaje
            //TH manejadores 
            var queueName = typeof(T).Name;
            var handlerType = typeof(TH);
            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }
            if(!_handlers.ContainsKey(queueName)){
                _handlers.Add(queueName,new List<Type>());
            }

            if (_handlers[queueName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException($"El handler exception {handlerType.Name} ya fue registrado anteriormente por '{queueName}'", nameof(handlerType));
            }
            _handlers[queueName].Add(handlerType);
            StartBasicConsumeAsync<T>();

        }
        private async Task StartBasicConsumeAsync<T>() where T : Event
        {
            var connectionString = _settings.ConnectionString;
            var queueName = typeof(T).Name;
            //var clientAdmind = new ServiceBusAdministrationClient(connectionString);
           var clientReceiver = new ServiceBusClient(connectionString);
            //quizas no sea necesario el admind
            //   await clientAdmind.CreateQueueAsync(queueName);
            // create a processor that we can use to process the messages
            //Create processor instance from client object, pass queue name and ServiceBisProcessorOptions instance
            var processor = clientReceiver.CreateProcessor(queueName, new ServiceBusProcessorOptions());
            // Register ProcessMessageAsync event method
            //Procedimiento  para que consuma todos los eventos azure service bus es Create Processor...
            processor.ProcessMessageAsync += async(messageArgs) =>
            {
                string body = messageArgs.Message.Body.ToString();
                Console.WriteLine(body);
                try
                {
                    await ProcessEvent(queueName, body).ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                }
                await messageArgs.CompleteMessageAsync(messageArgs.Message);
                };
                //Register ErrorAsync event method
                processor.ProcessErrorAsync += async(messageArgs) =>
            {
                Console.WriteLine(messageArgs.Exception.Message);
            };
            //Start the processor
            await processor.StartProcessingAsync();

            // ServiceBusReceiver receiver = clientReceiver.CreateReceiver(queueName);

            //ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            //string body = receivedMessage.Body.ToString();
            //if(body!=null){

            //    await receiver.CompleteMessageAsync(receivedMessage);
            //    Console.WriteLine(body);
            //    try
            //    {
            //        await ProcessEvent(queueName, body).ConfigureAwait(false);
            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Didnt receive a message");
            //}





        }

        private async Task ProcessEvent(string queueName, string body)
        {
            //consumir los mensajes que se encuentran dentro del queue
            if (_handlers.ContainsKey(queueName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _handlers[queueName];

                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);  //Activator.CreateInstance(subscription);
                        if (handler == null) continue;
                        var eventType = _eventTypes.SingleOrDefault(t => t.Name == queueName);
                        var @event = JsonConvert.DeserializeObject(body, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });

                    }

                }
            }
        }
    }
    
}

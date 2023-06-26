
using MicroBroker.Domain.Core.Commands;
using MicroBroker.Domain.Core.Events;

namespace MicroBroker.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        //publicar el mensaje dentro del broker
        void Publish<T>(T @event) where T : Event;
        //susbscribir el mensaje dentro del broker
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}

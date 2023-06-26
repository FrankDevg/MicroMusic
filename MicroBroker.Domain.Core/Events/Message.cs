using MediatR;


namespace MicroBroker.Domain.Core.Events
{
    public abstract class Message:IRequest<bool>
    { 
        public string MessageType { get; protected set; }  

        protected Message()
        {
            //obtiene el nombre de la clase que en tiempo de ejecucion esta instanciando en base a una clase abstracta message
            MessageType=GetType().Name;

        }
    }
}

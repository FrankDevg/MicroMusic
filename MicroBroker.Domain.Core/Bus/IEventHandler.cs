

using MicroBroker.Domain.Core.Events;

namespace MicroBroker.Domain.Core.Bus
{
    //recibe un TEvent
    public interface IEventHandler<in TEvent>:IEventHandler 
        where TEvent : Event
    {
        //mensajes que van hacia el broker.
        Task Handle(TEvent @event);
    }
    public interface IEventHandler { }

}

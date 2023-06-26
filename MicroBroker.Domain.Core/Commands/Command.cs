

using MicroBroker.Domain.Core.Events;

namespace MicroBroker.Domain.Core.Commands
{
    //es la instancia la referencia que va a llevar de un componente a otro
    public abstract class  Command:Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}

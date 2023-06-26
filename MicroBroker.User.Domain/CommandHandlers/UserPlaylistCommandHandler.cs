using MediatR;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.User.Domain.Commands;
using MicroBroker.User.Domain.Events;

namespace MicroBroker.User.Domain.CommandHandlers
{
    public class UserPlaylistCommandHandler : IRequestHandler<CreateUserPlaylistCommand, bool>
    {
        private readonly IEventBus _bus;

        public UserPlaylistCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateUserPlaylistCommand request, CancellationToken cancellationToken)
        {
            //logica para publicar el mensaje dentro del eventbus azure services bus.
            _bus.Publish(new UserPlaylistCreatedEvent(request.Id_User, request.Title, request.Creation_Date, request.User_Type, request.User_Photo));
            return Task.FromResult(true);
        }
    }
}

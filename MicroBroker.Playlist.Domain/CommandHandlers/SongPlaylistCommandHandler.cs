using MediatR;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.Playlist.Domain.Commands;
using MicroBroker.Playlist.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.CommandHandlers
{
    public class SongPlaylistCommandHandler:IRequestHandler<GetSongPlaylistCommand,bool>
    {
        private readonly IEventBus _bus;

        public SongPlaylistCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(GetSongPlaylistCommand request, CancellationToken cancellationToken)
        {
            //logica para publicar el mensaje dentro del eventbus azure services bus.
            _bus.Publish(new SongPlaylistGetEvent(request.idSongsList));
            return Task.FromResult(true);
        }
    }
}

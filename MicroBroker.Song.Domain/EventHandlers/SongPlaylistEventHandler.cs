using MicroBroker.Domain.Core.Bus;
using MicroBroker.Song.Domain.Events;
using MicroBroker.Song.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Song.Domain.EventHandlers
{
    public class SongPlaylistEventHandler: IEventHandler<SongPlaylistGetEvent>
    {
        private readonly ISongRepository _songRepository;

        public SongPlaylistEventHandler(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }
        //se ejecuta cuando llega un mensaje al bus
        public Task Handle(SongPlaylistGetEvent @event)
        {
            var idSongsList = @event.IdSongsList;


            _songRepository.ReadSongs(idSongsList);// .AddPlaylist(playlist);


            return Task.CompletedTask;
        }
    }
}

using MicroBroker.Domain.Core.Bus;
using MicroBroker.Song.Application.Interfaces;
using MicroBroker.Song.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Song.Application.Services
{
    public class SongService:ISongService
    {
        private readonly ISongRepository _songRepository;

        //comunicacion microservicios

        private readonly IEventBus _bus;
        public SongService(ISongRepository songRepository, IEventBus bus)
        {
            this._songRepository = songRepository;
            _bus = bus;
        }
        public IEnumerable<Domain.Models.Song> ReadSong()
        {
            return _songRepository.ReadSong();

        }
        public int CheckExistSong(string songName)
        {
            return _songRepository.CheckExistSong(songName);

        }

        public int DeleteSong(int id)
        {
            return _songRepository.DeleteSong(id);

        }

     

        public int SaveSong(Domain.Models.Song song)
        {
            return _songRepository.SaveSong(song);

        }

        public int UpdateSong(Domain.Models.Song song)
        {
            return _songRepository.UpdateSong(song);

        }

        public IEnumerable<Domain.Models.Song> ReadSongs(List<int> idSongs)
        {
            return _songRepository.ReadSongs(idSongs);

        }
    }
}

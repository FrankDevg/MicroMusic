using MicroBroker.Album.Application.Interfaces;
using MicroBroker.Album.Domain.Interfaces;
using MicroBroker.Album.Domain.Models;
using MicroBroker.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Application.Services
{
    public class TracklistService:ITracklistService
    {
        private readonly ITracklistRepository _tracklistRepository;
        private readonly IEventBus _bus;
        private readonly ISongServiceRemote _songServiceRemote;


        public TracklistService(ITracklistRepository tracklistRepository, IEventBus bus, ISongServiceRemote songServiceRemote)
        {
            _tracklistRepository = tracklistRepository;
            _bus = bus;
            _songServiceRemote = songServiceRemote;
        }

        public int CheckExistTracklist(int idAlbum, int idSong)
        {
            return _tracklistRepository.CheckExistTracklist(idAlbum, idSong);

        }

        public int DeleteSongOnTracklist(int idAlbum, int idSong)
        {
            return _tracklistRepository.DeleteSongOnTracklist(idAlbum, idSong);

        }

        public int DeleteTracklist(int idAlbum)
        {
            return _tracklistRepository.DeleteTracklist(idAlbum);

        }

        public IEnumerable<SongRemote> ReadTracklist(int idAlbum)
        {
            var player = _tracklistRepository.ReadTracklist(idAlbum);
            List<int> idSongsList = new List<int>();
            foreach (var song in player)
                idSongsList.Add(song.Id_Song);

            //LLAMAR MICROSERVICIO COMUNICACION ASINCRONA

            //var getSongPlaylistCommand = new GetSongPlaylistCommand(idSongsList);
            //_bus.SendCommand(getSongPlaylistCommand);

            var response = _songServiceRemote.GetSongs(idSongsList);

            return response.Result.songs;
        }

        public int SaveTracklist(int idAlbum, List<int> idSongs)
        {
            return _tracklistRepository.SaveTracklist(idAlbum, idSongs);
        }

        public int SaveTracklist(int idAlbum, int idSong)
        {
            return _tracklistRepository.SaveTracklist(idAlbum, idSong);

        }


        //  private readonly ISongServiceRemote _songServiceRemote;
    }
}

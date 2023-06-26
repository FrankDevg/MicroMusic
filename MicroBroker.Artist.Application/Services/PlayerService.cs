using MicroBroker.Artist.Application.Interfaces;
using MicroBroker.Artist.Domain.Interfaces;
using MicroBroker.Artist.Domain.Models;
using MicroBroker.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IEventBus _bus;
        private readonly ISongServiceRemote _songServiceRemote;

        public PlayerService(IPlayerRepository playerRepository, IEventBus bus, ISongServiceRemote songServiceRemote)
        {
            _playerRepository = playerRepository;
            _bus = bus;
            _songServiceRemote = songServiceRemote;
        }

        public int CheckExistPlayer(int idArtist, int idSong)
        {
            return _playerRepository.CheckExistPlayer(idArtist, idSong);
        }

        public int DeletePlayer(int idArtist)
        {
            return _playerRepository.DeletePlayer(idArtist);

        }

        public int DeletePlayer(int idArtist, int idSong)
        {
            return _playerRepository.DeletePlayer(idArtist, idSong);

        }

        public IEnumerable<SongRemote> ReadPlayer(int idArtist)
        {
            var player = _playerRepository.ReadPlayer(idArtist);
            List<int> idSongsList = new List<int>();
            foreach (var song in player)
                idSongsList.Add(song.Id_Song);

            //LLAMAR MICROSERVICIO COMUNICACION ASINCRONA

            //var getSongPlaylistCommand = new GetSongPlaylistCommand(idSongsList);
            //_bus.SendCommand(getSongPlaylistCommand);

            var response = _songServiceRemote.GetSongs(idSongsList);

            return response.Result.songs;
        }

        public int SavePlayer(int idArtist, List<int> idSongs)
        {
            return _playerRepository.SavePlayer(idArtist, idSongs);

        }

        public int SavePlayer(int idArtist, int idSong)
        {
            return _playerRepository.SavePlayer(idArtist, idSong);
        }
    }
}

using MicroBroker.Domain.Core.Bus;
using MicroBroker.Playlist.Application.Interfaces;
using MicroBroker.Playlist.Domain.Commands;
using MicroBroker.Playlist.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Application.Services
{
    public class PlaylistSongService : IPlaylistSongService


    {
        private readonly IPlaylistSongRepository _playlistSongRepository;
        private readonly IEventBus _bus;
        private readonly ISongServiceRemote _songServiceRemote;

        public PlaylistSongService(IPlaylistSongRepository playlistSongRepository, IEventBus bus, ISongServiceRemote songServiceRemote)
        {
            _playlistSongRepository = playlistSongRepository;
            _bus = bus;
            _songServiceRemote = songServiceRemote;
        }

        public int CheckExistPlaylistSong(int playlistId, int songId)
        {
          return _playlistSongRepository.CheckExistPlaylistSong(playlistId, songId);
        }

        public int DeletePlaylistSong(int playlistId)
        {
            return _playlistSongRepository.DeletePlaylistSong(playlistId);
        }

        public int DeletePlaylistSong(int playlistId, int songId)
        {
            return _playlistSongRepository.DeletePlaylistSong(playlistId,songId);
        }


        public IEnumerable<Domain.Models.SongRemote> ReadPlaylistSong(int playlistId)
        {
            var playlistSongs = _playlistSongRepository.ReadPlaylistSong(playlistId);
            List<int> idSongsList = new List<int>();
            foreach (var song in playlistSongs)
                idSongsList.Add(song.Id_Song);

            //LLAMAR MICROSERVICIO COMUNICACION ASINCRONA

            //var getSongPlaylistCommand = new GetSongPlaylistCommand(idSongsList);
            //_bus.SendCommand(getSongPlaylistCommand);

            var response = _songServiceRemote.GetSongs(idSongsList);

            return response.Result.songs;
        }

        public int SavePlaylistSong(int playlistId, int songId)
        {
             return _playlistSongRepository.SavePlaylistSong(playlistId, songId);
        }
    }
}

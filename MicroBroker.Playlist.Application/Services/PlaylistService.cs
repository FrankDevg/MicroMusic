using MicroBroker.Domain.Core.Bus;
using MicroBroker.Playlist.Application.Interfaces;
using MicroBroker.Playlist.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Application.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IEventBus _bus;

        public PlaylistService(IPlaylistRepository playlistRepository, IEventBus bus)
        {
            _playlistRepository = playlistRepository;
            _bus = bus;
        }

        public IEnumerable<Domain.Models.Playlist> ReadPlaylist()
        {
            return _playlistRepository.ReadPlaylist();
         }

        public IEnumerable<Domain.Models.Playlist> ReadPlaylistsByIdUser(int idUser)
        {
            return _playlistRepository.ReadPlaylistsByIdUser(idUser);
        }
        public Domain.Models.Playlist ReadPlaylistByIdUserAndIdPlaylist(int idUser,int idPlaylist)
        {
            return _playlistRepository.ReadPlaylistByIdUserAndIdPlaylist(idUser,idPlaylist);
        }

        public int SavePlaylist(Domain.Models.Playlist playlist)
        {
            return _playlistRepository.SavePlaylist(playlist);
        }
        public int UpdatePlaylist(Domain.Models.Playlist playlist)
        {
            return _playlistRepository.UpdatePlaylist(playlist);
        }
        public int DeletePlaylist(int id)
        {
            return _playlistRepository.DeletePlaylist(id);
        }
        public int CheckExistPlaylist(Domain.Models.Playlist playlist)
        {
            return _playlistRepository.CheckExistPlaylist(playlist);
        }
    }
}

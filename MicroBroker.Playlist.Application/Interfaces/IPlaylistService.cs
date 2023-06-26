using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Application.Interfaces
{
    public interface IPlaylistService
    {
        IEnumerable<Domain.Models.Playlist> ReadPlaylist();
        int SavePlaylist(Domain.Models.Playlist playlist);
        int UpdatePlaylist(Domain.Models.Playlist playlist);
        int DeletePlaylist(int id);
        int CheckExistPlaylist(Domain.Models.Playlist playlist);
        IEnumerable<Domain.Models.Playlist> ReadPlaylistsByIdUser(int idUser);
        Domain.Models.Playlist ReadPlaylistByIdUserAndIdPlaylist(int idUser,int idPlaylist);






    }
}

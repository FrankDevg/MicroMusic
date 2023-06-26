using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.Interfaces
{
    public interface IPlaylistSongRepository
    {
        IEnumerable<Domain.Models.PlaylistSong> ReadPlaylistSong(int playlistId);
  
        int SavePlaylistSong(int playlistId, int songId);
        int DeletePlaylistSong(int playlistId);
        int DeletePlaylistSong(int playlistId,int songId);

        int CheckExistPlaylistSong(int playlistId, int songId);
      
}
}

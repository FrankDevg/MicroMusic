using MicroBroker.Playlist.Application.Models;
using MicroBroker.Playlist.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Application.Interfaces
{
    public  interface ISongServiceRemote
    {

         Task<(bool resultado, List<SongRemote> songs, string ErrorMessage)> GetSongs(List<int> SongId);
       // IAsyncEnumerable<SongRemote> GetSong(List<int> SongId);



    }
}

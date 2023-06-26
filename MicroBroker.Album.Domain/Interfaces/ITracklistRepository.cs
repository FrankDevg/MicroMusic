using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Domain.Interfaces
{
    public interface  ITracklistRepository

    {
        IEnumerable<Domain.Models.Tracklist> ReadTracklist(int idAlbum);

        int SaveTracklist(int idAlbum, List<int> idSongs);
        int SaveTracklist(int idAlbum, int idSong);
        int CheckExistTracklist(int idAlbum, int idSong);
        int DeleteTracklist(int idSong);
        int DeleteSongOnTracklist(int idAlbum, int idSong);


    }
}

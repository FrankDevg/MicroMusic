using MicroBroker.Album.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Application.Interfaces
{
    public interface ITracklistService
    {
        IEnumerable<SongRemote> ReadTracklist(int idAlbum);

        int SaveTracklist(int idAlbum, List<int> idSongs);
        int SaveTracklist(int idAlbum, int idSong);
        int CheckExistTracklist(int idAlbum, int idSong);
        int DeleteTracklist(int idAlbum);
        int DeleteSongOnTracklist(int idAlbum, int idSong);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Song.Application.Interfaces
{
    public interface ISongService
    {
        IEnumerable<Domain.Models.Song> ReadSong();
        int SaveSong(Domain.Models.Song song);
        int UpdateSong(Domain.Models.Song song);
        int DeleteSong(int id);
        int CheckExistSong(string songName);
        IEnumerable<Domain.Models.Song> ReadSongs(List<int> idSongs);

    }
}

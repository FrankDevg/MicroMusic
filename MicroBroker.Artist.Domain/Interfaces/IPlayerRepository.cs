using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Domain.Models.Player> ReadPlayer(int idArtist);
        int SavePlayer(int idArtist, List<int> idSongs);
        int SavePlayer(int idArtist, int idSong);
        int CheckExistPlayer(int idArtist, int idSong);

        int DeletePlayer(int idArtist);
        int DeletePlayer(int idArtist, int idSong);




    }
}

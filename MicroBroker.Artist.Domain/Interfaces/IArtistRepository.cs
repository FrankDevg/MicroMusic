using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Domain.Interfaces
{
    public interface IArtistRepository
    {
        IEnumerable<Domain.Models.Artist> ReadArtist();
        int SaveArtist(Domain.Models.Artist artist);
        int UpdateArtist(Domain.Models.Artist artist);
        int DeleteArtist(int id);
        int CheckExistArtist(Domain.Models.Artist artist);
    }
}

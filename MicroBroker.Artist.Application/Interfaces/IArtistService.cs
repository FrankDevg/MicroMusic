

namespace MicroBroker.Artist.Application.Interfaces
{
    public interface IArtistService
    {
        IEnumerable<Domain.Models.Artist> ReadArtist();
        int SaveArtist(Domain.Models.Artist artist);
        int UpdateArtist(Domain.Models.Artist artist);
        int DeleteArtist(int id);
        int CheckExistArtist(Domain.Models.Artist artist);
    }
}

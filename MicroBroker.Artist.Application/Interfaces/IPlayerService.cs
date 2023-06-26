

namespace MicroBroker.Artist.Application.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<Domain.Models.SongRemote> ReadPlayer(int idArtist);
        int SavePlayer(int idArtist, List<int> idSongs);
        int SavePlayer(int idArtist, int idSong);
        int CheckExistPlayer(int idArtist, int idSong);

        int DeletePlayer(int idArtist);
        int DeletePlayer(int idArtist, int idSong);

    }
}

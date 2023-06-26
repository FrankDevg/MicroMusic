using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Domain.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Domain.Models.Album> ReadAlbum();
        int SaveAlbum(Domain.Models.Album album);
        int UpdateAlbum(Domain.Models.Album album);
        int DeleteAlbum(int id);
        int CheckExistAlbum(string albumTitle);

    }
}

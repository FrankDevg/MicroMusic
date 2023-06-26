using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Catalog.Domain.Interfaces
{
    public interface ICatalogRepository
    {
        int SaveCatalog(Domain.Models.Catalog catalog);
        int CheckExistCatalog(Domain.Models.Catalog catalog);

        IEnumerable<Domain.Models.Catalog> ReadCatalog();
        int UpdateCatalog(Domain.Models.Catalog catalog);
        int DeleteCatalog(int id);
        IEnumerable<Domain.Models.Catalog> GetUserType();
        IEnumerable<Domain.Models.Catalog> GetPlaylistType();
    }
}

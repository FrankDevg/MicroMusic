using MicroBroker.Catalog.Application.Interfaces;
using MicroBroker.Catalog.Domain.Interfaces;
using MicroBroker.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Catalog.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IEventBus _bus;

        public CatalogService(ICatalogRepository catalogRepository, IEventBus bus)
        {
            _catalogRepository = catalogRepository;
            _bus = bus;
        }

        public int CheckExistCatalog(Domain.Models.Catalog catalog)
        {
            return _catalogRepository.CheckExistCatalog(catalog);

        }

        public int DeleteCatalog(int id)
        {
            return _catalogRepository.DeleteCatalog(id);

        }

        public IEnumerable<Domain.Models.Catalog> GetPlaylistType()
        {
            return _catalogRepository.GetPlaylistType();

        }

        public IEnumerable<Domain.Models.Catalog> GetUserType()
        {
            return _catalogRepository.GetUserType();

        }

        public IEnumerable<Domain.Models.Catalog> ReadCatalog()
        {
            return _catalogRepository.ReadCatalog();

        }

        public int SaveCatalog(Domain.Models.Catalog catalog)
        {
            return _catalogRepository.SaveCatalog(catalog);

        }

        public int UpdateCatalog(Domain.Models.Catalog catalog)
        {
            return _catalogRepository.UpdateCatalog(catalog);

        }
    }
}

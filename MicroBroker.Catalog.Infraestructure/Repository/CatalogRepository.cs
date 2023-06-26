using MicroBroker.Catalog.Infraestructure.Context;
using MicroBroker.Catalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Catalog.Infraestructure.Repository
{
    public class CatalogRepository:Domain.Interfaces.ICatalogRepository
    {
        private CatalogDbContext _context;

        public CatalogRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public int CheckExistCatalog(Domain.Models.Catalog request)
        {
            var catalog = _context.Tbl_Catalog.Where(x => x.Cod_Catalog_Parent == request.Cod_Catalog_Parent)
                    .Where(x => x.Cod_Catalog == request.Cod_Catalog)
                    .Where(x => x.Value == request.Value)
                    .FirstOrDefault();
         
            return catalog == null?0:catalog.Id_Catalog;
        }

        public int DeleteCatalog(int id)    
        {
            var playlist = _context.Tbl_Catalog.Where(x => x.Id_Catalog == id)
                           .FirstOrDefault();
            if (playlist == null) return 0;//throw new Exception("No se pudo encontrar el catalogo.");
            _context.Tbl_Catalog.Remove(playlist);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar el catalogo.");
        }

        public IEnumerable<Domain.Models.Catalog> GetPlaylistType()
        {
            var catalogs = _context.Tbl_Catalog.Where(x => x.Cod_Catalog_Parent == Constants.ID_PLAYLIST_TYPE_CATALOG.ToString())
                .ToList();
            if (catalogs == null)
            {
                throw new Exception("No se encontro el catalog");
            }
            return  catalogs;
        }

        public IEnumerable<Domain.Models.Catalog> GetUserType()
        {
            var catalogs = _context.Tbl_Catalog.Where(x => x.Cod_Catalog_Parent == Constants.ID_USER_TYPE_CATALOG.ToString())
                 .ToList();
            if (catalogs == null)
            {
                throw new Exception("No se encontro el catalog");
            }
            return catalogs;
        }

        public IEnumerable<Domain.Models.Catalog> ReadCatalog()
        {
            return _context.Tbl_Catalog;

        }

        public int SaveCatalog(Domain.Models.Catalog catalog)
        {
            _context.Add(catalog);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar el catalogo.");
        }

        public int UpdateCatalog(Domain.Models.Catalog request)
        {
            var catalog = _context.Tbl_Catalog.Where(x => x.Id_Catalog == request.Id_Catalog)
                    .FirstOrDefault();
            if (catalog == null) throw new Exception("No se pudo encontrar el catalogo.");


            catalog.Cod_Catalog_Parent = request.Cod_Catalog_Parent != null && request.Cod_Catalog_Parent != string.Empty ? request.Cod_Catalog_Parent : catalog.Cod_Catalog_Parent;
         
            catalog.Cod_Catalog = request.Cod_Catalog != null && request.Cod_Catalog != string.Empty ? request.Cod_Catalog : catalog.Cod_Catalog;
            catalog.Value = request.Value != null && request.Value != string.Empty ? request.Value : catalog.Value;
            _context.Tbl_Catalog.Update(catalog);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo actualizar el catalogo.");
        }
    }
}

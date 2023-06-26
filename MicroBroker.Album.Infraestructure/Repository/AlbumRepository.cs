using MicroBroker.Album.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Infraestructure.Repository
{
    public class AlbumRepository : Domain.Interfaces.IAlbumRepository
    {
        private AlbumDbContext _context;

        public AlbumRepository(AlbumDbContext context)
        {
            _context = context;

        }

        public int CheckExistAlbum(string albumTitle)
        {
            var album = _context.Tbl_Album.Where(x => x.Title_Album == albumTitle)
                       .FirstOrDefault();
            if (album == null)
            {
                return 0;
            }
            return album.Id_Album;
        }

        public int DeleteAlbum(int id)
        {
            var song = _context.Tbl_Album.Where(x => x.Id_Album == id)
                       .FirstOrDefault();
            if (song == null) return 0;//throw new Exception("No se pudo encontro el album.");
            _context.Tbl_Album.Remove(song);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar el album.");
        }

        public IEnumerable<Domain.Models.Album> ReadAlbum()
        {
            return _context.Tbl_Album;
        }

        public int SaveAlbum(Domain.Models.Album album)
        {
            _context.Add(album);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar el album.");
        }

        public int UpdateAlbum(Domain.Models.Album request)
        {
            var album = _context.Tbl_Album.Where(x => x.Id_Album == request.Id_Album)
                          .FirstOrDefault();
            if (album == null) throw new Exception("No se pudo encontrar el album.");
            album.Title_Album = request.Title_Album != null && request.Title_Album != string.Empty ? request.Title_Album : album.Title_Album;
            album.Release_Year = request.Release_Year;
            album.Album_Image_Path = request.Album_Image_Path != null && request.Album_Image_Path != string.Empty ? request.Album_Image_Path : album.Album_Image_Path;
            _context.Tbl_Album.Update(album);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo actualizar el album.");



        }
    }
}

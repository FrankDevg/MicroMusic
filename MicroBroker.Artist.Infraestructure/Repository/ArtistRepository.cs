using MicroBroker.Artist.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Infraestructure.Repository
{
    public class ArtistRepository : Domain.Interfaces.IArtistRepository
    {
        private ArtistDbContext _context;

        public ArtistRepository(ArtistDbContext context)
        {
            _context = context;
        }

        public int CheckExistArtist(Domain.Models.Artist request)
        {
            var artist = _context.Tbl_Artist.Where(x => x.Artist_Name == request.Artist_Name)
                .Where(x => x.Artist_LastName == request.Artist_LastName)
                              .FirstOrDefault();
             return artist == null ? 0 : artist.Id_Artist;
        }

        public int DeleteArtist(int id)
        {
            var artist = _context.Tbl_Artist.Where(x => x.Id_Artist == id)
                    .FirstOrDefault();
            if (artist == null) return 0;// throw new Exception("No se pudo encontrar el artista.");
            _context.Tbl_Artist.Remove(artist);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar el artista.");
        }

        public IEnumerable<Domain.Models.Artist> ReadArtist()
        {
            return _context.Tbl_Artist;

        }

        public int SaveArtist(Domain.Models.Artist artist)
        {
            _context.Add(artist);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar el artista.");
        }

        public int UpdateArtist(Domain.Models.Artist request)
        {
            var artist = _context.Tbl_Artist.Where(x => x.Id_Artist == request.Id_Artist)
                   .FirstOrDefault();
            if (artist == null) throw new Exception("No se pudo encontrar el artista.");


            artist.Artist_Name = request.Artist_Name != null && request.Artist_Name != string.Empty ? request.Artist_Name : artist.Artist_Name;
            artist.Artist_LastName = request.Artist_LastName != null && request.Artist_LastName != string.Empty ? request.Artist_LastName : artist.Artist_LastName;
            artist.Artist_Image = request.Artist_Image != null && request.Artist_Image != string.Empty ? request.Artist_Image : artist.Artist_Image;

            _context.Tbl_Artist.Update(artist);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo actualizar la playlist.");
        }
    }
}

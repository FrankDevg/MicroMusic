using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBroker.Song.Infraestructure.Context;

namespace MicroBroker.Song.Infraestructure.Repository
{
    public class SongRepository : Domain.Interfaces.ISongRepository
    {


        private SongDbContext _context;

        public SongRepository(SongDbContext context)
        {
            _context = context;
        }


        public int CheckExistSong(string songName)
        {
            var song = _context.Tbl_Song.Where(x => x.Song_Name == songName)
                       .FirstOrDefault();
            if (song == null)
            {
                return 0;
            }
            return song.Id_Song;
        }

        public int DeleteSong(int id)
        {
            var song = _context.Tbl_Song.Where(x => x.Id_Song == id)
                          .FirstOrDefault();
            if (song == null) throw new Exception("No se pudo encontro la cancion.");
            _context.Tbl_Song.Remove(song);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar la cancion.");
        }

        public IEnumerable<Domain.Models.Song> ReadSong()
        {
            return _context.Tbl_Song;
        }

        public IEnumerable<Domain.Models.Song> ReadSongs(List<int> idSongListEnumerator)
        {
           
            List <Domain.Models.Song> listToReturn = new List<Domain.Models.Song>();
            foreach (var idSong in idSongListEnumerator)
            {

                var song = _context.Tbl_Song.Where(song => song.Id_Song == idSong )
                       .Select( song=> new Domain.Models.Song
                       {
                           Id_Song = song.Id_Song,
                           Song_Name = song.Song_Name,
                           Song_Path = song.Song_Path,
                           Plays = song.Plays,
                       }).FirstOrDefault();

                if(song != null) listToReturn.Add(song);
               
            }

            return listToReturn; 

        }

        public int SaveSong(Domain.Models.Song song)
        {
            _context.Add(song);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar la cancion.");
        }

        public int UpdateSong(Domain.Models.Song request)
        {
            var song = _context.Tbl_Song.Where(x => x.Id_Song == request.Id_Song)
                         .FirstOrDefault();
            if (song == null) throw new Exception("No se pudo encontrar la cancion.");
            song.Song_Name = request.Song_Name != null && request.Song_Name != string.Empty ? request.Song_Name : song.Song_Name;
            song.Song_Path = request.Song_Path != null && request.Song_Path != string.Empty ? request.Song_Path : song.Song_Path;
            song.Plays = request.Plays != null ? request.Plays : song.Plays;
           
            _context.Tbl_Song.Update(song);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo actualizar la cancion.");
        }
    }
}

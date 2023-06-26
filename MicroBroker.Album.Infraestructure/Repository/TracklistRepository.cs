 using MicroBroker.Album.Infraestructure.Context;
using MicroBroker.Album.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Infraestructure.Repository
{
    public class TracklistRepository : Domain.Interfaces.ITracklistRepository
    {
        private TracklistDbContext _context;

        public TracklistRepository(TracklistDbContext context)
        {
            _context = context;
        }

        public int CheckExistTracklist(int idAlbum, int idSong)
        {
            //var user = _context.Tbl_User.Where(x => x.Username == userName)
            //               .Where(x => x.Password == password)
            //           .FirstOrDefault();
            ////if (user == null)
            ////{
            ////    throw new Exception("No se encontro el usuario");
            ////}
            //return user;
            var tracklist = _context.Tbl_Tracklist.Where(x => x.Id_Album == idAlbum)
                                        .Where(x => x.Id_Song == idSong)
                              .FirstOrDefault();
            return tracklist == null ? 0 : tracklist.Id_Song;
        }

        public int DeleteSongOnTracklist(int idAlbum, int idSong)
        {
            //var tracklist = _context.Tbl_Tracklist.Where(x => x.Id_Album == idAlbum).Where(x => x.Id_Song == idSong)
            //           .ToList();

            //if (tracklist == null) throw new Exception("No se pudo encontrar el tracklist.");
            //_context.Tbl_Tracklist.RemoveRange(tracklist);

            //var cont = _context.SaveChanges();
            //if (cont > 0) return cont;
            //throw new Exception("No se pudo eliminar el player.");
            
            using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE [TBL_TRACKLIST] where [ID_SONG] = @ID_SONG AND [ID_ALBUM] = @ID_ALBUM";
                    cmd.Parameters.AddWithValue("@ID_ALBUM", idAlbum);
                    cmd.Parameters.AddWithValue("@ID_SONG", idSong);
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }



        }

        public int DeleteTracklist(int idAlbum)
        {
            var tracklist = _context.Tbl_Tracklist.Where(x => x.Id_Album == idAlbum).ToList();
            if (tracklist == null) throw new Exception("No se pudo encontrar el tracklist.");
            _context.Tbl_Tracklist.RemoveRange(tracklist);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            return 0;//throw new Exception("No se pudo eliminar el tracklist.");
        }

        public IEnumerable<Tracklist> ReadTracklist(int idAlbum)
        {
            var player = _context.Tbl_Tracklist.Where(x => x.Id_Album == idAlbum)
                          .ToList();


            return player;
        }

        public int SaveTracklist(int idAlbum, List<int> idSongs)
        {
            try
            {
                List<Tracklist> tracklist = new List<Tracklist>();

                foreach (var id in idSongs)
                {
                    Tracklist currentTracklist = new Tracklist();
                    currentTracklist.Id_Album = idAlbum;
                    currentTracklist.Id_Song = id;
                    tracklist.Add(currentTracklist);
                }

                _context.Tbl_Tracklist.AddRange(tracklist);

                var cont = _context.SaveChanges();

                if (cont > 0)
                    return cont;
                else
                    throw new Exception("No se pudo insertar el tracklist.");
            }
            catch (Exception ex)
            {
            
				return 0;
			}

		}

		public int SaveTracklist(int idAlbum, int idSong)
        {
			try
			{
				Tracklist tracklist = new Tracklist();
				tracklist.Id_Album = idAlbum;
				tracklist.Id_Song = idSong;
				_context.Add(tracklist);
				var cont = _context.SaveChanges();
				if (cont > 0)
					return cont;
				else
					throw new Exception("No se pudo insertar el tracklist.");
			}
			catch (Exception ex)
			{
			
				Console.WriteLine("Error al insertar el tracklist: " + ex.Message);
				return 0; 
			}

		}
	}
}

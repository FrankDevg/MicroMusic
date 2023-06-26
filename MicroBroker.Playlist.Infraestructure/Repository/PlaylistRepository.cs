using MicroBroker.Playlist.Domain.Models;
using MicroBroker.Playlist.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Infraestructure.Repository
{
    public class PlaylistRepository :Domain.Interfaces.IPlaylistRepository
    {
        private PlaylistDbContext _context;

        public PlaylistRepository(PlaylistDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Domain.Models.Playlist> ReadPlaylist()
        {
            return _context.Tbl_Playlist;

        }
        public IEnumerable<Domain.Models.Playlist> ReadPlaylistsByIdUser(int idUser)
        {
            var playlists =  _context.Tbl_Playlist.Where(x => x.Id_User == idUser).ToList();

            if (playlists == null)
            {
                throw new Exception("No se encontro ninguna playlist");
            }
            return playlists;
        }
        public Domain.Models.Playlist ReadPlaylistByIdUserAndIdPlaylist(int idUser,int idPlaylist)
        {
            var playlist =  _context.Tbl_Playlist.Where(x => x.Id_User == idUser)
                   .Where(x => x.Id_Playlist == idPlaylist).FirstOrDefault();

            if (playlist == null)
            {
                throw new Exception("No se encontro la playlist");
            }
            return playlist;
        }

        //I-EJEMPLO DE COMUNICACION ENTRE MICROSERVICIOS.....
        public void AddPlaylist(Domain.Models.Playlist playlist)
        {
            _context.Add(playlist);
            _context.SaveChanges();
        }
        //F-EJEMPLO DE COMUNICACION ENTRE MICROSERVICIOS.....
      

		
		public int UpdatePlaylist(Domain.Models.Playlist request)
        {
            var playlist =  _context.Tbl_Playlist.Where(x => x.Id_User == request.Id_User)
                    .Where(x => x.Id_Playlist == request.Id_Playlist).FirstOrDefault();
            if (playlist == null) throw new Exception("No se pudo encontrar la playlist.");


            playlist.Title = request.Title != null && request.Title != string.Empty ? request.Title : playlist.Title;
            playlist.Type = request.Type;
            playlist.Photo = request.Photo != null && request.Photo != string.Empty ? request.Photo : playlist.Photo;
            _context.Tbl_Playlist.Update(playlist);
            var cont =  _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo actualizar la playlist.");
        }
        public int DeletePlaylist(int id)
        {
            var playlist =  _context.Tbl_Playlist.Where(x => x.Id_Playlist == id)
                           .FirstOrDefault();
            if (playlist == null) throw new Exception("No se pudo encontrar la playlist.");
            _context.Tbl_Playlist.Remove(playlist);
            var cont =  _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar la playlist.");
        }
        public int CheckExistPlaylist(Domain.Models.Playlist request)
        {
            var playList = _context.Tbl_Playlist.Where(x => x.Id_User == request.Id_User)
                     .Where(x => x.Title == request.Title)
                              .FirstOrDefault();
    
    
            return playList==null?0 : playList.Id_Playlist;

        }
		public int SavePlaylist(Domain.Models.Playlist playlist)
		{
            Domain.Models.Playlist newPlaylist = new Domain.Models.Playlist();
            newPlaylist.Id_Playlist = playlist.Id_Playlist;
			newPlaylist.Id_User = playlist.Id_User;
			newPlaylist.Title = playlist.Title;
			newPlaylist.Creation_Date = playlist.Creation_Date;
            newPlaylist.Type = playlist.Type;
			newPlaylist.Photo = playlist.Photo;
			_context.Add(newPlaylist);
			int cont = _context.SaveChanges();
			_context.Dispose();
			if (cont > 0) return cont;
			throw new Exception("No se pudo insertar la playlist.");
		}
	



	}
}

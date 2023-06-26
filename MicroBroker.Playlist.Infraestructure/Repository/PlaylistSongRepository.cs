using MicroBroker.Playlist.Infraestructure.Context;
using MicroBroker.Playlist.Domain.Interfaces;
using MicroBroker.Playlist.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Infraestructure.Repository
{
    public class PlaylistSongRepository:Domain.Interfaces.IPlaylistSongRepository
    {
        private PlaylistSongDbContext _context;

        public PlaylistSongRepository(PlaylistSongDbContext context)
        {
            _context = context;
        }

        public int CheckExistPlaylistSong(int playlistId, int songId)
        {
            var playListSong = _context.Tbl_Playlist_Song.Where(x => x.Id_Playlist == playlistId)
                     .Where(x => x.Id_Song == songId)
                              .FirstOrDefault();
            return playListSong == null ? 0 : playListSong.Id_Playlist;
        }

        public int DeletePlaylistSong(int playlistId)
        {
            var playListSongs = _context.Tbl_Playlist_Song.Where(x => x.Id_Playlist == playlistId).ToList();
            if (playListSongs == null) return 0;
            _context.Tbl_Playlist_Song.RemoveRange(playListSongs);
            var cont = _context.SaveChanges();

           return cont;
            


        }

        public int DeletePlaylistSong(int playlistId, int songId)
        {
            var playlistSong = _context.Tbl_Playlist_Song.Where(x => x.Id_Playlist == playlistId).Where(x =>  x.Id_Song== songId)
                         .FirstOrDefault();
            if (playlistSong == null) return 0;
            _context.Tbl_Playlist_Song.Remove(playlistSong);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No sé pudo eliminar el detalle playlistSong.");
        }

      

        public int SavePlaylistSong(int playlistId, int songId)
        {
            PlaylistSong playlistSong = new PlaylistSong();
            playlistSong.Id_Playlist = playlistId;
            playlistSong.Id_Song= songId;
            _context.Add(playlistSong);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar detalle playlistSong.");

        }

        IEnumerable<Domain.Models.PlaylistSong> IPlaylistSongRepository.ReadPlaylistSong(int playlistId)
        {
            var playlistSong = _context.Tbl_Playlist_Song.Where(x => x.Id_Playlist == playlistId)
                              .ToList();


            return playlistSong;
        }
    }
}

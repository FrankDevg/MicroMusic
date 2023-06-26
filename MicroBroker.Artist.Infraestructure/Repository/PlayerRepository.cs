using MicroBroker.Artist.Infraestructure.Context;
using MicroBroker.Artist.Domain.Interfaces;
using MicroBroker.Artist.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Infraestructure.Repository
{
    public class PlayerRepository:IPlayerRepository
    {
        private  PlayerDbContext _context;

        public PlayerRepository(PlayerDbContext context)
        {
            _context = context;
        }

        public int CheckExistPlayer(int idArtist, int idSong)
        {
            var player = _context.Tbl_Player.Where(x => x.Id_Artist == idArtist)
                                        .Where(x => x.Id_Song == idSong)
                              .FirstOrDefault();
            return player == null ? 0 : player.Id_Song;
        }

        public int DeletePlayer(int idArtist)
        {
            var player = _context.Tbl_Player.Where(x => x.Id_Artist == idArtist).ToList();
            if (player == null) return 0; //throw new Exception("No se pudo encontrar el player.");
            _context.Tbl_Player.RemoveRange(player);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar el player.");
        }

        public int DeletePlayer(int idArtist, int idSong)
        {
            var player = _context.Tbl_Player.Where(x => x.Id_Song == idSong).Where(x => x.Id_Artist == idArtist)
                       .FirstOrDefault();
            if (player == null) return 0;//throw new Exception("No se pudo encontrar el player.");
            _context.Tbl_Player.Remove(player);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo eliminar el player.");
        }

        public IEnumerable<Player> ReadPlayer(int idArtist)
        {
            var player = _context.Tbl_Player.Where(x => x.Id_Artist == idArtist)
                             .ToList();


            return player;
        }

        public int SavePlayer(int idArtist, List<int> idSongs)
        {
           List<Player> player = new List<Player>();
          

            foreach (var id in idSongs)
            {
                Player currentPlayer = new Player();
                currentPlayer.Id_Artist = idArtist;
                currentPlayer.Id_Song = id;
                player.Add(currentPlayer);

            }

            _context.Tbl_Player.AddRange(player);

            var cont =_context.SaveChanges();
            
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar el player.");
        }

        public int SavePlayer(int idArtist, int idSong)
        {
            Player player = new Player();
            player.Id_Artist = idArtist;
            player.Id_Song = idSong;
            _context.Add(player);
            var cont = _context.SaveChanges();
            if (cont > 0) return cont;
            throw new Exception("No se pudo insertar el player.");
        }
    }
}

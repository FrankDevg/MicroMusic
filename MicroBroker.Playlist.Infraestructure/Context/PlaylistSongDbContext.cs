using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Infraestructure.Context
{
    public class PlaylistSongDbContext : DbContext
    {

        public PlaylistSongDbContext(DbContextOptions<PlaylistSongDbContext> options) : base(options) { }
        public DbSet<Domain.Models.PlaylistSong> Tbl_Playlist_Song { get; set; }
    }
}


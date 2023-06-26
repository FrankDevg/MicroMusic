using Microsoft.EntityFrameworkCore;



namespace MicroBroker.Playlist.Infraestructure.Context
{
    public class PlaylistDbContext : DbContext
    {
     
        public PlaylistDbContext(DbContextOptions<PlaylistDbContext> options) : base(options) 
        { 
        }
        public DbSet<MicroBroker.Playlist.Domain.Models.Playlist> Tbl_Playlist { get; set; }
    }
}

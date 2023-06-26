using Microsoft.EntityFrameworkCore;


namespace MicroBroker.Artist.Infraestructure.Context
{
    public class ArtistDbContext:DbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options) { }
        public DbSet<Domain.Models.Artist> Tbl_Artist { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;


namespace MicroBroker.Catalog.Infraestructure.Context
{
    public class CatalogDbContext:DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }
        public DbSet<Domain.Models.Catalog> Tbl_Catalog { get; set; }
    }
}

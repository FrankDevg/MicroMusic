using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MicroBroker.Album.Infraestructure.Context
{
    public class AlbumDbContext : DbContext
    {
        public AlbumDbContext(DbContextOptions<AlbumDbContext> options) : base(options) { }
        public DbSet<Domain.Models.Album> Tbl_Album { get; set; }
    }
}

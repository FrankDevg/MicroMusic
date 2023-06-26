using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MicroBroker.Song.Infraestructure.Context
{
    public class SongDbContext:DbContext
    {
        public SongDbContext(DbContextOptions<SongDbContext> options) : base(options) { }
        public DbSet<Domain.Models.Song> Tbl_Song { get; set; }

    }
}

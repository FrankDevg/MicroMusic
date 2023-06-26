using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Infraestructure.Context
{
    public class TracklistDbContext: DbContext
    {
        public TracklistDbContext(DbContextOptions<TracklistDbContext> options) : base(options) { }
        public DbSet<Domain.Models.Tracklist> Tbl_Tracklist { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Infraestructure.Context
{
    public class UserDbContext:DbContext 
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<MicroBroker.User.Domain.Models.User> Tbl_User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.User.Application.Models
{
    public class UserPlaylist
    {
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public int Type { get; set; }
        public string Photo { get; set; }
    }
}

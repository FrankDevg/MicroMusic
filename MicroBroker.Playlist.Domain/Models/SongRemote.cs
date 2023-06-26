using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.Models
{
    public class SongRemote
    {
        public int Id_Song { get; set; }
        public string Song_Name { get; set; }
        public string Song_Path { get; set; }
        public int Plays { get; set; }
    }
}

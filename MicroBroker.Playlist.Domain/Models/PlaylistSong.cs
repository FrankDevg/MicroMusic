
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.Models
{
    public class PlaylistSong
    {
        public int ID { get; set; }
        public int Id_Playlist { get; set; }
        public int Id_Song { get; set; }
    }
}

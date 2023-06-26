using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Playlist.Domain.Models
{
    public class Playlist
    {
		public Playlist()
		{
		}

        public Playlist(int id_Playlist, int id_User, string title, DateTime? creation_Date, int type, string photo)
        {
            Id_Playlist = id_Playlist;
            Id_User = id_User;
            Title = title;
            Creation_Date = creation_Date;
            Type = type;
            Photo = photo;
        }

        [Key]
        public int Id_Playlist { get; set; }
        public int Id_User { get; set; }
        public string Title { get; set; }
        public DateTime? Creation_Date { get; set; }
        public int Type { get; set; }
        public string Photo { get; set; }
    }
}

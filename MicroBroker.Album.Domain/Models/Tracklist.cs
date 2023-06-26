using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Domain.Models
{
    public class Tracklist//ALBUMSONG
    {
        [Key]
		public int ID { get; set; }

		public int Id_Album { get; set; }
        
        public int Id_Song { get; set; }
       
    }
}

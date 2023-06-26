using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace MicroBroker.Artist.Domain.Models
{
    public class Player//(ArtistSong)
    {
        [Key]
		public int ID { get; set; }

		public int Id_Song { get; set; }
        public int Id_Artist { get; set; }
    }
}

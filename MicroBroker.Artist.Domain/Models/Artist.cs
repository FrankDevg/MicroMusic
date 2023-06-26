using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Artist.Domain.Models
{
    public class Artist
    {
        [Key]
        public int Id_Artist { get; set; }
        public string Artist_Name { get; set; }
        public string Artist_LastName { get; set; }
        public string Artist_Image { get; set ; }
    }
}

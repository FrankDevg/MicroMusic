using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Album.Domain.Models
{
    public class Album
    {
        [Key]
        public int Id_Album { get; set; }
        public string Title_Album { get; set; }
        public int Release_Year { get; set; }
        public string Album_Image_Path { get; set; }
    }
}

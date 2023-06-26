using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBroker.Catalog.Domain.Models
{
    public class Catalog
    {
        [Key]
        public int Id_Catalog { get; set; }
        public string? Cod_Catalog_Parent { get; set; }
        public string Cod_Catalog { get; set; }
        public string Value { get; set; }
    }
}

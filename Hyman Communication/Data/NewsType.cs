using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Data
{
    public class NewsType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("MarketID")]
        public string Market { get; set; }
        public DateTime DateCreated { get; set; }

       public string User { get; set; }
    }
}

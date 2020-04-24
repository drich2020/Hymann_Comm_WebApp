using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
        public int DocumentId { get; set; }
       
        [ForeignKey("MarketId")]
        public Market Market { get; set; }
        public int MarketId { get; set; }
    }
}

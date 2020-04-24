using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Data
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MarketName { get; set; }
        
        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
        public int DocumentId { get; set; }
        
    }
}

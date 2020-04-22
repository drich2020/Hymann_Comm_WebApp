using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Data
{
    public class NewsHistory
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("RequestingEmployeeID")]
        public Employee PostedByEmployee { get; set; }
        public string PostedByEmployeeID { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("NewsTypeId")]
        public NewsType NewsType { get; set; }
        public int NewsTypeId { get; set; }
        [ForeignKey("MarketID")]
        public string Market { get; set; }
    }
}

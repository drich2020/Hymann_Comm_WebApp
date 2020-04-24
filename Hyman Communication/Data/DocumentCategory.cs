using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Data
{
    public class DocumentCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeOfDocument { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Data
{
    public class Document
    {
        [Key]
        public int Id  { get; set; }
        [Required]
        public string DocumentName  { get; set; }
        public DateTime DateCreated  { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("DocumentCategoryId")]
        public DocumentCategory DocumentCategory { get; set; }
        public int DocumentCategoryId { get; set; }
    }
}

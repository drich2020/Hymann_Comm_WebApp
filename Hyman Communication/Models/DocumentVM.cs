using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Models
{
    public class DocumentVM
    {
        public int Id { get; set; }
        [Required]
        public string DocumentName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public DocumentCategoryVM DocumentCategory { get; set; }
        public int DocumentCategoryId { get; set; }
        public IEnumerable<SelectListItem> DocumentCategories { get; set; }
    }
}

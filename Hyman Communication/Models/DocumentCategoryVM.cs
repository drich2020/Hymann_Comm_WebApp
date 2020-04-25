using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Models
{
    public class DocumentCategoryVM
    {
        public int Id { get; set; }
        [Required]
        public string TypeOfDocument { get; set; }
        public IEnumerable<SelectListItem> TypesOfDocument { get; set; }
    }
}

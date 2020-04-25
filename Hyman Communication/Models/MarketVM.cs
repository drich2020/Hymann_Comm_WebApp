using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Models
{
    public class MarketVM
    {
        public int Id { get; set; }
        [Required]
        public string MarketName { get; set; }

        public DocumentVM Document { get; set; }
        public int DocumentId { get; set; }
        public IEnumerable<SelectListItem> Documents { get; set; }
    }
}

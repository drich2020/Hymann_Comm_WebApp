using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hyman_Communication.Models
{
    public class PromotionVM
    {
        public int Id { get; set; }
        [Required]
        public string OfferedPromotion { get; set; }

        public ProductVM Product { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }

        public MarketVM Market { get; set; }
        public int MarketId { get; set; }
        public IEnumerable<SelectListItem> Markets { get; set; }

        public DocumentVM Document { get; set; }
        public int DocumentId { get; set; }
        public IEnumerable<SelectListItem> Documents { get; set; }
    }
}

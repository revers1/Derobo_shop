using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoroboShop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public float? Price { get; set; }

        [Required]
        public float? Size { get; set; }

        public int Sale { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public string Color { get; set; }

        public string Brand { get; set; }

        public string Country { get; set; }
        [Required]
        public string Season { get; set; }


        [Required]
        public string Description { get; set; }


        [Required]
        public DateTime DataCreate { get; set; }

        public string FilePath { get; set; }

        public HttpPostedFileBase SomeFile { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
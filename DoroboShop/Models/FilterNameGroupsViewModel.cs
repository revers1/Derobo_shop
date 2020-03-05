using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoroboShop.Models
{
    public class FilterNameGroupsViewModel
    {
        public int Id { get; set; }
        [Required]
        public int FilterNameId { get; set; }

        [Required]
        public int FilterValueId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
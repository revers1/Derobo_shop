using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoroboShop.ModelsCreate
{
    public class CreateFilterGroupsViewModel
    {
        [Required]
        public int FilterNameId { get; set; }

        [Required]
        public int FilterValueId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoroboShop.ModelsCreate
{
    public class CreateFilterValueViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
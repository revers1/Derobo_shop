using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.ModelsCreate
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public List<SelectListItem> Categories { get; set; }

    }
}
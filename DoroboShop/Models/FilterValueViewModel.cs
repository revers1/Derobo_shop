using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Models
{
    public class FilterValueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int NameFilterId { get; set; }

        public List<SelectListItem> FiltersNames { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoroboShop.Models
{
    public class GroupViewModel
    {
        public List<CategoryViewModelcs> Categories { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
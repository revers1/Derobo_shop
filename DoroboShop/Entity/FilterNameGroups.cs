using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTEstFilters.Entity
{
    [Table("tblFilterNameGroups")]
    public class FilterNameGroups
    {
        [ForeignKey("FilterNameOf"), Key, Column(Order = 0)]
        public int FilterNameId { get; set; }

        [ForeignKey("FilterValueOf"), Key, Column(Order = 1)]
        public int FilterValueId { get; set; }

        [ForeignKey("CategoryOf"), Key, Column(Order = 2)]
        public int CategoryId { get; set; }

        public virtual FilterValue FilterValueOf { get; set; }
        public virtual FilterName FilterNameOf { get; set; }
        public virtual Category CategoryOf { get; set; }

    }
}

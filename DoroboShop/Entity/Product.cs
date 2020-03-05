using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleTEstFilters.Entity
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
       
        [Required,StringLength(maximumLength:50)]
        public string Name { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public float ? Price { get; set; }

        [Required]
        public float ? Size { get; set; }

        public int Sale { get; set; }

        [Required]
        public int ? Quantity { get; set; }

     
        [Required]
        public string Color { get; set; }
       
        public string Brand { get; set; }
     
        public string Country{ get; set; }
        [Required]
        public string Season { get; set; }


        [Required, StringLength(maximumLength: 150)]
        public string Description { get; set; }


        [Required]
        public DateTime DataCreate { get; set; }

        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }

      

        public virtual Category Category { get; set; }
    }
}

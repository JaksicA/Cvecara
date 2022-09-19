using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Entities
{
    public class Inventory : IEntity
    {
        [Key]
        [ForeignKey(nameof(Entities.Item))]
        [Display(Name = "Ime")]
        public int Id { get; set; }
        [Display(Name = "Ime")]
        public Item Item { get; set; }
       
        [Display(Name = "Kolicina")]
        public int Quantity { get; set; }
    }
}

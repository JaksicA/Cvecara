using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data.Entities
{
    public class Item : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Cena")]
        public int Price { get; set; }
    }
}

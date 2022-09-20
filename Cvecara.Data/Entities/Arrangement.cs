using System.ComponentModel.DataAnnotations;

namespace Cvecara.Data.Entities
{
    public class Arrangement : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ime")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Putanja do slike")]
        public string ImagePath { get; set; }
        [Display(Name = "Cena")]
        public int Price { get; set; }
    }
}

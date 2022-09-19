namespace Cvecara.Data.Entities
{
    public class Arrangement : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
    }
}

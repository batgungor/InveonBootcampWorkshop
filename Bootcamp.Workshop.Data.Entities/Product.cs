using System;

namespace Bootcamp.Workshop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

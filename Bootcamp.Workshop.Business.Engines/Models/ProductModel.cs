using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Workshop.Business.Engines.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public CategoryModel Category { get; set; }
    }
}

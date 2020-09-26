using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerWebApi.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public ProductDto() { }
    }
}

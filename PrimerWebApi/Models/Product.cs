using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerWebApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, string color, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
            this.Price = price;
        }

        public Product() { }
    }
}

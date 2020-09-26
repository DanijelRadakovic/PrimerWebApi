using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimerWebApi.Models;
using PrimerWebApi.Dtos;

namespace PrimerWebApi.Adapters
{
    public class ProductAdapter
    {
        public static Product ProductDtoToProduct(ProductDto dto) 
        {
            Product product = new Product();
            product.Name = dto.Name;
            product.Color = dto.Color;
            product.Price = dto.Price;
            return product;
        }

        public static ProductDto ProductToProductDto(Product product)
        {
            ProductDto dto = new ProductDto();
            dto.Name = product.Name;
            dto.Color = product.Color;
            dto.Price = product.Price;
            return dto;
        }
    }
}

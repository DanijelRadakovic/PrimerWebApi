using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrimerWebApi.Models;
using PrimerWebApi.Dtos;
using PrimerWebApi.Adapters;

namespace PrimerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]       // GET /api/product
        public IActionResult Get()
        {
            List<ProductDto> result = new List<ProductDto>();
            Program.Products.ForEach(product => result.Add(ProductAdapter.ProductToProductDto(product)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/product/1
        public IActionResult Get(long id)
        {
            Product product = Program.Products.Find(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProductAdapter.ProductToProductDto(product));
            }
        }

        [HttpPost]      // POST /api/product Request body: {"name": "jeans", "color": "blue", "price": 55.4}
        public IActionResult Add(ProductDto dto)
        {
            if (dto.Name.Length <= 0 || dto.Color.Length <= 0 || dto.Price <= 0)
            {
                return BadRequest();    // if any of the values is incorrect return bad request
            }

            // id of new object is 1 if list empty, else max id + 1
            long id = Program.Products.Count > 0 ? Program.Products.Max(product => product.Id) + 1 : 1;        
            Product product = ProductAdapter.ProductDtoToProduct(dto);
            product.Id = id;
            Program.Products.Add(product);
            return Ok();
        }

        [HttpPut]       // PUT /api/product Request body: {"id": 2, "price": 11}
        public IActionResult ModifyPrice(PriceChangeDto dto)
        {
            if (dto.Id <= 0 || dto.Price <= 0)
            {
                return BadRequest();    // if any of the values is incorrect return bad request
            }
            Product product = Program.Products.Find(product => product.Id == dto.Id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.Price = dto.Price;      // change price and save
                return Ok(ProductAdapter.ProductToProductDto(product));
            }
            
        }

        [HttpDelete("{id?}")]       // DELETE /api/product/1
        public IActionResult Delete(long id = 0)
        {
            Product product = Program.Products.Find(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Program.Products.Remove(product);
                return Ok();
            }
        }

        [HttpGet("find")]       // GET /api/product/find?color=blue
        public IActionResult FindByColor(string color = "")
        {
            if (color.Length <= 0)
            {
                return BadRequest();    // if color value is incorrect return bad request
            }
            List<Product> products = Program.Products.FindAll(product => product.Color.ToLower().Contains(color.ToLower()));
            List<ProductDto> result = new List<ProductDto>();
            products.ForEach(product => result.Add(ProductAdapter.ProductToProductDto(product)));
            return Ok(result);
        }
    }
}
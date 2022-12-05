using AutoMapper;
using Curso.Data.Interfaces;
using Curso.Dtos;
using Curso.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
       private readonly IApiRepository _repo;
       private readonly IMapper _mapper;
        public ProductsController(IApiRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetProductAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var product = await _repo.GetProductByNameAsync(name);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto productDto)
        {
            // var productToCreate = new Product();
            // productToCreate.Name = productDto.Name;
            // productToCreate.Description = productDto.Description;
            // productToCreate.Price = productDto.Precio;
            // productToCreate.DateIn = DateTime.Now;
            // productToCreate.Active = true;
            var productToCreate = _mapper.Map<Product>(productDto);
            _repo.Add(productToCreate);
            if(await _repo.SaveAll())
                return Ok(productToCreate);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, ProductUpdateDto productDto){
            if(id != productDto.Id)
                return BadRequest("The id no is equal");
            var productToUpdate = await _repo.GetProductByIdAsync(productDto.Id);
            if(productToUpdate == null)
                return BadRequest();
        
            productToUpdate.Description = productDto.Description;
            productToUpdate.Price = productDto.Price;

            if(!await _repo.SaveAll())
                return NoContent();
            
            return Ok(productToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if(product == null)
                return NotFound("Product no found");

            _repo.Delete(product);
            if(!await _repo.SaveAll())
                return BadRequest("It doesn't delete product");
            
            return Ok("Product delete");
        }
    }
}
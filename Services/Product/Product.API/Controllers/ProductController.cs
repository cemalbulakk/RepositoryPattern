using Microsoft.AspNetCore.Mvc;
using Product.API.Dtos;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using Shared.ControllerBases;
using Shared.Dtos;
using Product = Product.Domain.Entities.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductRepository _productRepository;

        // GET: api/<ProductController>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get(int skip, int take)
        {
            var response = _productRepository.FindAll().Skip(skip).Take(take).ToList();
            return CreateActionResultInstance(Response<List<Domain.Entities.Product>>.Success(response, 200));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _productRepository.FindById(id);
            return CreateActionResultInstance(Response<Domain.Entities.Product>.Success(response, 200));
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductCreateDto model)
        {
            var product = new Domain.Entities.Product()
            {
                Code = model.Code,
                Name = model.Name,
                CreatedDate = DateTime.Now,
                Category = new Category()
                {
                    Name = "Tanımsız"
                }
            };
            var response = _productRepository.Create(product);
            return CreateActionResultInstance(response > 0
                ? Response<NoContent>.Success(200)
                : Response<NoContent>.Fail("not added.", 400));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

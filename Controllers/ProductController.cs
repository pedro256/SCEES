using Microsoft.AspNetCore.Mvc;
using SCEES.Domain.Models;
using SCEES.Domain.Services;
using SCEES.Resorces.Errors;
using System;
using System.Threading.Tasks;

namespace SCEES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productServices;
        public ProductController(IProductService services)
        {
            this.productServices = services;
        }
        [HttpGet]
        public async Task<ActionResult> getAllAsync()
        {
            return Ok(await productServices.findAllAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var item = await productServices.findAsync(id);
            if (item == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(item);
        }
        [HttpGet]
        [Route("queryName")]
        public async Task<ActionResult> GetQueryName([FromQuery (Name ="name")]string name)
        {
            var result = await productServices.findAsync(name);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(result);
        }
        [HttpGet]
        [Route("queryPrice")]
        public async Task<ActionResult> GetQuery([FromQuery(Name = "price")] decimal price)
        {
            var result = await productServices.findByPrice(price);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(result);
        }
        [HttpGet]
        [Route("querySalePrice")]
        public async Task<ActionResult> GetQuerySAle([FromQuery(Name = "salePrice")] decimal price)
        {
            var result = await productServices.findByPriceSale(price);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(result);
        }
        [HttpGet]
        [Route("queryQtd")]
        public async Task<ActionResult> GetQueryQtd([FromQuery(Name = "qtd")] int qtd)
        {
            var result = await productServices.findByQtd(qtd);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(result);
        }
        [HttpGet]
        [Route("queryDateValid")]
        public async Task<ActionResult> GetQueryDateValid([FromQuery(Name = "dateValid")] DateTime dateTime)
        {
            var result = await productServices.findByDateValid(dateTime);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(result);
        }

        [HttpGet]
        [Route("category/{id:guid}")]
        public async Task<ActionResult> GetByCategory(Guid id)
        {
            var result = await productServices.findByCategoryId(id);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> create([FromBody]Product product)
        {
            if (!ModelState.IsValid) return BadRequest(new ErrorResponse { Error = null, Status = false });
            var productIn = await productServices.createAsync(product);
            return Ok(productIn);
        }
        [HttpPut]
        public async Task<ActionResult> update([FromBody] Product product)
        {
            var result = await productServices.updateAsync(product);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return NoContent();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> delete(Guid id)
        {
            bool response = await productServices.deleteAsync(id);
            if (response) return NoContent();
            return NotFound();
        }

    }
}

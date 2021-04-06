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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService IcategoryService)
        {
            this.categoryService = IcategoryService;
        }

        [HttpGet]
        public async Task<ActionResult> getAll()
        {
            return Ok(await categoryService.findAllAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> getOneById(Guid id)
        {
            var item = await categoryService.findByIdAsync(id);
            if (item != null) return Ok(item);
            return NotFound(new ErrorResponse { Error = null, Status = false });
        }
        [HttpGet]
        [Route("query")]
        public async Task<ActionResult> getByName([FromQuery] string name)
        {
            var item = await categoryService.findByNameAsync(name);
            if (item == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(item);

        }
        [HttpPost]
        public async Task<ActionResult> add([FromBody]Category category)
        {

            if (!ModelState.IsValid) return BadRequest(new ErrorResponse { Error = null, Status = false });
            var categorIn= await categoryService.create(category);
            return Ok(categorIn);
        }

        [HttpPut]
        public async Task<ActionResult> update([FromBody] Category category)
        {
            var result = await categoryService.updateAsync(category);
            if (result == null) return NotFound(new ErrorResponse { Error=null,Status=false});
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> delete(Guid id)
        {
            bool response = await categoryService.deleteAsync(id);
            if (response) return NoContent();
            return NotFound();
        }
        
    }
}

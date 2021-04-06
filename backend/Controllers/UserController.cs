using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCEES.Domain.Services;
using SCEES.Models;
using SCEES.Resorces.Errors;
using System;
using System.Threading.Tasks;

namespace SCEES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userServiceInsert)
        {
            this.userService = userServiceInsert;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await userService.findAllAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var user = await userService.findByIdAsync(id);
            if (user == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult> update(Usuario usuario)
        {
            var result = await userService.updateAsync(usuario);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(new ErrorResponse { Error = null, Status = false });
            var userIn = await userService.createUser(usuario);
            return Ok(userIn);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool response = await userService.deleteAsync(id);
            if (response) return NoContent();
            return NotFound();
        }

    }
}

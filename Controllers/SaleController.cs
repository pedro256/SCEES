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
    public class SaleController: ControllerBase
    {
        private readonly ISaleService saleService;
        public SaleController(ISaleService _saleService){
            this.saleService = _saleService;
        }

        [HttpGet]
        public async Task<ActionResult> getAll(){
            return  Ok(await saleService.findAllAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> getById(Guid id){
            var item = await saleService.findById(id);
            if(item==null) return NotFound(new ErrorResponse{Error=false,Status=false});
            return Ok(item);
        }
        [HttpGet]
        [Route("queryIdProduct")]
        public async Task<ActionResult> getByIdProduct([FromQuery(Name="idProduct")] Guid idProduct){
            var item = await saleService.findByIdProduct(idProduct);
            if(item==null) return NotFound(new ErrorResponse{Error=false,Status=false});
            return Ok(item);
        }
        [HttpGet]
        [Route("queryDateCreate")]
        public async Task<ActionResult> getByDateCreated([FromQuery(Name="dateCreated")] DateTime dateTime){
            var item = await saleService.findByDateCreate(dateTime);
            if(item==null) return NotFound(new ErrorResponse{Error=false,Status=false});
            return Ok(item);
        }
        [HttpGet]
        [Route("queryNameClient")]
        public async Task<ActionResult> getByNameClient([FromQuery(Name="nameClient")] string name){
            var item = await saleService.findByNameClient(name);
            if(item==null) return NotFound(new ErrorResponse{Error=false,Status=false});
            return Ok(item);
        }
        [HttpGet]
        [Route("queryQtd")]
        public async Task<ActionResult> getByQtd([FromQuery(Name="qtd")] int qtd){
            var item = await saleService.findByQtd(qtd);
            if(item==null) return NotFound(new ErrorResponse{Error=false,Status=false});
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> create([FromBody] Sale sale){
            if(!ModelState.IsValid) return BadRequest(new ErrorResponse{Error=false,Status=false});
            var saleIn = await saleService.createAsync(sale);
            return Ok(saleIn);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool response = await saleService.deleteAsync(id);
            if (response) return NoContent();
            return NotFound();
        }
        [HttpPut]
        public async Task<ActionResult> update(Sale sale)
        {
            var result = await saleService.updateAsync(sale);
            if (result == null) return NotFound(new ErrorResponse { Error = null, Status = false });
            return NoContent();
        }
           

    }
}
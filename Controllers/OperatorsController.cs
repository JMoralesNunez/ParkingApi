using Microsoft.AspNetCore.Mvc;
using ParkingProyect.Data;
using ParkingProyect.Models;
using ParkingProyect.DTOs;
using Microsoft.EntityFrameworkCore;
using ParkingProyect.Services;

namespace ParkingProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly PostgresContext _context; //POr remover, pues se usará servicios
        private readonly OperatorService _operatorService;
        
        public OperatorsController(PostgresContext context, OperatorService operatorService)
        {
            _context = context; //por remover
            _operatorService = operatorService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<OperatorDTO>>> Get()
        {
            return Ok(await _operatorService.Get());
        }

        [HttpGet]
        [Route("Search/{id}")]
        public async Task<ActionResult<OperatorDTO>> Search(int id)
        {
            var operatorDto = new OperatorDTO();
            var operatordb = await _context.Operators.FindAsync(id);
            
            if (operatordb == null) return NotFound("Operator not found");
            
            operatorDto.operator_id = id;
            operatorDto.full_name = operatordb.full_name;
            operatorDto.email = operatordb.email;
            operatorDto.is_active = operatordb.is_active;
            operatorDto.created_at = operatordb.created_at;
            
            return Ok(operatorDto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Operator>> Create(Operator operatordb)
        {
            if ( ModelState.IsValid)
            {
                _context.Operators.Add(operatordb);
                await _context.SaveChangesAsync();
                return Ok("Operator added");
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<Operator>> Update(int id, Operator operatordb)
        {
            var operatortoUpdate = await _context.Operators.FindAsync(id);
            
            operatortoUpdate.full_name = operatordb.full_name;
            operatortoUpdate.password_hash = operatordb.password_hash;
            operatortoUpdate.email = operatordb.email;
            
            _context.Operators.Update(operatortoUpdate);
            await _context.SaveChangesAsync();
            return Ok("Operator updated");
        }
        
        [HttpPut]
        [Route("State/{id}")]
        public async Task<ActionResult<Operator>> ChangeState(int id, OperatorDTO operatordto)
        {
            var operatortoUpdate = await _context.Operators.FindAsync(id);
            
            operatortoUpdate.is_active = operatordto.is_active;
            
            _context.Operators.Update(operatortoUpdate);
            await _context.SaveChangesAsync();
            return Ok("Operator state updated");
        }
    }
}

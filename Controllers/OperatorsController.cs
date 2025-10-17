using Microsoft.AspNetCore.Mvc;
using ParkingProyect.Data;
using ParkingProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace ParkingProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly PostgresContext _context;
        
        public OperatorsController(PostgresContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListOperators")]
        public async Task<ActionResult<IEnumerable<Operator>>> GetOperators()
        {
            return Ok(await _context.Operators.ToListAsync());
        }
    }
}

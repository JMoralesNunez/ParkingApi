using ParkingProyect.DTOs;
using Microsoft.EntityFrameworkCore;
using ParkingProyect.Data;
using ParkingProyect.Models;

namespace ParkingProyect.Services;

public class OperatorService
{
    private readonly PostgresContext _context;
    
    public OperatorService(PostgresContext context)
    {
        _context = context;
    }

    public async Task<List<OperatorDTO>> Get()
    {
        var operators = await _context.Operators.OrderBy(o => o.operator_id).ToListAsync();
        var operatorsDto = new List<OperatorDTO>();
            
        foreach (var op in operators)
        {
            operatorsDto.Add(new OperatorDTO
            {
                operator_id = op.operator_id,
                full_name = op.full_name,
                email = op.email,
                is_active = op.is_active,
                created_at = op.created_at,
            });
        }
            
        return operatorsDto;
    }
}
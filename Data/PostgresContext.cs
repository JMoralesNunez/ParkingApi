using ParkingProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace ParkingProyect.Data;

public class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
    {
    }
    
    public DbSet<Operator> Operators { get; set; }
}
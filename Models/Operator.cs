using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingProyect.Models;

[Table("operators")]
public class Operator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int operator_id { get; set; }

    public string password_hash { get; set; }

    public string full_name { get; set; }

    public string? email { get; set; }
    
    public bool is_active { get; set; }
    
    public DateTime created_at { get; set; }
}
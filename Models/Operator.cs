namespace ParkingProyect.Models;

public class Operator
{
    public int operator_id { get; set; }

    public string password_hash { get; set; }

    public string full_name { get; set; }

    public string? email { get; set; }
    
    public bool is_active { get; set; }
    
    public DateTime created_at { get; set; }
}
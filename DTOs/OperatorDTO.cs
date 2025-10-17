namespace ParkingProyect.DTOs;

public class OperatorDTO
{
    public int? operator_id { get; set; }

    public string? full_name { get; set; }

    public string? email { get; set; }
    
    public bool is_active { get; set; }
    
    public DateTime? created_at { get; set; }
}
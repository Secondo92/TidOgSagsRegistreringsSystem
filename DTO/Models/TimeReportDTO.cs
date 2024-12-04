namespace DTO.Models
{
    public class TimeReportDTO
    {
        public string Period { get; set; } // F.eks. "Uge 1" eller "01/2024"
        public double TotalHours { get; set; }
    }
}
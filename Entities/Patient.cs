using System.ComponentModel.DataAnnotations;

namespace HealthcareAPI.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

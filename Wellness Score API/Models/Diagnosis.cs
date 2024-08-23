using System.ComponentModel.DataAnnotations;

namespace Wellness_Score_API.Models
{
    public class Diagnosis
    {
        [Required]
        public int Id { get; set; }
        public float Pulse { get; set; }
        public float HBP { get; set; }
        public float LBP { get; set; }
        public float Hemoglobin { get; set; }
        public float HBA1C_FBS { get; set; }
        public float Cholesterol { get; set; }
        public float Creatinine { get; set; }
        public float SGPT { get; set; }
        public string ECG_TMT { get; set; }
        public string MER { get; set; }
        public float BMI { get; set; }
        public float ESR { get; set; }
        public int? WellnessScore { get; set; }
    }
}

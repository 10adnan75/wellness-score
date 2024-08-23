using System.ComponentModel.DataAnnotations;

namespace Wellness_Score_API.DataContext
{
    public class CustomerDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public int Age { get; set; }
        [Display(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string City { get; set; }
        public string Plan { get; set; }
        public string Coverage { get; set; }
    }
}

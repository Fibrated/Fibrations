using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UserInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}

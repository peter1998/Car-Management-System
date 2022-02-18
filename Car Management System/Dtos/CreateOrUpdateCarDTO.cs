using Car_Management_System.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Car_Management_System.Dtos
{
    public record CreateOrUpdateCarDTO
    {
        [Required]
        public string Owner { get; set; }

        [Required]
        public CarBrand Brand { get; set; }
        [Required]
        public CarModel Model { get; set; }

        [Required]
        public string Registration { get; set; }

        [Required]
        public int EngineCapacity { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int HorsePower { get; set; }
    }
}

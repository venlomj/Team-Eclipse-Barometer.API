using System.ComponentModel.DataAnnotations;

namespace Barometer.DTO
{
    public class BarometerRequest
    {
        public int BarometerId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "EmployeeCount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeCount must be greater than 0")]
        public int EmployeeCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

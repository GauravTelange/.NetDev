using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class Customer
    {
        [Required]
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        [Key]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerName { get; set; }

        public decimal CustomerAmount { get; set; }
    }
}
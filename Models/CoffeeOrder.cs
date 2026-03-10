using System.ComponentModel.DataAnnotations;

namespace CoffeeQueueApp.Models
{
    public class CoffeeOrder
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(50)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Drink { get; set; } = "Latte";

        //size
        [Required]
        [StringLength(15)]
        public string Size { get; set; } = "Medium";

        //milk option
        [Required]
        [StringLength(50)]
        public string Milk { get; set; } = "Full Cream";

        //sugar
        [Range(0, 6, ErrorMessage = "Sugar must be between 0 and 6")]
        public int Sugar { get; set; } = 0;

        //status of order (pending, in progress, completed)
        [Required]
        [StringLength(15)]
        public string Status { get; set; } = "Completed";

        //date created
        public DateTime CreatedAt { get; set; }

    }
}

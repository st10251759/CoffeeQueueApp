using System.ComponentModel.DataAnnotations;

namespace CoffeeQueueApp.Models
{
    public class Barista
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Barista Name Required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Barista shift time required")]
        [StringLength(20)]
        public string Shift { get; set; } = "Morning";

        //navigation property/foreign key
        public List<CoffeeOrder> Order { get; set; } = new List<CoffeeOrder>();
        // oner order can only have one barsita 


    }
}

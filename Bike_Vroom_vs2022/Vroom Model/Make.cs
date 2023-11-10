using System.ComponentModel.DataAnnotations;

namespace Bike_Vroom_vs2022.Vroom_Model
{
    public class Make
    {
        public int Id { get; set; }
        [Required]
        [StringLength(225)]
        public string Name { get; set; }
    }
}

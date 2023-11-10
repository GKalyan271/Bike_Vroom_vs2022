using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bike_Vroom_vs2022.Vroom_Model
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [StringLength(225)]
        public string Name { get; set; }
        public Make Make { get; set; }
        public int MakeID { get; set; }


    }
}

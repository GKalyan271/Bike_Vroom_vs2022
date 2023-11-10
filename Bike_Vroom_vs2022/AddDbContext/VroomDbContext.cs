using Bike_Vroom_vs2022.Vroom_Model;
using Bike_Vroom_vs2022.Vroom_Model.ViewModelView;
using Microsoft.EntityFrameworkCore;

namespace Bike_Vroom_vs2022.AddDbContext
{
    public class VroomDbContext : DbContext
    {
        public VroomDbContext(DbContextOptions<VroomDbContext> options):base(options) 
        {
        }   
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
       // public DbSet<ModelViewModel> ViewModels { get; set; }
    }
}

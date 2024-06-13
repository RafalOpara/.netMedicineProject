using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Database
{
    public class MedicineProjectDbContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }


        public MedicineProjectDbContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}

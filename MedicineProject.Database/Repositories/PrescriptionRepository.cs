using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Database
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {

        protected override DbSet<Prescription> DbSet => _context.Prescriptions;

        public PrescriptionRepository (MedicineProjectDbContext dbContext) : base(dbContext)
        {
            
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return DbSet/*.Include(x=>x.Medicines)*/.Select(x => x);
        }

     

    }
}

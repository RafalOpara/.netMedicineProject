using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Database
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {

        protected override DbSet<Medicine> DbSet => _context.Medicines;

        public MedicineRepository(MedicineProjectDbContext dbContext) : base(dbContext)
        {
            
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return DbSet.Select(x => x);
        }

    
    }
}

using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Database
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {

        protected override DbSet<Doctor> DbSet => _context.Doctors;

        public DoctorRepository(MedicineProjectDbContext dbContext) : base(dbContext)
        {
            
        }


        public IEnumerable<Doctor> GetAllDoctors()
        {

            return DbSet/*.Include(x=>x.Prescriptions).ThenInclude(x => x.Medicines)*/.Select(x=>x);
        }

       
    }
}

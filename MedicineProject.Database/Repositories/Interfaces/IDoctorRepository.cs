namespace MedicineProject.Database
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
    }
}
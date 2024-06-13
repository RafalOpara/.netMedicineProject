namespace MedicineProject.Database
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptions();
    }
}
namespace MedicineProject.Database
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
    }
}
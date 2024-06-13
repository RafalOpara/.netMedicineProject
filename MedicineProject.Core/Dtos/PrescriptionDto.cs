using MedicineProject.Database;

namespace MedicineProject
{
    public class PrescriptionDto
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public DoctorDto Doctor { get; set; }

        public IEnumerable<MedicineDto> Medicines { get; set; }
    }
}

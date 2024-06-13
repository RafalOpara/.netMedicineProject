using MedicineProject;

namespace MedicineApp
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public DoctorViewModel Doctor { get; set; }

        public IEnumerable<MedicineViewModel> Medicines { get; set; }

    }
}

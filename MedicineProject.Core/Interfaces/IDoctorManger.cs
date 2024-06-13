namespace MedicineProject.Core.Interfaces
{
    public interface IDoctorManger
    {
        void AddNewDoctor(DoctorDto doctor);
        void AddNewMedicine(MedicineDto medicine, int prescriptionId);
        void AddNewPrescription(PrescriptionDto prescription, int doctorId);
        bool DeleteDoctor(DoctorDto doctor);
        bool DeleteMedicine(MedicineDto medicine);
        bool DeletePrescription(PrescriptionDto prescription);
        List<DoctorDto> GetAllDoctors(string filterString);
        List<MedicineDto> GetAllMedicineForAPrescription(int prescriptionId, string filterString);
        List<PrescriptionDto> GetAllPrescriptionForADoctor(int doctorId, string filterString);
    }
}

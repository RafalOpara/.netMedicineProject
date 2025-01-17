﻿using MedicineProject.Core.Interfaces;
using MedicineProject.Database;

namespace MedicineProject.Core
{
  

    public class DoctorManger : IDoctorManger
    {
        private readonly IDoctorRepository mDoctorRepository;
        private readonly IMedicineRepository mDMedicineRepository;
        private readonly IPrescriptionRepository mPrescriptionpository;
        private readonly DtoMapper mDtoMapper;


        public DoctorManger(IDoctorRepository doctorRepository,
            IMedicineRepository medicineRepository,
            IPrescriptionRepository prescriptionRepository,
            DtoMapper mDoctorMapper)
        {
            mDoctorRepository = doctorRepository;
            mDMedicineRepository = medicineRepository;
            mPrescriptionpository = prescriptionRepository;
            mDtoMapper = mDoctorMapper;
        }


        public List<DoctorDto> GetAllDoctors(string filterString)
        {
            var doctorEntities = mDoctorRepository.GetAllDoctors().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                doctorEntities = doctorEntities
                    .Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString))
                    .ToList();
            }

            return mDtoMapper.Map(doctorEntities);
        }

        public List<PrescriptionDto> GetAllPrescriptionForADoctor(int doctorId, string filterString)
        {
            var prescriptionEntities = mPrescriptionpository.GetAllPrescriptions()
                .Where(x => x.DoctorId == doctorId)
                .ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                prescriptionEntities = prescriptionEntities
                    .Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(prescriptionEntities);
        }

        public List<MedicineDto> GetAllMedicineForAPrescription(int prescriptionId, string filterString)
        {
            var medicineEntities = mDMedicineRepository.GetAllMedicines().Where(x => x.PrescriptionId == prescriptionId).ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                medicineEntities = medicineEntities
                    .Where(x => x.ActiveSubstance.Contains(filterString) ||
                    x.Name.Contains(filterString) ||
                    x.CompanyName.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(medicineEntities);
        }

        public void AddNewMedicine(MedicineDto medicine, int prescriptionId)
        {
            var entity = mDtoMapper.Map(medicine);

            entity.PrescriptionId = prescriptionId;

            mDMedicineRepository.AddNew(entity);
        }

        public void AddNewPrescription(PrescriptionDto prescription, int doctorId)
        {
            var entity = mDtoMapper.Map(prescription);

            entity.DoctorId = doctorId;

            mPrescriptionpository.AddNew(entity);
        }

        public void AddNewDoctor(DoctorDto doctor)
        {
            var entity = mDtoMapper.Map(doctor);

            mDoctorRepository.AddNew(entity);
        }




        /////usuwanie
        ///

        public bool DeleteMedicine(MedicineDto medicine)
        {
            var entity = mDtoMapper.Map(medicine);

            return mDMedicineRepository.Delete(entity);
        }

        public bool DeletePrescription(PrescriptionDto prescription)
        {
            var entity = mDtoMapper.Map(prescription);

            return mPrescriptionpository.Delete(entity);
        }

        public bool DeleteDoctor(DoctorDto doctor)
        {
            var entity = mDtoMapper.Map(doctor);

            return mDoctorRepository.Delete(entity);
        }

    }
}

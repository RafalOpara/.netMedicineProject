using AutoMapper;
using MedicineProject.Database;

namespace MedicineProject
{
    public class DtoMapper
    {
        private IMapper mMapper;

        public DtoMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {

                config.CreateMap<Medicine, MedicineDto>()
                .ForMember(x=>x.PriceInTotal, opt => opt.MapFrom(y=>y.Price * y.Amount))
                .ReverseMap();

                config.CreateMap<Prescription, PrescriptionDto>()
                .ReverseMap();

                config.CreateMap<Doctor, DoctorDto>()
                .ReverseMap();

            }).CreateMapper();
        }


        #region Medicine Maps

        public MedicineDto Map(Medicine medicine)
            => mMapper.Map<MedicineDto>(medicine);

        public List<MedicineDto> Map(List<Medicine> medicines)
            => mMapper.Map<List<MedicineDto>>(medicines);

         public Medicine Map(MedicineDto medicine)
            => mMapper.Map<Medicine>(medicine);

        public List<Medicine> Map(List<MedicineDto> medicines)
            => mMapper.Map<List<Medicine>>(medicines);

        #endregion

        #region Doctor Maps

        public DoctorDto Map(Doctor doctor)
           => mMapper.Map<DoctorDto>(doctor);

        public List<DoctorDto> Map(List<Doctor> doctor)
            => mMapper.Map<List<DoctorDto>>(doctor);

        public Doctor Map(DoctorDto doctor)
           => mMapper.Map<Doctor>(doctor);

        public List<Doctor> Map(List<DoctorDto> doctor)
            => mMapper.Map<List<Doctor>>(doctor);



        #endregion

        #region Prescription Maps
        public PrescriptionDto Map(Prescription prescription)
          => mMapper.Map<PrescriptionDto>(prescription);

        public List<PrescriptionDto> Map(List<Prescription> prescription)
            => mMapper.Map<List<PrescriptionDto>>(prescription);

        public Prescription Map(PrescriptionDto prescription)
           => mMapper.Map<Prescription>(prescription);

        public List<Prescription> Map(List<PrescriptionDto> prescription)
            => mMapper.Map<List<Prescription>>(prescription);
        #endregion
    }
}

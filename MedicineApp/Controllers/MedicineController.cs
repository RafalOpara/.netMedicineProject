using MedicineProject;
using MedicineProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MedicineApp.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IDoctorManger mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;


      

        public MedicineController(IDoctorManger doctorManager,ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        

        public IActionResult Index(int indexOfDoctor, int prescriptionId, string filterString)
        {
            TempData["DoctorId"]= indexOfDoctor;
            TempData["PresriptionId"] = prescriptionId;


            var prescriptionDtos = mDoctorManager.GetAllPrescriptionForADoctor(indexOfDoctor, null).
                FirstOrDefault(x=>x.Id==prescriptionId);

            var medicineDtos = mDoctorManager.GetAllMedicineForAPrescription(prescriptionId, filterString);

            var prescriptionViewModel = mViewModelMapper.Map(prescriptionDtos);
            prescriptionViewModel.Medicines = mViewModelMapper.Map(medicineDtos);



            return View(prescriptionViewModel);
           
            
        }

        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVm)
        {
            var dto=mViewModelMapper.Map(medicineVm);

            mDoctorManager.AddNewMedicine(dto, int.Parse(TempData["PresriptionId"].ToString()));
            
            return RedirectToAction("Index", new { indexOfDoctor = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PresriptionId"].ToString()) });

        }

        public IActionResult Delete(int medicineId)
        {

            mDoctorManager.DeleteMedicine(new MedicineDto { Id = medicineId });

            return RedirectToAction("Index", new { indexOfDoctor = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PresriptionId"].ToString()) });
        }
    }
}

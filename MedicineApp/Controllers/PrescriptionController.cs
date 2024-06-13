using MedicineProject.Core.Interfaces;
using MedicineProject;
using Microsoft.AspNetCore.Mvc;
using MedicineProject.Database;

namespace MedicineApp.Controllers
{
    public class PrescriptionController : Controller
    {

        private readonly IDoctorManger mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;


       

        public PrescriptionController(IDoctorManger doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

       


        public IActionResult Index(int indexOfDoctor, string filterString)
        {
            TempData["DoctorId"] = indexOfDoctor;


            var doctorDto = mDoctorManager.GetAllDoctors(null).
                                FirstOrDefault(x => x.Id == indexOfDoctor);

            var prescriptionDtos = mDoctorManager.GetAllPrescriptionForADoctor(indexOfDoctor, filterString);

            var doctorViewModel = mViewModelMapper.Map(doctorDto);
            doctorViewModel.Prescriptions = mViewModelMapper.Map(prescriptionDtos);


            return View(doctorViewModel);


        }

        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVm)
        {
           var dto = mViewModelMapper.Map(prescriptionVm);

            mDoctorManager.AddNewPrescription(dto, int.Parse(TempData["DoctorId"].ToString()));

            var tes = int.Parse(TempData["DoctorId"].ToString());

            return RedirectToAction("Index", new { indexOfDoctor = int.Parse(TempData["DoctorId"].ToString()) });

        }


        public IActionResult View(int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine", new { indexOfDoctor = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = prescriptionId });
        }



        public IActionResult Delete(int prescriptionId)
        {
            mDoctorManager.DeletePrescription(new PrescriptionDto { Id = prescriptionId });

            return RedirectToAction("Index", new { indexOfDoctor = int.Parse(TempData["DoctorId"].ToString()) });
        }

    }
}

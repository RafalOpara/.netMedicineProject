using MedicineProject.Core.Interfaces;
using MedicineProject;
using Microsoft.AspNetCore.Mvc;
using MedicineProject.Database;

namespace MedicineApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDoctorManger mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;


        private int PrescriptionId { get; set; }

        public HomeController(IDoctorManger doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(string filterString)
        {
            var doctorsDtos = mDoctorManager.GetAllDoctors(filterString);

           var doctorViewModels= mViewModelMapper.Map(doctorsDtos);

            return View(doctorViewModels);
            
        }

        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(DoctorViewModel doctorVm)
        {
            var dto = mViewModelMapper.Map(doctorVm);

            mDoctorManager.AddNewDoctor(dto);

            return RedirectToAction("Index");

        }


        public IActionResult View(int doctorId)
        {
            return RedirectToAction("Index", "Prescription", new {indexOfDoctor = doctorId });
        }

        


        public IActionResult Delete(int doctorId)
        {

            mDoctorManager.DeleteDoctor(new DoctorDto { Id = doctorId });

            var doctorsDtos = mDoctorManager.GetAllDoctors(null);

            var doctorViewModels = mViewModelMapper.Map(doctorsDtos);

            return View("Index", doctorViewModels);

        }
    }
}

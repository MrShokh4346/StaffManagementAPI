using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StaffManagementAPI.Models;
using StaffManagementAPI.ViewModels;

namespace StaffManagementAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IWebHostEnvironment _env;

        public HomeController(IStaffRepository staffRepository, IWebHostEnvironment env)
        {
            _staffRepository = staffRepository;
            _env = env;
        }

        public ViewResult Index()
        {
          
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll(),
            };
            return View(viewModel);
        }
        public ViewResult Detail(int? id)
        {

            HomeDetailViewModel viewModel = new HomeDetailViewModel()
            {
                Staff = _staffRepository.Get(id??1),
                Title = "Staff details"
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            Staff staff = _staffRepository.Get(id);
            HomeUpdateViewModel viewModel = new HomeUpdateViewModel()
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Email = staff.Email,
                Department = staff.Department,
                ExistingPhotoFilePath = staff.PhotoFilePath
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel staff)
        {
            string uniqueFileName = string.Empty;
            if (ModelState.IsValid)
            {

                uniqueFileName = ProccessImageFile(staff);

                Staff newStaff = new Staff()
                {
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Email = staff.Email,
                    Department = staff.Department,
                    PhotoFilePath = uniqueFileName
                };

                newStaff = _staffRepository.Create(newStaff);
                return RedirectToAction("detail", new { id = newStaff.Id });
            }
            return View();
        }


        [HttpPost]
        public IActionResult Update(HomeUpdateViewModel updatedStaff)
        {
            string uniqueFileName = string.Empty;
            if (ModelState.IsValid)
            {
                Staff staff = _staffRepository.Get(updatedStaff.Id);
                staff.FirstName = updatedStaff.FirstName;
                staff.LastName = updatedStaff.LastName;
                staff.Email = updatedStaff.Email;
                staff.Department = updatedStaff.Department;
                if(updatedStaff.Photo != null)
                {
                    if(updatedStaff.ExistingPhotoFilePath != null)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "images", updatedStaff.ExistingPhotoFilePath);
                        System.IO.File.Delete(filePath);
                    }
                    staff.PhotoFilePath = ProccessImageFile(updatedStaff);
                }
                _staffRepository.Update(staff);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProccessImageFile(HomeCreateViewModel staff)
        {
            string uniqueFileName;
            var uploadFolderfilePath = Path.Combine(_env.WebRootPath, "images");
            if (staff.Photo != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
                string imageFilePath = Path.Combine(uploadFolderfilePath, uniqueFileName);
                staff.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
            }
            else
            {
                uniqueFileName = "user.jpg";
            }
            return uniqueFileName;
        }

        public IActionResult Delete(int id) 
        {
            _staffRepository.Delete(id);
            return RedirectToAction("index");
        }


    }
}

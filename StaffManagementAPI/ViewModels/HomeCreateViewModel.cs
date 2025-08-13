using StaffManagementAPI.Attributes;
using StaffManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace StaffManagementAPI.ViewModels
{
    public class HomeCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Departament")]
        public Department Department { get; set; }

        [MaxFileSize(800)]
        [AllowedExtensions(new string[] {".jpeg", ".png"})]
        public IFormFile? Photo { get; set; }
    }
}

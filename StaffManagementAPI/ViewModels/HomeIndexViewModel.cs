using StaffManagementAPI.Models;

namespace StaffManagementAPI.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
    }
}


namespace StaffManagementAPI.Models
{
    public class SQLServerStaffRepositiry : IStaffRepository
    {
        private List<Staff> _staffs = null;
        public SQLServerStaffRepositiry()
        {
            _staffs = new List<Staff>()
                {
                    new Staff() {Id = 1, FirstName = "Ali", LastName = "Valiyev", Email = "ali@gmail.com", Department = Department.Admin},
                    new Staff() {Id = 2, FirstName = "Usmon", LastName = "Aliyev", Email = "usmon@gmail.com", Department = Department.IT},
                    new Staff() {Id = 3, FirstName = "Abbos", LastName = "Axrorov", Email = "abbos@gmail.com", Department = Department.Marketing},
                    new Staff() {Id = 3, FirstName = "Umar", LastName = "Axmadov", Email = "umar@gmail.com", Department = Department.Science},
                };
        }

        public Staff Create(Staff staff)
        {
            staff.Id = _staffs.Max(s=>s.Id) + 1;
            _staffs.Add(staff);
            return staff;
        }

        public Staff Delete(int id)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id.Equals(id));
            if (staff != null)
            {
                _staffs.Remove(staff);
            }
            return staff;
        }

        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }

        public Staff Update(Staff updatedStaff)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id.Equals(updatedStaff.Id));
            if (staff != null)
            {
                staff.FirstName = updatedStaff.FirstName;
                staff.LastName = updatedStaff.LastName;
                staff.Email = updatedStaff.Email;
                staff.Department = updatedStaff.Department;
            }
            return staff;
        }
    }
}

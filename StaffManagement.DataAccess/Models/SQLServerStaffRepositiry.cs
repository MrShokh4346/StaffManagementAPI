using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManagementAPI.Models;

namespace StaffManagement.DataAccess.Models
{
    public class SQLServerStaffRepositiry : IStaffRepository
    {
        private readonly AppDbContext dbContext;

        public SQLServerStaffRepositiry(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Staff Create(Staff staff)
        {
            dbContext.Staffs.Add(staff);
            dbContext.SaveChanges();
            return staff;
        }

        public Staff Delete(int id)
        {
            var staff = dbContext.Staffs.Find(id);
            if (staff != null)
            { 
                dbContext.Staffs.Remove(staff);
                dbContext.SaveChanges();
            }
            return staff;
        }

        public Staff Get(int id)
        {
            return dbContext.Staffs.Find(id);
        }

        public IEnumerable<Staff> GetAll()
        {
            return dbContext.Staffs;

        }

        public Staff Update(Staff updatedStaff)
        {
            var staff = dbContext.Staffs.Attach(updatedStaff);
            staff.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedStaff;
        }
    }
}

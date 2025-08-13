using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffManagementAPI.Models;

namespace StaffManagement.DataAccess.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    FirstName = "Nodir",
                    LastName = "Qodirov",
                    Email = "nodir@gmail.com",
                    Department = Department.IT
                },
                new Staff
                {
                    Id = 2,
                    FirstName = "Akbar",
                    LastName = "Bozorov",
                    Email = "akbar@gmail.com",
                    Department = Department.Marketing
                });
        }
    }
}

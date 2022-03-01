using RazorPagesLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLearn.Services
{
    public class MokEmployRepository : IEmployeeRepository
    {
        private List<employee> employees;
        public MokEmployRepository()
        {
            employees = new List<employee>()
            {
                new employee()
                {
                    Id = 0,
                    Name = "Mishail",
                    Email = "mary@example.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.IT
                },
                new employee()
                {
                    Id = 1,
                    Name = "Dmitry",
                    Email = "mary@example.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.IT
                },
                new employee()
                {
                    Id = 2,
                    Name = "Olga",
                    Email = "mary@example.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.IT
                },
                new employee()
                {
                    Id = 3,
                    Name = "Evgeny",
                    Email = "mary@example.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.IT
                }
            };
        }
        public IEnumerable<employee> GetAllEmployees()
        {
            return employees;
        }

        public employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }
    }
}

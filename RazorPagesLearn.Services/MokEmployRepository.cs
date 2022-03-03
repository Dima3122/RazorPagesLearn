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

        public employee Add(employee NewEmployee)
        {
            NewEmployee.Id = employees.Max(x => x.Id) + 1;
            employees.Add(NewEmployee);
            return NewEmployee;
        }

        public IEnumerable<employee> GetAllEmployees()
        {
            return employees;
        }

        public employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        public employee Update(employee UpdatedEmployee)
        {
            var employee = employees.FirstOrDefault(x => x.Id == UpdatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = UpdatedEmployee.Name;
                employee.Email = UpdatedEmployee.Email;
                employee.PhotoPath = UpdatedEmployee.PhotoPath;
                employee.Department = UpdatedEmployee.Department;
            }
            return employee;
        }
    }
}

using RazorPagesLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLearn.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<employee> GetAllEmployees();
        employee GetEmployee(int id);
        employee Update(employee UpdatedEmployee);
    }
}

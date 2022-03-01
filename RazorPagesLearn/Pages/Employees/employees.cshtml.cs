using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearn.Models;
using RazorPagesLearn.Services;

namespace RazorPagesLearn.Pages.Employees
{
    public class employeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;
        public employeesModel(IEmployeeRepository db)
        {
            _db = db;
        }
        public IEnumerable<employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = _db.GetAllEmployees();
        }
    }
}

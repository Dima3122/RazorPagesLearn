using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearn.Models;
using RazorPagesLearn.Services;

namespace RazorPagesLearn.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        public EditModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public employee Employee { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.GetEmployee(id);
            if (Employee == null)
            {
                RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}

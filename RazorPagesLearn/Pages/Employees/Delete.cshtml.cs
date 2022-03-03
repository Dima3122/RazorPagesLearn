using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearn.Models;
using RazorPagesLearn.Services;

namespace RazorPagesLearn.Pages.Employees
{
    public class DeleteModel : PageModel
    {
		private readonly IEmployeeRepository employeeRepository;

		[BindProperty]
		public employee Employee{ get; set; }
		public DeleteModel(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}
		public IActionResult OnGet(int id)
        {
			Employee = employeeRepository.GetEmployee(id);
			if (Employee == null)
			{
				return RedirectToPage("/NotFound");
			}
			return Page();
		}
		public IActionResult OnPost()
		{
			employee deletemployee = employeeRepository.Delete(Employee.Id);
			if (deletemployee == null)
			{
				return RedirectToPage("/NotFound");
			}
			return RedirectToPage("Employees");
		}
	}
}

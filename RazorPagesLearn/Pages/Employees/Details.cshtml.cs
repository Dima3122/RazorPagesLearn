using App.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearn.Metrics;
using RazorPagesLearn.Models;
using RazorPagesLearn.Services;

namespace RazorPagesLearn.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMetrics metrics;
        public DetailsModel(IEmployeeRepository employeeRepository, IMetrics metrics)
        {
            this.metrics = metrics;
            this.employeeRepository = employeeRepository;
        }
        public employee Employee { get; set; } 

        public IActionResult OnGet(int id)
        {
            metrics.Measure.Counter.Increment(BusinessMetrics.CounterAddButton);
            Employee = employeeRepository.GetEmployee(id);
            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}

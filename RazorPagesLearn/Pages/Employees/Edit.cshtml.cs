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
        /// <summary>
        /// Представление конкретного члена персонала
        /// </summary>
        [BindProperty]
        public employee Employee { get; set; }
        [BindProperty]
        public bool Norify { get; set; }
        public string msg { get; set; }
        /// <summary>
        /// Get запросы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.GetEmployee(id);
            if (Employee == null)
            {
                RedirectToPage("/NotFound");
            }
            return Page();
        }
        /// <summary>
        /// Пост запросы
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (ModelState.ErrorCount < 2)
            {
                Employee = employeeRepository.Update(Employee);
                TempData["msg"] = $"Update {Employee.Name} successful";
                return RedirectToPage("/Employees/employees");
            }
            return Page();
        }
        public void OnPostUpdate(int id)
        {
            if (Norify)
            {
                msg = "Спасибо что включили оповещения";
            }
            else
            {
                msg = "Оповещения не включены";
            }
            Employee = employeeRepository.GetEmployee(id);
        }
    }
}

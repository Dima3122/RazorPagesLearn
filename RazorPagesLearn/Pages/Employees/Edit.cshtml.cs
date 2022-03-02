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
        /// ������������� ����������� ����� ���������
        /// </summary>
        [BindProperty]
        public employee Employee { get; set; }
        [BindProperty]
        public bool Norify { get; set; }
        public string msg { get; set; }
        /// <summary>
        /// Get �������
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
        /// ���� �������
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
                msg = "������� ��� �������� ����������";
            }
            else
            {
                msg = "���������� �� ��������";
            }
            Employee = employeeRepository.GetEmployee(id);
        }
    }
}

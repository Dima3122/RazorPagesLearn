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
        public employee Employee { get; set; }
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
        public IActionResult OnPost(employee employee)
        {
            Employee = employeeRepository.Update(employee);
            return RedirectToPage("/Employees/employees");
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

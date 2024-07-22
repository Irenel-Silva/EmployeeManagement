using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagememt.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [BindProperty]
        public Employee employee { get; set; } 

       
        public IActionResult  OnGet(int id)
        {
           employee=  employeeRepository.GetEmployee(id);
            if(employee==null)
            {
                return RedirectToPage("/NotFound");

            }
            return Page();
            
        }
        public IActionResult OnPost()
        {
            Employee DeleteEmployee= employeeRepository.Delete(employee.Id);
            if(DeleteEmployee==null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Index");
        }
    }
}

using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagememt.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        //[BindProperty(SupportsGet = true)]
        [TempData]
        public string Message { get; set; }

        public Employee Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee= employeeRepository.GetEmployee(id);
            if(Employee==null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();

        }
    }
}

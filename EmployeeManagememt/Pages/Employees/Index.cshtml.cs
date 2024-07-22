using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagememt.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        public IEnumerable<Employee> Employees{ get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IndexModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        
        public void OnGet()
        {
            Employees = employeeRepository.Search(SearchTerm);
            //Employees = employeeRepository.GetallEmployees();
        }
    }
}

using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagememt.ViewComponents
{
    public class HeadCountViewComponent: ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;
        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        //Contagem de todos funcionários por departamento especifico com Component tagHelper
        public IViewComponentResult Invoke(Dept? departmentName= null)
        {
           var result= employeeRepository.EmployeeCountByDept(departmentName);
            return View(result);
        }

        //Contagem de todos funcionários por departamento especifico 
        //public IViewComponentResult Invoke(Dept? department = null)
        //{
        //    var result = employeeRepository.EmployeeCountByDept(department);
        //    return View(result);
        //}

        //Contagem de todos funcionários por departamento
        //public IViewComponentResult Invoke()
        //{
        //    var result = employeeRepository.EmployeeCountByDept();
        //    return View(result);
        //}
    }
}

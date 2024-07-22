using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchtearm);
        IEnumerable<Employee> GetallEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee UpdateEmployee);
        Employee Add(Employee NewEmployee);
        Employee Delete(int id);
        IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);
        //IEnumerable<DeptHeadCount> EmployeeCountByDept();
    }
}

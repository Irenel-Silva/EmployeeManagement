using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EmployeeManagement.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com", PhotoPath = "mary.png" },
                new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com", PhotoPath = "john.png" },
                new Employee() { Id = 3, Name = "Sara", Department = Dept.IT, Email = "sara@pragimtech.com", PhotoPath = "sara.png" },
                new Employee() { Id = 4, Name = "David", Department = Dept.Payroll, Email = "david@pragimtech.com" },  //,PhotoPath = "david.png"
            };
        }
        public IEnumerable<Employee> GetallEmployees()
        {
            return _employeeList;
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee UpdateEmployee)
        {
          Employee employee= _employeeList.FirstOrDefault(e => e.Id == UpdateEmployee.Id);
          if(employee!= null)
            {
                employee.Name = UpdateEmployee.Name;
                employee.Email = UpdateEmployee.Email;
                employee.Department = UpdateEmployee.Department;
                employee.PhotoPath = UpdateEmployee.PhotoPath;
            }
            return employee;
        }

        public Employee Add(Employee NewEmployee)
        {
            NewEmployee.Id = _employeeList.Max(e => e.Id)+1;
            _employeeList.Add(NewEmployee);
            return NewEmployee;
        }

        public Employee Delete(int id)
        {

            Employee employeeToDelete = _employeeList.FirstOrDefault(e => e.Id==id);
            if(employeeToDelete!=null)
            {
                _employeeList.Remove(employeeToDelete);
            }

            return employeeToDelete;

        }

        //Contagem de todos funcionários por departamento
        public IEnumerable<DeptHeadCount> EmployeeCountByDept()
        {
            return _employeeList.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();
        }

        //Contagem de todos funcionários por departamento especifico
        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {

            IEnumerable<Employee> query = _employeeList;
            if(dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();
        }

        public IEnumerable<Employee> Search(string searchtearm)
        {
            if (string.IsNullOrEmpty(searchtearm))
            {
                return _employeeList;
            }
            return _employeeList.Where(e => e.Name.Contains(searchtearm) || e.Email.Contains(searchtearm));
        }
    }
}

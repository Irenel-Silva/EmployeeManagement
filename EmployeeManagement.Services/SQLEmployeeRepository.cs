using EmployeeManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee NewEmployee)
        {
            context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}, {3}",
                NewEmployee.Name, NewEmployee.Email, NewEmployee.PhotoPath, NewEmployee.Department);
            //context.Employees.Add(NewEmployee);
            //context.SaveChanges();
            return NewEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee= context.Employees.Find(id);
            if(employee!=null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            // int TotalEmployees=context.Employees.Count();
            IEnumerable<Employee> query = context.Employees;
            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();
        }

        public IEnumerable<Employee> GetallEmployees()
        {
           return context.Employees.FromSqlRaw<Employee>("select * from Employees").ToList();
            //return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            return context.Employees.FromSqlRaw<Employee>("spGetEmployeeById @Id", parameter).ToList().FirstOrDefault();
            //return context.Employees.FromSqlRaw<Employee>("spGetEmployeeById {0}", id).ToList().FirstOrDefault();
            //return context.Employees.Find(id);

        }

        public IEnumerable<Employee> Search(string searchtearm)
        {
            if (string.IsNullOrEmpty(searchtearm))
            {
                return context.Employees;
            }
            return context.Employees.Where(e => e.Name.Contains(searchtearm) || e.Email.Contains(searchtearm));
        }

        public Employee Update(Employee UpdateEmployee)
        {
            var employee = context.Employees.Attach(UpdateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return UpdateEmployee;
        }
    }
}

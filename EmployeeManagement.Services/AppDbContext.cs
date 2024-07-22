using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) // DbContextOptions   DbContext<AppDbContext> options é umaopção que geraum erro no Base(options)
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

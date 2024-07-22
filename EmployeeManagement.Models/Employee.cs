using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public  class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Name is required"), MinLength(3, ErrorMessage = "Name Should contain at least 3 characters")]
        //[MinLength(3,ErrorMessage ="Name Should contain at least 3 chacacters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is required"), RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format"), Display(Name ="Office Email")]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }

        public string? PhotoPath { get; set; }
        [Required]
        public Dept? Department{ get; set; }

    }
}

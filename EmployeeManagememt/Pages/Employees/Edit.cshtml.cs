using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace EmployeeManagememt.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {

            this.employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Employee Employee{ get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }
        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Employee= employeeRepository.GetEmployee(id.Value);
            }
            else
            {
                Employee = new Employee();
            }
          
            if(Employee==null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if(ModelState.IsValid)
            {
                if(Photo!= null)
                {
                    if(Employee.PhotoPath!=null)
                    {
                        string FilePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Employee.PhotoPath);
                        System.IO.File.Delete(FilePath);
                    }

                    Employee.PhotoPath = ProcessUploadFile();
                }
                if(Employee.Id>0)
                {
                    Employee = employeeRepository.Update(Employee);
                }
                else
                {
                    Employee = employeeRepository.Add(Employee);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }

       //public void OnPostUpdateNotificationPreferences(int id)
        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if(Notify==true)
            {
                Message = "Thank you for Turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            //Employee= employeeRepository.GetEmployee(id);
            TempData["message"] = Message;  // Store in TempData
            return RedirectToPage("Details", new { id = id});
            //return RedirectToPage("Details", new { id = id, message = Message });
        }
        private string ProcessUploadFile()
        {
            string uniqueFilename = null;
            if(Photo!=null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string FilePath = Path.Combine(uploadsFolder, uniqueFilename);
                using (var fileStream= new FileStream(FilePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFilename;
        }

    }
}

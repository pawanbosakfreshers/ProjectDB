using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectDB.Pages.Students
{
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Student_Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Student_Name { get; set; }

        [BindProperty]
        [Display(Name = "Gender")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Gender { get; set; }

        [BindProperty]
        [Display(Name = "MobileNumber")]
        [Required]
       
        public string MobileNumber { get; set; }
        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }
      

        public AddModel()
        {
            Student_Name = "";
            Gender = "";
            MobileNumber = "";
            SuccessMessage = "";
            ErrorMessage = "";
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please try again";
                return;
            }
            var departmentData = new StudentDataAccess();

            var newStudent1 = new StudentDataModel { Student_Name = Student_Name, Gender = Gender, MobileNumber = MobileNumber };
            var insertedDepartment = departmentData.Insert(newStudent1);

            if ((insertedDepartment != null) && (insertedDepartment.Student_Id > 0))
            {
                SuccessMessage = $"Successfully Inserted Student1 {insertedDepartment.Student_Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Error! Add failed. Please try again";
            }

        }
    }
}
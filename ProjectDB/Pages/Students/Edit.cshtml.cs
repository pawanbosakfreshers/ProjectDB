

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectDB;
//using TrainingCRUDWebApp.DataAccess;
//using TrainingCRUDWebApp.Models;

namespace ProjectDB.Pages.Students
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        [Display(Name = "Student_Name")]
        [Required]
        [MinLength(3)]
        public string Student_Name { get; set; }

        [BindProperty]
        [Display(Name = "Gender")]
        [Required]
        [MinLength(3)]
        public string Gender { get; set; }
        [BindProperty]
        [Display(Name ="MobileNumber")]
        public string MobileNumber { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet(int id)
        {
            Id = id;
            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }
            var departmentData = new StudentDataAccess();
            var dept = departmentData.GetStudentById(id);
            if (dept != null)
            {
                Student_Name = dept.Student_Name;
                Gender = dept.Gender;
                MobileNumber = dept.MobileNumber;
            }
            else
            {

                ErrorMessage = "No Records found with Id";
            }
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid data. Please Try Again";
                return;
            }
            //update
            var departmentData = new StudentDataAccess();
            var depToUpdate = new StudentDataModel { Student_Id = Id, Student_Name = Student_Name, Gender = Gender,MobileNumber=MobileNumber };
            var updStudent = departmentData.Update(depToUpdate);

            //check result
            if (updStudent != null)
            {
                SuccessMessage = $"Student{updStudent.Student_Id} updated Successfully";

            }
            else
            {
                ErrorMessage = $"Error..!!!  Updating Student.";
            }
        }
    }
}
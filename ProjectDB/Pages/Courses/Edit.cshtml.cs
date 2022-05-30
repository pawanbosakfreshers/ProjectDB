

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectDB;
//using TrainingCRUDWebApp.DataAccess;
//using TrainingCRUDWebApp.Models;

namespace ProjectDB.Pages.Courses
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        [Display(Name = "Course_Name")]
        [Required]
        [MinLength(3)]
        public string Course_Name { get; set; }

        
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
            var departmentData = new CourseDataAccess();
            var dept = departmentData.GetCourseById(id);
            if (dept != null)
            {
                Course_Name = dept.Course_Name;
               
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
            var departmentData = new CourseDataAccess();
            var depToUpdate = new CourseDataModel { Course_id = Id, Course_Name = Course_Name,};
            var updCourse = departmentData.Update(depToUpdate);

            //check result
            if (updCourse != null)
            {
                SuccessMessage = $"Course{updCourse.Course_id} updated Successfully";

            }
            else
            {
                ErrorMessage = $"Error..!!!  Updating Student.";
            }
        }
    }
}
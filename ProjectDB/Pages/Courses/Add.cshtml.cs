using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectDB.Pages.Course
{
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Course_Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Course_Name { get; set; }

      
        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }


        public AddModel()
        {
            Course_Name = "";
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
            var departmentData = new CourseDataAccess();

            var newCourse = new CourseDataModel { Course_Name=Course_Name};
            var insertedCourse = departmentData.Insert(newCourse);

            if ((insertedCourse != null) && (insertedCourse.Course_id > 0))
            {
                SuccessMessage = $"Successfully Inserted Course {insertedCourse.Course_id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Error! Add failed. Please try again";
            }

        }
    }
}
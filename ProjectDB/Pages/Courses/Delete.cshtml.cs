using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ProjectDB.Pages.Course
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public bool ShowButton { get; set; }

        public string Course_Name { get; set; }
        
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public DeleteModel()
        {

            Course_Name = "";
           
            SuccessMessage = "";
            ErrorMessage = "";
            ShowButton = true;
        }

        public void OnGet(int id)
        {
            Id = id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var departmentData = new CourseDataAccess();
            var dept = departmentData.GetCourseById(Id);

            if (dept != null)
            {
                Course_Name = dept.Course_Name;
            }
            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

            var departmentData = new CourseDataAccess();
            var numOfRows = departmentData.Delete(Id);
            if (numOfRows >= 0)
            {
                SuccessMessage = $"Course {Id} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete Course {Id}";
            }
        }
    }
}
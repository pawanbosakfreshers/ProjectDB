using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectDB;


namespace ProjectDB.Pages.Courses
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public List<CourseDataModel> Courses { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Courses = new List<CourseDataModel>();
        }

        public void OnGet()
        {

            var departmentData = new CourseDataAccess();
            Courses = departmentData.GetAll();

        }
        public void OnPostSearch()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = $"Invalid data";
                return;
            }
            if (string.IsNullOrEmpty(SearchText) && (SearchText.Length < 3))
            {
                ErrorMessage = "please input more than 3 character";
                return;
            }
            CourseDataAccess departmentData = new CourseDataAccess();
            Courses = departmentData.GetCoursesByName(SearchText, SearchText);
            if (Courses != null)
            {

                SuccessMessage = "search successful";
                ErrorMessage = "";
                return;
            }
            else
            {
                ErrorMessage = "No Course found";
                SuccessMessage = "";
                return;
            }





        }
        public void OnPostClear()
        {
            SearchText = "";
            ModelState.Clear();
            OnGet();
        }
    }
}


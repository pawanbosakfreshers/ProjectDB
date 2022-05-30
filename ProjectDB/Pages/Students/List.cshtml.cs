using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectDB;


namespace ProjectDB.Pages.Students
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public List<StudentDataModel> Students { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Students = new List<StudentDataModel>();
        }

        public void OnGet()
        {

            var departmentData = new StudentDataAccess();
            Students = departmentData.GetAll();

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
            StudentDataAccess departmentData = new StudentDataAccess();
            Students = departmentData.GetStudentsByName(SearchText, SearchText);
            if (Students != null)
            {

                SuccessMessage = "search successful";
                ErrorMessage = "";
                return;
            }
            else
            {
                ErrorMessage = "No Student1 found";
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


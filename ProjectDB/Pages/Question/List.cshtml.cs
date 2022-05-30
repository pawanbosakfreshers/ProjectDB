using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectDB;


namespace ProjectDB.Pages.Question
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public List<QuestionDataModel> Questions { get; set; }

        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            Questions = new List<QuestionDataModel>();
        }

        public void OnGet()
        {

            var departmentData = new QuestionDataAccess();
            Questions = departmentData.GetAll();

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
           
            if (Questions!= null)
            {

                SuccessMessage = "search successful";
                ErrorMessage = "";
                return;
            }
            else
            {
                ErrorMessage = "No Question found";
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


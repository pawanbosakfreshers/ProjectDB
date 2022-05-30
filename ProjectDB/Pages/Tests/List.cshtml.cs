using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectDB.DataAccess;
using ProjectDB.Model;

namespace ProjectDB.Pages.Tests
{
    public class ListModel : PageModel
    {
        [BindProperty]
        public string SearchText { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public List<QuestionDataModel> Tests { get; set; }



        public void OnGet()
        {

            var questionData = new QuestionDataAccess();
            Tests = questionData.GetAll();

        }
        public void OnPostSearch()
        {
            //        if (!ModelState.IsValid)
            //        {
            //            ErrorMessage = $"Invalid data";
            //            return;
            //        }
            //        if (string.IsNullOrEmpty(SearchText) && (SearchText.Length < 3))
            //        {
            //            ErrorMessage = "please input more than 3 character";
            //            return;
            //        }
            //        TestDataAccess departmentData = new TestDataAccess();
            //        Tests = departmentData.GetTestsByName(SearchText, SearchText);
            //        if (Tests != null)
            //        {

            //            SuccessMessage = "search successful";
            //            ErrorMessage = "";
            //            return;
            //        }
            //        else
            //        {
            //            ErrorMessage = "No Test found";
            //            SuccessMessage = "";
            //            return;
            //        }





            //    }
            //    public void OnPostClear()
            //    {
            //        SearchText = "";
            //        ModelState.Clear();
            //        OnGet();
            //    }
        }
    }
}


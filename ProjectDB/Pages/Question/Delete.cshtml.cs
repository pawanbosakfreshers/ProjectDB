using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ProjectDB.Pages.Question
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public bool ShowButton { get; set; }

        public string Questions { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public DeleteModel()
        {

            Questions = "";
            Option1 = "";
            Option2 = "";
            Option3 = "";
            Option4 = "";
            CorrectAnswer = "";
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

            var departmentData = new QuestionDataAccess();
            var dept = departmentData.GetQuestionById(Id);

            if (dept != null)
            {
                Questions = dept.Questions;
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

            var departmentData = new QuestionDataAccess();
            var numOfRows = departmentData.Delete(Id);
            if (numOfRows >= 0)
            {
                SuccessMessage = $"Question {Id} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete Question {Id}";
            }
        }
    }
}
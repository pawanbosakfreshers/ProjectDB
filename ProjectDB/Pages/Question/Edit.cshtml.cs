

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectDB;


namespace ProjectDB.Pages.Question
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        [Display(Name = "Questions")]
        [Required]
        [MinLength(3)]
        public string Questions { get; set; }

        [BindProperty]
        [Display(Name = "Option1")]
        [Required]
        [MinLength(3)]
        public string Option1 { get; set; }
        [BindProperty]
        [Display(Name = "Option2")]
        [Required]
        [MinLength(3)]
        public string Option2 { get; set; }
        [BindProperty]
        [Display(Name = "Option3")]
        [Required]
        [MinLength(3)]
        public string Option3 { get; set; }
        [BindProperty]
        [Display(Name = "Option4")]
        [Required]
        [MinLength(3)]
        public string Option4 { get; set; }
        [BindProperty]
        [Display(Name = "CorrectAnswer")]
        [Required]
        [MinLength(3)]
        public string CorrectAnswer { get; set; }

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
            var departmentData = new QuestionDataAccess();
            var dept = departmentData.GetQuestionById(id);
            if (dept != null)
            {
                Questions = dept.Questions;
                Option1 = dept.Option1;
                Option1 = dept.Option2;
                Option1 = dept.Option3;
                Option1 = dept.Option4;
                CorrectAnswer = dept.CorrectAnswer;
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
            var departmentData = new QuestionDataAccess();
            var depToUpdate = new QuestionDataModel { Id = Id, Questions = Questions, Option1 = Option1, Option2 = Option2 , Option3 = Option3, Option4= Option4,CorrectAnswer= CorrectAnswer };
            var updQuestion = departmentData.Update(depToUpdate);

            //check result
            if (updQuestion != null)
            {
                SuccessMessage = $"Question{updQuestion.Id} updated Successfully";

            }
            else
            {
                ErrorMessage = $"Error..!!!  Updating Question.";
            }
        }
    }
}
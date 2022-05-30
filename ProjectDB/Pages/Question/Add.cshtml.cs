using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjectDB.Pages.Question
{
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Questions")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Questions { get; set; }

        [BindProperty]
        [Display(Name = "CorrectAnswer")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string CorrectAnswer { get; set; }

        [BindProperty]
        [Display(Name = "Option1")]
        [Required]

        public string Option1 { get; set; }
        [BindProperty]
        [Display(Name = "Option2")]
        [Required]

        public string Option2 { get; set; }
        [BindProperty]
        [Display(Name = "Option3")]
        [Required]

        public string Option3 { get; set; }
        [BindProperty]
        [Display(Name = "Option4")]
        [Required]

        public string Option4 { get; set; }
        //[BindProperty]
        //[Display(Name = "Course_Id")]
        //[Required]

        public int Course_Id { get; set; }
        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }


        public AddModel()
        {
            Questions = "";
            CorrectAnswer = "";
            Course_Id = -1;
            Option1 = "";
            Option2 = "";
            Option3 = "";
            Option4 = "";
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
            var departmentData = new QuestionDataAccess();

            var newQuestion = new QuestionDataModel {Questions = Questions, CorrectAnswer = CorrectAnswer, Option1 = Option1, Option2 = Option2, Option3 = Option3, Option4 = Option4 };
            var insertedQuestion = departmentData.Insert(newQuestion);

            if ((insertedQuestion != null) && (insertedQuestion.Id > 0))
            {
                SuccessMessage = $"Successfully Inserted Question {insertedQuestion.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Error! Add failed. Please try again";
            }

        }
    }
}
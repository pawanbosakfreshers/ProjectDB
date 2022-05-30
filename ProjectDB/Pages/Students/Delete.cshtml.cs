using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ProjectDB.Pages.Students
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public bool ShowButton { get; set; }

        public string Student_Name { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public DeleteModel()
        {
           
            Student_Name = "";
            Gender = "";
            MobileNumber = "";
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

            var departmentData = new StudentDataAccess();
            var dept = departmentData.GetStudentById(Id);

            if (dept != null)
            {
                Student_Name = dept.Student_Name;
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

            var departmentData = new StudentDataAccess();
            var numOfRows = departmentData.Delete(Id);
            if (numOfRows >= 0)
            {
                SuccessMessage = $"Student {Id} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete Student {Id}";
            }
        }
    }
}
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectDB.Pages.DataAccess;
using ProjectDB.Pages.Models;

namespace ProjectDB.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DashboardDataModel Dashboard { get; set; }
        [FromQuery(Name = "action")]
        public string Action { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }



        public void OnGet()
        {
            DashboardDataModel dashboard = new DashboardDataModel();
            if (!String.IsNullOrEmpty(Action) && Action.ToLower() == "logout")
            {
                Logout();
                return;
            }

            var d = new DashboardDataAccess();
            Dashboard = d.GetAll();



        }



        public void OnPost()

        {
            Logout();
        }

        private void Logout()
        {
            HttpContext.SignOutAsync();
            Response.Redirect("/Index");
        }






    }


}


using ProjectDB;
using ProjectDB.Pages.Models;
using System.Data.SqlClient;

namespace ProjectDB.Pages.DataAccess
{
    public class DashboardDataAccess
    {

        public string ErrorMessage { get; set; }
        public int Questions { get; set; }
        public int Course_id { get; set; }
        public int Student_Id { get; set; }


        public DashboardDataAccess()
        {
            ErrorMessage = "";
        }

        public DashboardDataModel GetAll()
        {
            try
            {

                var db = new DashboardDataModel();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "select count(*) as Question_Id from Question; select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))

                    {
                        db.Questions = Convert.ToInt32(cmd.ExecuteScalar());


                    }

                    sqlStmt = "select count(*) as NoOfCourse from Course";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.Course_id= Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    sqlStmt = "select count(*) as NoOfStudents from Student";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.Student_Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                }





                return db;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





    }
}
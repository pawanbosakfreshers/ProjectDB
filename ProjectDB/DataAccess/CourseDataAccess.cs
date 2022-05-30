
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB
{
    public class CourseDataAccess
    {
        public string ErrorMessage { get; private set; }

        //Get all Departments
        public List<CourseDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<CourseDataModel> departments = new List<CourseDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Course_id,Course_Name from dbo.Course";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                CourseDataModel department = new CourseDataModel();

                                department.Course_id = reader.GetInt32(0);
                                department.Course_Name = reader.GetString(1);
                             


                                departments.Add(department);
                            }
                        }
                    }
                }

                return departments;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        internal List<CourseDataModel> GetCoursesByName(string searchText1, string searchText2)
        {
            throw new NotImplementedException();
        }


        //Get Department By Id
        public CourseDataModel GetCourseById(int id)
        {

            try
            {
                CourseDataModel department = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select  Course_id ,Course_Name from Course where Course_id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                department = new CourseDataModel();
                                department.Course_id = reader.GetInt32(0);
                                department.Course_Name = reader.GetString(1);
                            }
                        }
                    }
                }

                return department;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        public List<CourseDataModel> GetCoursesByName(string Course_Name)
        {
            try
            {
                List<CourseDataModel> departments = new List<CourseDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Course_id, Course_Name from Course where Course_Name like '%{Course_Name}%'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                CourseDataModel department = new CourseDataModel();
                                department.Course_id = reader.GetInt32(0);
                                department.Course_Name = reader.GetString(1);
                                departments.Add(department);
                            }
                        }
                    }
                }

                return departments;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
        //Insert new Departmen
        public CourseDataModel Insert(CourseDataModel newCourse)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Course (Course_Name) VALUES ('{newCourse.Course_Name}') SELECT SCOPE_IDENTITY()";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newCourse.Course_id = idInserted;
                            return newCourse;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return null;
            }
        }

        //Update Department
        public CourseDataModel Update(CourseDataModel updCourse)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Course SET Course_Name = '{updCourse.Course_Name}'  " +
                       
                        $"where Course_id = {updCourse.Course_id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updCourse;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return null;
        }

        //Delete Department
        public int Delete(int id)
        {
            try
            {
                ErrorMessage = String.Empty;
                int numOfRows = 0;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM dbo.Course Where Course_id = {id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        numOfRows = cmd.ExecuteNonQuery();
                    }
                }
                return numOfRows;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return 0;
            }
        }
    }
}
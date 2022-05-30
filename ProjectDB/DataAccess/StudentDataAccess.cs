
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB
{
    public class StudentDataAccess
    {
        public string ErrorMessage { get; private set; }

        //Get all Departments
        public List<StudentDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<StudentDataModel> departments = new List<StudentDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Student_Id,Student_Name,Gender,MobileNumber from dbo.Student";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                StudentDataModel department = new StudentDataModel();
                              
                                department.Student_Id = reader.GetInt32(0);
                                department.Student_Name = reader.GetString(1);
                                department.Gender = reader.GetString(2);
                                department.MobileNumber = reader.GetString(3);


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

        internal List<StudentDataModel> GetStudentsByName(string searchText1, string searchText2)
        {
            throw new NotImplementedException();
        }


        //Get Department By Id
        public StudentDataModel GetStudentById(int id)
        {

            try
            {
                StudentDataModel department = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select  Student_Id ,Student_Name, Gender,MobileNumber from Student where Student_Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                department = new StudentDataModel();
                                department.Student_Id = reader.GetInt32(0);
                                department.Student_Name = reader.GetString(1);
                                department.Gender = reader.GetString(2);
                                department.MobileNumber = reader.GetString(3);
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

        public List<StudentDataModel> GetStudentsByName(string Student_Name, string Gender,string MobileNumber)
        {
            try
            {
                List<StudentDataModel> departments = new List<StudentDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Student_Id, Student_Name, Gender,MobileNumber from Student where Student_Name like '%{Student_Name}%' OR MobileNumber like '%{MobileNumber}%' OR Geder like '%{Gender}%'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                StudentDataModel department = new StudentDataModel();
                                department.Student_Id = reader.GetInt32(0);
                                department.Student_Name = reader.GetString(1);
                                department.Gender = reader.GetString(2);
                                department.MobileNumber = reader.GetString(3);
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
        //Insert new Department
        public StudentDataModel Insert(StudentDataModel newStudent)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Student (Student_Name, Gender,MobileNumber) VALUES ('{newStudent.Student_Name}', '{newStudent.Gender}' , '{newStudent.MobileNumber}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newStudent.Student_Id = idInserted;
                            return newStudent;
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
        public StudentDataModel Update(StudentDataModel updStudent)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Student SET Student_Name = '{updStudent.Student_Name}', " +
                        $"Gender = '{updStudent.Gender}', " +
                          $"MobileNumber = '{updStudent.MobileNumber}' " +
                        $"where Student_Id = {updStudent.Student_Id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updStudent;
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
                    string sqlStmt = $"DELETE FROM dbo.Student Where Student_Id = {id}";

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
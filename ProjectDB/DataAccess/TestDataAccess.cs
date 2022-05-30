using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDB.Model;

namespace ProjectDB.DataAccess
{
    public class TestDataAccess
    {
        public string ErrorMessage { get; set; }
        public string Std_Name { get; set; }

        //Get all Departments
        public List<TestDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<TestDataModel> departments = new List<TestDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Std_Id,Std_Name from dbo.Test";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                TestDataModel department = new TestDataModel();

                                department.Std_Id = reader.GetInt32(0);
                                department.Std_Name = reader.GetString(1);



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

        internal List<TestDataModel> GetTestsByName(string searchText1, string searchText2)
        {
            throw new NotImplementedException();
        }


        //Get Department By Id
        public TestDataModel GetTestById(int id)
        {

            try
            {
                TestDataModel department = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Std_Id,Std_Name from Test where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                department = new TestDataModel();
                                department.Std_Id = reader.GetInt32(0);
                                department.Std_Name = reader.GetString(1);
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

        public List<TestDataModel> GetTestsByName(string Course_Name)
        {
            try
            {
                List<TestDataModel> departments = new List<TestDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Std_Id, Std_Name from Test where Std_Name like '%{Std_Name}%'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                TestDataModel department = new TestDataModel();
                                department.Std_Id = reader.GetInt32(0);
                                department.Std_Name = reader.GetString(1);
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
        public TestDataModel Insert(TestDataModel newTest)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = string.Empty;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Test (Std_Name) VALUES ('{newTest.Std_Name}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newTest.Std_Id = idInserted;
                            return newTest;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        //Update Department
        public TestDataModel Update(TestDataModel updTest)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Test SET Std_Name = '{updTest.Std_Name}', " +

                        $"where id = {updTest.Std_Id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updTest;
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
                ErrorMessage = string.Empty;
                int numOfRows = 0;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM dbo.Test Where Std_Id = {id}";

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

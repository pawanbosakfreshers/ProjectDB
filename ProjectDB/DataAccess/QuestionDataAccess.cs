using System.Data.SqlClient;

namespace ProjectDB
{
    public class QuestionDataAccess
    {
        public string ErrorMessage { get; private set; }

        //Get all Departments
        public List<QuestionDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<QuestionDataModel> departments = new List<QuestionDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Questions,Option1,Option2,Option3,Option4,CorrectAnswer from dbo.Question";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                QuestionDataModel department = new QuestionDataModel();

                                
                                department.Questions = reader.GetString(0);
                                department.Option1 = reader.GetString(1);
                                department.Option2 = reader.GetString(2);
                                department.Option3 = reader.GetString(3);
                                department.Option4 = reader.GetString(4);
                                department.CorrectAnswer = reader.GetString(5);


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

      

        //Get Department By Id
        public QuestionDataModel GetQuestionById(int id)
        {

            try
            {
                QuestionDataModel department = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select  Question_Id ,Course_Id, Questions,Option1,Option2,Option3,Option4,CorrectAnswer from Question where Question_Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                department = new QuestionDataModel();
                                department.Id = reader.GetInt32(0);
                                department.Course_Id = reader.GetInt32(1);
                                department.Questions = reader.GetString(2);
                                department.Option1 = reader.GetString(3);
                                department.Option2 = reader.GetString(4);
                                department.Option3 = reader.GetString(5);
                                department.Option4 = reader.GetString(6);
                                department.CorrectAnswer = reader.GetString(7);
                          ;
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

        //Insert new Department
        public QuestionDataModel Insert(QuestionDataModel newQuestion)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.Question (Questions,Option1,Option2,Option3,Option4,CorrectAnswer ) VALUES ('{newQuestion.Questions}', '{newQuestion.Option1}' , '{newQuestion.Option2}' , '{newQuestion.Option3}' , '{newQuestion.Option4}' , '{newQuestion.CorrectAnswer}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newQuestion.Id = idInserted;
                            return newQuestion;
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
        public QuestionDataModel Update(QuestionDataModel updQuestion)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.Question SET Questions Name = '{updQuestion.Questions}', " +
                        $"Option1 = '{updQuestion.Option1}' " +
                        $"Option2 = '{updQuestion.Option2}' " +
                          $"Option3 = '{updQuestion.Option3}' " +
                            $"Option4 = '{updQuestion.Option4}' " +
                          $"CorrectAnswer = '{updQuestion.CorrectAnswer}' " +
                        $"where Question_Id = {updQuestion.Id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updQuestion;
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
                    string sqlStmt = $"DELETE FROM dbo.Question Where Question_Id = {id}";

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
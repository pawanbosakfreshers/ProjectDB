using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB
{
    public class QuestionDataModel
    {
        public int Id { get; set; }
        public int Course_Id { get; set; }

        public string Questions { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }
      

        //Constructor
        public QuestionDataModel()
        {
            Id = -1;
            Course_Id = -1;
            Questions = "";
            Option1 = "";
            Option2 = "";
            Option3 = "";
            Option4 = "";
            CorrectAnswer = "";
        }

        public bool IsValid()
        {
            //if (Id <= 0)
            //{
            //    return false;
            //}

            if (Questions == null || Questions.Trim() == "" || Questions.Trim().Length < 20)
            {
                return false;
            }



            if (CorrectAnswer == null || CorrectAnswer.Trim().Length == 0 || CorrectAnswer.Trim().Length <= 3)
            {
                return false;
            }


            return true;
        }

        internal static SqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB
{
    public class StudentDataModel
    {
        public int Student_Id { get; set; }

        public string Student_Name { get; set; }

        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string CorrectAnswer { get; internal set; }
        public string Questions { get; internal set; }
        public int Question_Id { get; internal set; }
        public string Option1 { get; internal set; }
        public string Option2 { get; internal set; }
        public string Option3 { get; internal set; }
        public string Option4 { get; internal set; }

        //Constructor
        public StudentDataModel()
        {
            Student_Id = -1;
            Student_Name = "";
            Gender = "";
            MobileNumber = "";
        }

        public bool IsValid()
        {
            //if (Id <= 0)
            //{
            //    return false;
            //}

            if (Student_Name == null || Student_Name.Trim() == "" || Student_Name.Trim().Length > 20)
            {
                return false;
            }

            
            
            if (Gender == null || Gender.Trim().Length == 0 || Gender.Trim().Length <= 3)
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
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB
{
    public class CourseDataModel
    {
        public int Course_id { get; set; }

        public string Course_Name { get; set; }

       
        //Constructor
        public CourseDataModel()
        {
            Course_id = -1;
            Course_Name = "";
          
        }

        public bool IsValid()
        {
            //if (Id <= 0)
            //{
            //    return false;
            //}

            if (Course_Name == null || Course_Name.Trim() == "" || Course_Name.Trim().Length <20)
            {
                return false;
            }



         


            return true;
        }

        
    }
}
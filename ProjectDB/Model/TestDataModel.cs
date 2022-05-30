using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB.Model
{
    public class TestDataModel
    {
        public int Std_Id { get; set; }

        public string Std_Name { get; set; }


        //Constructor
        public TestDataModel()
        {
            Std_Id = -1;
            Std_Name = "";

        }

        public bool IsValid()
        {
            //if (Id <= 0)
            //{
            //    return false;
            //}

            if (Std_Name == null || Std_Name.Trim() == "" || Std_Name.Trim().Length < 20)
            {
                return false;
            }






            return true;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROG2_Livestock
{
    public class LoginClass
    {
        public string userName;
        public string passWord;
        public int loginType;
        public int doNext;

        public void LoginUser()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True");
            con.Open();

            //Checking that the username and password entered match the ones in the database
            if (passWord != string.Empty & userName != string.Empty & loginType != -1)
            {
                //Checking whether the user logging in is an employee or a farmer
                switch (loginType)
                {
                    case 0:
                        SqlCommand cmd = new SqlCommand("select * from Employees where Username='" + userName + "' and Password='" + hashClass.hashPassword(passWord) + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Global.loggedUser = userName;
                            doNext = 1;                     
                        }
                        else
                        {
                            dr.Close();
                            doNext = 2;
                        }
                        break;
                    case 1:
                        SqlCommand cmd2 = new SqlCommand("select * from Farmers where Username='" + userName + "' and Password='" + hashClass.hashPassword(passWord) + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Global.loggedUser = userName;
                            doNext = 3;
                        }
                        else
                        {
                            dr2.Close();
                            doNext = 2;
                        }
                        break;
                }
            }
            else
            {
                doNext = 4;
            }

        }
    }

    
}
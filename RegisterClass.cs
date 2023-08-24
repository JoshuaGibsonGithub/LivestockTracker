using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROG2_Livestock
{
    public class RegisterClass
    {
        public string userName;
        public string passWord;
        public int userType;
        public int doNext;

        public void RegisterUser()
        {
            if (passWord != string.Empty & userName != string.Empty & userType != -1)
            {
                //SQL connection to database
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True");
                con.Open();
                switch (userType)
                {
                    case 0:
                        SqlCommand cmd = new SqlCommand("select * from Employees where Username='" + userName + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Close();
                        //Inserting values from text box into database
                        cmd = new SqlCommand("insert into Employees values(@Username,@Password)", con);
                        cmd.Parameters.AddWithValue("@Username", userName);
                        //hashing password
                        cmd.Parameters.AddWithValue("@Password", hashClass.hashPassword(passWord.Trim()));
                        cmd.ExecuteNonQuery();
                        doNext = 1;
                        break;
                    case 1:
                        SqlCommand cmd2 = new SqlCommand("select * from Farmers where Username='" + userName + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        dr2.Close();
                        //Inserting values from text box into database
                        cmd = new SqlCommand("insert into Farmers values(@Username,@Password)", con);
                        cmd.Parameters.AddWithValue("@Username", userName);
                        //hashing password
                        cmd.Parameters.AddWithValue("@Password", hashClass.hashPassword(passWord.Trim()));
                        cmd.ExecuteNonQuery();
                        doNext = 2;
                        break;
                }
            }
            else
            {
                doNext = 3;
            }
        }
    }
}
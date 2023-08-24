using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG2_Livestock
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        public void RegisterUser()
        {
            if (txtPassword.Text != string.Empty & txtUsername.Text != string.Empty & rbType.SelectedItem != null)
            {

                string userName = txtUsername.Text.Trim();
                string Password = txtPassword.Text.Trim();
                int Type = rbType.SelectedIndex;
                //SQL connection to database
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True");
                con.Open();
                switch (Type)
                {
                    case 0:
                        SqlCommand cmd = new SqlCommand("select * from Employees where Username='" + userName + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Close();
                        //Inserting values from text box into database
                        cmd = new SqlCommand("insert into Employees values(@Username,@Password)", con);
                        cmd.Parameters.AddWithValue("@Username", userName);
                        //hashing password
                        cmd.Parameters.AddWithValue("@Password", hashClass.hashPassword(Password.Trim()));
                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('New employee registered');</script>");
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        rbType.ClearSelection();
                        break;
                    case 1:
                        SqlCommand cmd2 = new SqlCommand("select * from Farmers where Username='" + userName + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        dr2.Close();
                        //Inserting values from text box into database
                        cmd = new SqlCommand("insert into Farmers values(@Username,@Password)", con);
                        cmd.Parameters.AddWithValue("@Username", userName);
                        //hashing password
                        cmd.Parameters.AddWithValue("@Password", hashClass.hashPassword(Password.Trim()));
                        cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('New farmer registered');</script>");
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        rbType.ClearSelection();
                        break;
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter values in all the fields');</script>");
            }
        }

        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
    }
}

//-------------------------------------------------------------------END OF PAGE-------------------------------------------------------------------------------------------------
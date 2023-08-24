using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG2_Livestock
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoginUser()
        {
            string userName = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();
            int Type = rbType.SelectedIndex;
            //SQL connection to database
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True");
            con.Open();

            //Checking that the username and password entered match the ones in the database
            if (txtPassword.Text != string.Empty & txtUsername.Text != string.Empty & rbType.SelectedItem != null)
            {
                //Checking whether the user logging in is an employee or a farmer
                switch (Type)
                {
                    case 0:
                        SqlCommand cmd = new SqlCommand("select * from Employees where Username='" + userName + "' and Password='" + hashClass.hashPassword(Password) + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Global.loggedUser = userName;
                            Response.Redirect("MainMenu.aspx");
                        }
                        else
                        {
                            dr.Close();
                            Response.Write("<script>alert('Invalid Login Details');</script>");
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            rbType.ClearSelection();
                        }
                        break;
                    case 1:
                        SqlCommand cmd2 = new SqlCommand("select * from Farmers where Username='" + userName + "' and Password='" + hashClass.hashPassword(Password) + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Global.loggedUser = userName;
                            Response.Redirect("FarmerProducts.aspx");
                        }
                        else
                        {
                            dr2.Close();
                            Response.Write("<script>alert('Invalid Login Details');</script>");
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            rbType.ClearSelection();
                        }
                        break;
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter values in all the fields');</script>");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }
    }
}

//------------------------------------------------------------------------------END OF PAGE------------------------------------------------------------------------------------
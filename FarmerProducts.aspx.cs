using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROG2_Livestock
{
    public partial class FarmerProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDataGrid();
            this.grdProducts.DataBind();
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Add();
            FillDataGrid();
        }

        //Adding user's data to the database
        public void Add()
        {
            string productName = txtProductName.Text.Trim();
            string productType = txtProductType.Text.Trim();
            DateTime currentDate = DateTime.Today;
            //SQL connection to database
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True");
            con.Open();
            string add_data = "INSERT INTO Products VALUES(@ProductName, @ProductType, @DateAdded, @Username)";
            SqlCommand cmd = new SqlCommand(add_data, con);
            //Adding values from the text boxes to the database
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@ProductType", productType);
            cmd.Parameters.AddWithValue("@DateAdded", currentDate);
            cmd.Parameters.AddWithValue("@Username", Global.loggedUser);
            cmd.ExecuteNonQuery();
            con.Close();
            FillDataGrid();
            this.grdProducts.DataBind();
        }

        //Filling data grid with data from the database
        public void FillDataGrid()
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True"))
            {
                //Only gets data from the current user
                CmdString = "SELECT ProductName, ProductType, DateAdded FROM Products WHERE Username = '" + Global.loggedUser + "'";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Products");
                sda.Fill(dt);
                grdProducts.DataSource = dt.DefaultView;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}

//------------------------------------------------------------------------------END OF PAGE------------------------------------------------------------------------------------
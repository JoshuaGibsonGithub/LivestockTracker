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
    public partial class EmployeeAdministration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

       

        //Fills the data grid with data from the database
        public void FillDataGrid()
        {
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True"))
            {
                CmdString = "SELECT ProductName, ProductType, DateAdded, Username FROM Products";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Products");
                sda.Fill(dt);
                grdDisplay.DataSource = dt.DefaultView;
                this.grdDisplay.DataBind();
            }
        }

      

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            FilterByProductType();
        }

        //Filters the data by the product type selected by the user
        public void FilterByProductType()
        {
            string CmdString = string.Empty;
            string selectedFarmer = txtFarmer.Text.Trim();
            string selectedProduct = txtProductType.Text.Trim();
            if (selectedFarmer != string.Empty & selectedProduct != string.Empty)
            {
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True"))
                {
                    CmdString = "SELECT ProductName, ProductType, DateAdded, Username FROM Products WHERE Username = '" + selectedFarmer + "' AND ProductType = '" + selectedProduct + "'";
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Products");
                    sda.Fill(dt);
                    grdDisplay.DataSource = dt.DefaultView;
                    this.grdDisplay.DataBind();
                }
            }
            else
            {
                Response.Write("<script>alert('Please ensure that the Farmer and Product Type fields are filled');</script>");
            }

            txtFarmer.Text = "";
            txtProductType.Text = "";
        }

        //Filters the data by the dates chosen by the user
        public void FilterByDate()
        {
            string CmdString = string.Empty;
            string selectedFarmer = txtFarmer.Text.Trim();
            DateTime fromDate = cldFrom.SelectedDate;
            DateTime toDate = cldTo.SelectedDate;
            if (selectedFarmer != string.Empty & fromDate != null & toDate != null)
            {
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True"))
                {
                    CmdString = "SELECT ProductName, ProductType, DateAdded, Username FROM Products WHERE Username = '" + selectedFarmer + "' AND DateAdded BETWEEN '" + fromDate + "' AND '" + toDate + "'";
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Products");
                    sda.Fill(dt);
                    grdDisplay.DataSource = dt.DefaultView;
                    this.grdDisplay.DataBind();
                }
            }
            else
            {
                Response.Write("<script>alert('Please ensure that the Farmer and Chosen Date fields are filled');</script>");
            }

            txtFarmer.Text = "";
            txtProductType.Text = "";
        }

        //Filters the data by the farmer chosen by the user
        public void FilterByFarmer()
        {
            string CmdString = string.Empty;
            string selectedFarmer = txtFarmer.Text.Trim();

            if (selectedFarmer != string.Empty)
            {
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ProgDB.mdf;Integrated Security=True"))
                {
                    CmdString = "SELECT ProductName, ProductType, DateAdded, Username FROM Products WHERE Username = '" + selectedFarmer + "'";
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Products");
                    sda.Fill(dt);
                    grdDisplay.DataSource = dt.DefaultView;
                    this.grdDisplay.DataBind();
                }
            }
            else
            {
                Response.Write("<script>alert('Please ensure that the Farmer field is filled');</script>");
            }

            txtFarmer.Text = "";
            txtProductType.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        protected void btnFilterDate_Click(object sender, EventArgs e)
        {
            FilterByDate();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void btnFilterFarmer_Click(object sender, EventArgs e)
        {
            FilterByFarmer();
        }
    }
}

//------------------------------------------------------------------------------END OF PAGE------------------------------------------------------------------------------------
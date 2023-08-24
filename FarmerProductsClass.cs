using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PROG2_Livestock
{
    public class FarmerProductsClass
    {
        public string productName;
        public string productType;
        public void Add()
        {
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
        }
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WP_Lab9
{
    public partial class Login : System.Web.UI.Page
    {

        string conn = @"Server=localhost;Database=usersdb;Uid=root;";

        protected void Page_Load(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                textPassword.Attributes["type"] = "password";
            }
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM user WHERE Username = '" + textUsername.Text.ToString() + "' AND password='" + textPassword.Text.ToString() + "'", sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.SelectCommand = sqlCmd;
                mySqlDataAdapter.Fill(dataSet, "user");
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    data.Text = "Data is corect, you may proced to next page!";
                    Response.Redirect("index.aspx");
                }
                else
                {
                    data.Text = "Incorrect username/password!";
                }
            }
        }
    }
}
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WP_Lab9
{
    public partial class index : System.Web.UI.Page
    {
        string conn = @"Server=localhost;Database=usersdb;Uid=root;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridFill();
            }
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(conn))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("AddOrEditUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_ID", Convert.ToInt32(hiddenfieldID.Value == "" ? "0" : hiddenfieldID.Value));
                    sqlCmd.Parameters.AddWithValue("_Name", textName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_Username", textUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_Age", Convert.ToInt32(textAge.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_Email", textEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_Webpage", textWebpage.Text.Trim());
                    sqlCmd.ExecuteNonQuery();

                    GridFill();
                    Clear();

                    labelSuccessMessage.Text = "Submitted Sucessfully!";
                }
            }
            catch (Exception ex)
            {
                labelErrorMessage.Text = ex.Message;
            }
            
        }

        void Clear()
        {
            hiddenfieldID.Value = "";
            textName.Text = textUsername.Text = textAge.Text = textEmail.Text = textWebpage.Text = "";
            buttonSave.Text = "Save";
            buttonDelete.Enabled = false;
            labelErrorMessage.Text = labelSuccessMessage.Text = "";
        }

        protected void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void GridFill()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("UsersViewAll", sqlCon);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                gvName.DataSource = dataTable;
                gvName.DataBind();
            }
        }

        protected void linkSelect_OnClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);

            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter("UsersViewByID", sqlCon);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("_ID", ID);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                textName.Text = dataTable.Rows[0][1].ToString();
                textUsername.Text = dataTable.Rows[0][2].ToString();
                textAge.Text = dataTable.Rows[0][4].ToString();
                textEmail.Text = dataTable.Rows[0][6].ToString();
                textWebpage.Text = dataTable.Rows[0][7].ToString();

                hiddenfieldID.Value = dataTable.Rows[0][0].ToString();

                buttonSave.Text = "Update";
                buttonDelete.Enabled = true;
            }
        }

        protected void buttonDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand("UsersDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("_ID", Convert.ToInt32(hiddenfieldID.Value == "" ? "0" : hiddenfieldID.Value));

                sqlCmd.ExecuteNonQuery();

                GridFill();
                Clear();

                labelSuccessMessage.Text = "Deleted Sucessfully!";
            }
        }

        protected void textSearch_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(conn))
            {
                sqlCon.Open();
                MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM user WHERE " + SearchList.Text.ToString() + " Like '" + textSearch.Text.ToString() + "%'", sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();
                

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCmd.CommandText, sqlCon);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                gvName.DataSource = dataTable;
                gvName.DataBind();

                Clear();

                ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "uniqueScript", "copyText()", true);

            }
        }

    }
}
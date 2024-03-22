using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class SignUp : System.Web.UI.Page
{
    Control connect = new Control();
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Panel pnlLogSign = (System.Web.UI.WebControls.Panel)Master.FindControl("pnlLogSign");
        System.Web.UI.WebControls.Panel pnlLogout = (System.Web.UI.WebControls.Panel)Master.FindControl("pnlLogout");

        if (Session["ID"] == null)
        {
            pnlLogSign.Visible = true;
            pnlLogout.Visible = false;
        }
        else
        {
            pnlLogout.Visible = true;
            pnlLogSign.Visible = false;
        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string address = txtAddress.Text;
        string phone = txtPhone.Text;
        string password = txtPassword.Text;
        int normalUser = 3;

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE [email]='" + email + "'";
        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            MessageBox.Show("There is an account with this e-mail address!");
            Response.Redirect("Login.aspx");
        }
        else
        {
            cmd2.CommandText = "INSERT INTO [dbo].[User]([name],[surname],[email],[address],[phone],[password],[userTypeID]) VALUES(@name,@surname,@email,@address,@phone,@password,@userTypeID)";
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@surname", surname);
            cmd2.Parameters.AddWithValue("@email", email);
            cmd2.Parameters.AddWithValue("@address", address);
            cmd2.Parameters.AddWithValue("@phone", phone);
            cmd2.Parameters.AddWithValue("@password", password);
            cmd2.Parameters.AddWithValue("@userTypeID", normalUser);

            cmd2.Connection = connect.connectToDB();

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Registration was successful.");
            Response.Redirect("Login.aspx");
        }

        connect.connectToDB().Close();
    }
}
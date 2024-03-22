using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class ForgotPassword : System.Web.UI.Page
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPasswordAgain.Text;

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE [email]='" + email + "'";
        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            cmd2.CommandText = "UPDATE [dbo].[User] SET [password]='" + password + "' WHERE [email]='" + email + "'";
            cmd2.Connection = connect.connectToDB();
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Password has been changed successfully.!");
            Response.Redirect("Login.aspx");
        }
        else
        {
            MessageBox.Show("There is no registration with this mail!");
        }
        connect.connectToDB().Close();
    }
}
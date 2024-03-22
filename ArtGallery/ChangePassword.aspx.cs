using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class ChangePassword : System.Web.UI.Page
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
            Response.Redirect("Login.aspx");
        }
        else
        {
            pnlLogout.Visible = true;
            pnlLogSign.Visible = false;
        }

        if (Session["ID"] != null)
        {
            string user = Request.QueryString["userC"];

            SqlCommand bring = new SqlCommand();
            SqlDataReader dr;

            bring.CommandText = "SELECT * FROM [dbo].[User] WHERE [userID]=" + user;
            bring.Connection = connect.connectToDB();
            dr = bring.ExecuteReader();
            dr.Read();

            txtEmail.Text = dr["email"].ToString();

            connect.connectToDB().Close();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlCommand change = new SqlCommand();
        string newPass = txtPasswordAgain.Text;
        string curPass = txtCurPassword.Text;
        string email = txtEmail.Text;
        string user = Request.QueryString["userC"];

        change.CommandText = "UPDATE [dbo].[User] SET [password]='" + newPass + "' WHERE [userID]='" + user + "' AND [email]='" + email + "' AND [password]='" + curPass + "'";
        change.Connection = connect.connectToDB();

        change.ExecuteNonQuery();
        connect.connectToDB().Close();

        MessageBox.Show("Password Changed!");

        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
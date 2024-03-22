using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class Login : System.Web.UI.Page
{
    Control connect = new Control();
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Panel pnlLogSign = (System.Web.UI.WebControls.Panel)Master.FindControl("pnlLogSign");
        System.Web.UI.WebControls.Panel pnlLogout = (System.Web.UI.WebControls.Panel)Master.FindControl("pnlLogout");

        if (!IsPostBack)
        {
            if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                txtEmail.Text = Request.Cookies["email"].Value;
                txtPassword.Text = Request.Cookies["password"].Value;
            }
        }

        if (Session["ID"] == null)
        {
            pnlLogSign.Visible = true;
            pnlLogout.Visible = false;
        }
        else
        {
            pnlLogout.Visible = true;
            pnlLogSign.Visible = false;
            Response.Redirect("Default.aspx");
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;


        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE email='" + email + "' AND password='" + password + "'";
        cmd.Connection = connect.connectToDB();


        if (chkRemember.Checked)
        {
            Response.Cookies["email"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["password"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
        }

        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Session.Add("ID", dr["userID"].ToString());
            Response.Redirect("Default.aspx");
        }
        else
        {
            MessageBox.Show("Wrong email or password");
        }

        connect.connectToDB().Close();
    }
}
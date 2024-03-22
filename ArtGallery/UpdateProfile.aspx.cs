using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

public partial class UpdateProfile : System.Web.UI.Page
{
    Control connect = new Control();
    string filePath;
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
            string user = Request.QueryString["user"];

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

    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string address = txtAddress.Text;
        string nationality = txtNationality.Text;
        string phone = txtPhone.Text;
        string password = txtPassword.Text;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Users/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand update = new SqlCommand();
        string user = Request.QueryString["user"];


        update.CommandText = "UPDATE [dbo].[User] " +
                    "SET [name]='" + name + "',[surname]='" + surname + "',[email]='" + email + "',[address]='" + address + "',[nationality]='" + nationality + "',[phone]='" + phone + "',[image]='" + filePath.ToString() + "' " +
                    "WHERE [userID]='" + user + "' AND [password]='" + password + "'";


        update.Connection = connect.connectToDB();
        update.ExecuteNonQuery();


        connect.connectToDB().Close();
        MessageBox.Show("Updated!");

        Response.Redirect("UserProfile.aspx");

    }
}
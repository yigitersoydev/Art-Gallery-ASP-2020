using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

public partial class UpdateArtistProfile : System.Web.UI.Page
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
            string artist = Request.QueryString["artist"];

            SqlCommand bring = new SqlCommand();
            SqlDataReader dr;

            bring.CommandText = "SELECT * FROM [dbo].[Artist] WHERE [artistID]=" + artist;
            bring.Connection = connect.connectToDB();
            dr = bring.ExecuteReader();
            dr.Read();

            txtEmail.Text = dr["email"].ToString();
            txtName.Text = dr["name"].ToString();
            txtSurname.Text = dr["surname"].ToString();
            txtNumber.Text = dr["number"].ToString();

            connect.connectToDB().Close();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnUpdateArtistProfile_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string address = txtAddress.Text;
        string nationality = txtNationality.Text;
        string password = txtPassword.Text;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Artists/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand update = new SqlCommand();
        string artist = Request.QueryString["artist"];


        update.CommandText = "UPDATE [dbo].[Artist] SET [address]='" + address + "',[nationality]='" + nationality + "',[image]='" + filePath.ToString() + "' FROM [dbo].[Artist] AS A INNER JOIN [dbo].[UserArtist] AS UA ON UA.artistID = A.artistID INNER JOIN [dbo].[User] AS U ON U.userID = UA.userID WHERE A.[artistID]='" + artist + "' AND U.[password]='" + password + "'";


        update.Connection = connect.connectToDB();
        update.ExecuteNonQuery();


        connect.connectToDB().Close();
        MessageBox.Show("Updated!");

        Response.Redirect("ArtistProfile.aspx");

    }
}
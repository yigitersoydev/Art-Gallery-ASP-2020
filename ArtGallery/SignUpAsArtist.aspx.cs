using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

public partial class SignUpAsArtist : System.Web.UI.Page
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
        string number = txtNumber.Text;
        string nationality = txtNationality.Text;
        string DOB = txtDOB.Text;
        string born = txtBorn.Text;
        int artist = 2;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Artists/";
        string upload2 = Request.PhysicalApplicationPath + "Images/Users/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            FileUpload1.SaveAs(upload2 + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlCommand cmd4 = new SqlCommand();
        SqlCommand cmd5 = new SqlCommand();
        SqlCommand cmd6 = new SqlCommand();
        SqlCommand cmd7 = new SqlCommand();
        SqlDataReader dr, dr2, dr3, dr4;
        cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE [email]='" + email + "'";
        cmd4.CommandText = "SELECT * FROM [dbo].[Artist] WHERE [number] = '" + number + "'";
        cmd.Connection = connect.connectToDB();
        cmd4.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        dr2 = cmd4.ExecuteReader();
        if (dr.HasRows || dr2.HasRows)
        {
            MessageBox.Show("There is an account with this e-mail address or number!");
            Response.Redirect("Login.aspx");
        }
        else
        {
            string path = Server.MapPath("/Files/artistNumbers.txt");
            StreamReader sr = new StreamReader(path);
            string artistNumber = sr.ReadLine();
            if (File.ReadAllLines(path).Contains(number))
            {
                cmd2.CommandText = "INSERT INTO [dbo].[User]([name],[surname],[email],[address],[phone],[password],[userTypeID],[nationality],[image]) VALUES(@name,@surname,@email,@address,@phone,@password,@userTypeID,@nationality,@image)";
                cmd2.Parameters.AddWithValue("@name", name);
                cmd2.Parameters.AddWithValue("@surname", surname);
                cmd2.Parameters.AddWithValue("@email", email);
                cmd2.Parameters.AddWithValue("@address", address);
                cmd2.Parameters.AddWithValue("@phone", phone);
                cmd2.Parameters.AddWithValue("@password", password);
                cmd2.Parameters.AddWithValue("@userTypeID", artist);
                cmd2.Parameters.AddWithValue("@nationality",nationality);
                cmd2.Parameters.AddWithValue("@image", filePath.ToString());

                cmd2.Connection = connect.connectToDB();
                cmd2.ExecuteNonQuery();

                cmd3.CommandText = "INSERT INTO [dbo].[Artist]([name],[surname],[email],[address],[number],[dateOfBirth],[bornLocation],[nationality],[image]) VALUES(@name,@surname,@email,@address,@number,@dateOfBirth,@bornLocation,@nationality,@image)";
                cmd3.Parameters.AddWithValue("@name", name);
                cmd3.Parameters.AddWithValue("@surname", surname);
                cmd3.Parameters.AddWithValue("@email", email);
                cmd3.Parameters.AddWithValue("@address", address);
                cmd3.Parameters.AddWithValue("@number", number);
                cmd3.Parameters.AddWithValue("@dateOfBirth", DOB);
                cmd3.Parameters.AddWithValue("@bornLocation", born);
                cmd3.Parameters.AddWithValue("@nationality", nationality);
                cmd3.Parameters.AddWithValue("@image", filePath.ToString());

                cmd3.Connection = connect.connectToDB();
                cmd3.ExecuteNonQuery();


                cmd5.CommandText = "SELECT TOP 1 [userID] FROM [dbo].[User] ORDER BY [userID] DESC";
                cmd5.Connection = connect.connectToDB();
                dr3 = cmd5.ExecuteReader();

                cmd6.CommandText = "SELECT TOP 1 [artistID] FROM [dbo].[Artist] ORDER BY [artistID] DESC";
                cmd6.Connection = connect.connectToDB();
                dr4 = cmd6.ExecuteReader();

                if (dr3.Read() && dr4.Read())
                {
                    cmd7.CommandText = "INSERT INTO [dbo].[UserArtist]([artistID],[userID]) VALUES(@artistID,@userID)";
                    cmd7.Parameters.AddWithValue("@userID", dr3["userID"].ToString());
                    cmd7.Parameters.AddWithValue("@artistID", dr4["artistID"].ToString());

                    cmd7.Connection = connect.connectToDB();
                    cmd7.ExecuteNonQuery();
                }

                MessageBox.Show("Registration was successful.");
                Response.Redirect("Login.aspx");
            }
            else
            {
                MessageBox.Show("Invalid number. Try Again!");
            }
        }

        connect.connectToDB().Close();
    }
}
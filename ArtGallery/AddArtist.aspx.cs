using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

public partial class AddArtist : System.Web.UI.Page
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
    }

    protected void btnAddArtist_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string DOB = txtDOB.Text;
        string DOD = txtDOD.Text;
        string born = txtBorn.Text;
        string death = txtDeath.Text;
        string nationality = txtNationality.Text;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Artists/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        cmd2.CommandText = "SELECT * FROM [dbo].[Artist] WHERE [name]='" + name + "' AND [surname]='" + surname + "'";
        cmd2.Connection = connect.connectToDB();
        dr = cmd2.ExecuteReader();

        if (dr.HasRows)
        {
            MessageBox.Show("There is already an artist with this name and surname!");
        }
        else
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[Artist]([name],[surname],[dateOfBirth],[dateOfDeath],[bornLocation],[deathLocation],[nationality],[image]) VALUES(@name,@surname,@dateOfBirth,@dateOfDeath,@bornLocation,@deathLocation,@nationality,@image)";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@dateOfBirth", DOB);
            cmd.Parameters.AddWithValue("@dateOfDeath", DOD);
            cmd.Parameters.AddWithValue("@bornLocation", born);
            cmd.Parameters.AddWithValue("@deathLocation", death);
            cmd.Parameters.AddWithValue("@nationality", nationality);
            cmd.Parameters.AddWithValue("@image", filePath.ToString());

            cmd.Connection = connect.connectToDB();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Artist successfully added!");
            Response.Redirect("Artists.aspx");
        }

        connect.connectToDB().Close();
    }
}
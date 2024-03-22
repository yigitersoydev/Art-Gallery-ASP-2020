using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

public partial class AddGallery : System.Web.UI.Page
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

    protected void btnAddGallery_Click(object sender, EventArgs e)
    {
        string gname = txtGName.Text;
        string city = txtCity.Text;
        string country = txtCountry.Text;
        string date = txtDate.Text;
        string desc = txtDescription.Text;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Galleries/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        cmd2.CommandText = "SELECT * FROM [dbo].[Gallery] WHERE [gname]='" + gname + "'";
        cmd2.Connection = connect.connectToDB();
        dr = cmd2.ExecuteReader();

        if (dr.HasRows)
        {
            MessageBox.Show("There is already a gallery with this name!");
        }
        else
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[Gallery]([gname],[city],[country],[image],[date],[description]) VALUES(@gname,@city,@country,@image,@date,@description)";
            cmd.Parameters.AddWithValue("@gname", gname);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@image", filePath.ToString());
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@description", desc);

            cmd.Connection = connect.connectToDB();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Gallery successfully added!");
            Response.Redirect("Galleries.aspx");
        }

        connect.connectToDB().Close();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

public partial class ArtApplication : System.Web.UI.Page
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
            SqlDataReader dr;

            SqlCommand bringA = new SqlCommand();
            bringA.CommandText = "SELECT * FROM [dbo].[Artist] AS A INNER JOIN [dbo].[UserArtist] AS UA ON UA.artistID = A.artistID WHERE [userID]=" + Session["ID"];
            bringA.Connection = connect.connectToDB();
            dr = bringA.ExecuteReader();
            dr.Read();

            txtName.Text = dr["name"].ToString();
            txtSurname.Text = dr["surname"].ToString();
            txtEmail.Text = dr["email"].ToString();

            if (!IsPostBack)
            {
                SqlCommand bringG = new SqlCommand();
                bringG.CommandText = "SELECT [galleryID],[gname] FROM [dbo].[Gallery]";
                bringG.Connection = connect.connectToDB();
                SqlDataAdapter da = new SqlDataAdapter(bringG);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlGallery.DataSource = dt;
                ddlGallery.DataBind();
                ddlGallery.DataTextField = "gname";
                ddlGallery.DataValueField = "galleryID";
                ddlGallery.DataBind();

                SqlCommand bringAT = new SqlCommand();
                bringAT.CommandText = "SELECT [artType],[artTypeID] FROM [dbo].[ArtType]";
                bringAT.Connection = connect.connectToDB();
                SqlDataAdapter da2 = new SqlDataAdapter(bringAT);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ddlArtType.DataTextField = "artType";
                ddlArtType.DataValueField = "artTypeID";
                ddlArtType.DataSource = dt2;
                ddlArtType.DataBind();

            }

            connect.connectToDB().Close();
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        SqlCommand bringA = new SqlCommand();
        SqlDataReader dr;
        bringA.CommandText = "SELECT * FROM [dbo].[Artist] AS A INNER JOIN [dbo].[UserArtist] AS UA ON UA.artistID = A.artistID WHERE [userID]=" + Session["ID"];
        bringA.Connection = connect.connectToDB();
        dr = bringA.ExecuteReader();
        dr.Read();

        //artistID = dr["artistID"]
        string title = txtTitle.Text;
        string year = txtYear.Text;
        string history = txtHistory.Text;
        string gallery = ddlGallery.SelectedValue;
        string type = ddlArtType.SelectedValue;
        int defaultVal = 0;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Arts/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand insert = new SqlCommand();
        insert.CommandText = "INSERT INTO [dbo].[Application]([artistID],[titleOfArt],[yearOfArt],[image],[artTypeID],[history],[statusOfApplication],[galleryID]) VALUES(@artistID,@titleOfArt,@yearOfArt,@image,@artTypeID,@history,@statusOfApplication,@galleryID)";
        insert.Parameters.AddWithValue("@artistID", dr["artistID"]);
        insert.Parameters.AddWithValue("@titleOfArt", title);
        insert.Parameters.AddWithValue("@yearOfArt", year);
        insert.Parameters.AddWithValue("@image", filePath.ToString());
        insert.Parameters.AddWithValue("@artTypeID", type);
        insert.Parameters.AddWithValue("@history", history);
        insert.Parameters.AddWithValue("@statusOfApplication", defaultVal);
        insert.Parameters.AddWithValue("@galleryID", gallery);

        insert.Connection = connect.connectToDB();
        insert.ExecuteNonQuery();

        MessageBox.Show("Application done successfully.");
        Response.Redirect("ArtistProfile.aspx");
    }
}
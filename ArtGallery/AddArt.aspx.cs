using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;

public partial class AddArt : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [artistID],([name] +' '+ ISNULL([surname],' ')) AS [Name Surname] FROM [dbo].[Artist]";
            cmd.Connection = connect.connectToDB();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlArtist.DataSource = dt;
            ddlArtist.DataBind();
            ddlArtist.DataTextField = "Name Surname";
            ddlArtist.DataValueField = "artistID";
            ddlArtist.DataBind();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SELECT [artType],[artTypeID] FROM [dbo].[ArtType]";
            cmd2.Connection = connect.connectToDB();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ddlArtType.DataTextField = "artType";
            ddlArtType.DataValueField = "artTypeID";
            ddlArtType.DataSource = dt2;
            ddlArtType.DataBind();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT [gname],[galleryID] FROM [dbo].[Gallery]";
            cmd3.Connection = connect.connectToDB();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ddlGallery.DataTextField = "gname";
            ddlGallery.DataValueField = "galleryID";
            ddlGallery.DataSource = dt3;
            ddlGallery.DataBind();
        }

        connect.connectToDB().Close();
    }

    protected void btnAddArt_Click(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string date = txtDate.Text;
        string history = txtHistory.Text;
        string artist = ddlArtist.SelectedValue;
        string type = ddlArtType.SelectedValue;
        string gallery = ddlGallery.SelectedValue;
        int defaultVal = 0;

        string random = connect.CreateRandomChar();
        string upload = Request.PhysicalApplicationPath + "Images/Arts/";

        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(upload + random + extension);
            filePath = (random + extension).ToString();
        }

        SqlCommand cmd3 = new SqlCommand();
        SqlDataReader dr;
        cmd3.CommandText = "SELECT * FROM [dbo].[Art] WHERE [title]='" + title + "' AND [artistID]='" + artist + "'";
        cmd3.Connection = connect.connectToDB();
        dr = cmd3.ExecuteReader();

        if (dr.HasRows)
        {
            MessageBox.Show("There is already an art with this title and author!");
        }
        else
        {
            SqlCommand cmd4 = new SqlCommand();
            cmd4.CommandText = "INSERT INTO [dbo].[Art]([title],[date],[image],[likes],[dislikes],[history],[artistID],[artTypeID]) VALUES(@title,@date,@image,@likes,@dislikes,@history,@artistID,@artTypeID)";
            cmd4.Parameters.AddWithValue("@title", title);
            cmd4.Parameters.AddWithValue("@date", date);
            cmd4.Parameters.AddWithValue("@history", history);
            cmd4.Parameters.AddWithValue("@artistID", artist);
            cmd4.Parameters.AddWithValue("@artTypeID", type);
            cmd4.Parameters.AddWithValue("@likes", defaultVal);
            cmd4.Parameters.AddWithValue("@dislikes", defaultVal);
            cmd4.Parameters.AddWithValue("@image", filePath.ToString());

            cmd4.Connection = connect.connectToDB();
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand();
            SqlDataReader dr2;
            cmd5.CommandText = "SELECT TOP 1 [artID] FROM [dbo].[Art] ORDER BY [artID] DESC";
            cmd5.Connection = connect.connectToDB();
            dr2 = cmd5.ExecuteReader();
            dr2.Read();

            SqlCommand cmd6 = new SqlCommand();
            cmd6.CommandText = "INSERT INTO [dbo].[GalleryArt]([galleryID],[artID]) VALUES(@galleryID,@artID)";
            cmd6.Parameters.AddWithValue("@galleryID", gallery);
            cmd6.Parameters.AddWithValue("@artID", dr2["artID"]);

            cmd6.Connection = connect.connectToDB();
            cmd6.ExecuteNonQuery();

            MessageBox.Show("Art successfully added!");
            Response.Redirect("Artists.aspx?artist=" + artist);
        }

        connect.connectToDB().Close();
    }
}
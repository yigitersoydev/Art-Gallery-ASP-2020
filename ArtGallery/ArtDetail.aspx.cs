using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ArtDetail : System.Web.UI.Page
{
    Control connect = new Control();
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnlLogSign = (Panel)Master.FindControl("pnlLogSign");
        Panel pnlLogout = (Panel)Master.FindControl("pnlLogout");

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

        string art = Request.QueryString["art"];

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        cmd.CommandText = "SELECT ART.[title],ART.[date],[likes],[dislikes],ART.[image],A.[name],A.[surname],A.[artistID],ART.[history],ATYPE.[artType],G.[galleryID],G.[gname],G.[city],G.[country] " +
            "FROM [dbo].[Art] AS ART INNER JOIN [dbo].[Artist] AS A ON A.artistID = ART.artistID " +
            "INNER JOIN [dbo].[ArtType] AS ATYPE ON ATYPE.artTypeID = ART.artTypeID INNER JOIN [dbo].[GalleryArt] AS GA ON GA.artID = ART.artID " +
            "INNER JOIN [dbo].[Gallery] AS G ON G.galleryID = GA.galleryID " +
            "WHERE ART.artID='" + art + "'";
        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        rptr_ArtDetail.DataSource = dr;
        rptr_ArtDetail.DataBind();

        connect.connectToDB().Close();

        string gallery = Request.QueryString["gallery"];
        string artist = Request.QueryString["artist"];

        if (gallery != null)
        {
            Response.Redirect("GalleryDetail.aspx?gallery=" + gallery);
        }

        if (artist != null)
        {
            Response.Redirect("ArtistDetail.aspx?artist=" + artist);
        }
    }
    protected void btnLiked_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
        {
            string art = Request.QueryString["art"];

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE [dbo].[Art] SET [likes]=[likes]+1 WHERE [artID]=" + art;
            cmd.Connection = connect.connectToDB();
            cmd.ExecuteNonQuery();

            connect.connectToDB().Close();

            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        
    }

    protected void btnDislike_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
        {
            string art = Request.QueryString["art"];

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE [dbo].[Art] SET [dislikes]=[dislikes]+1 WHERE [artID]=" + art;
            cmd.Connection = connect.connectToDB();
            cmd.ExecuteNonQuery();

            connect.connectToDB().Close();

            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnLikedAlready_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
        {
            string art = Request.QueryString["art"];

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE [dbo].[Art] SET [likes]=[likes]-1 WHERE [artID]=" + art;
            cmd.Connection = connect.connectToDB();
            cmd.ExecuteNonQuery();

            connect.connectToDB().Close();

            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnDislikedAlready_Click(object sender, EventArgs e)
    {
        if (Session["ID"] != null)
        {
            string art = Request.QueryString["art"];

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE [dbo].[Art] SET [dislikes]=[dislikes]-1 WHERE [artID]=" + art;
            cmd.Connection = connect.connectToDB();
            cmd.ExecuteNonQuery();

            connect.connectToDB().Close();

            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}
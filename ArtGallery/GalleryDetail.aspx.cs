using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class GalleryDetail : System.Web.UI.Page
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

        string gallery = Request.QueryString["gallery"];

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr, dr2;
        cmd.CommandText = "SELECT A.[artID],A.[title],A.[image],G.[galleryID] " +
            "FROM [dbo].[GalleryArt] AS GA INNER JOIN [dbo].[Art] AS A ON A.artID = GA.artID INNER JOIN [dbo].[Gallery] AS G ON G.galleryID = GA.galleryID " +
            "WHERE G.galleryID ='" + gallery + "'";
        cmd2.CommandText = "SELECT * FROM [dbo].[Gallery] WHERE [galleryID]='" + gallery + "'";
        cmd.Connection = connect.connectToDB();
        cmd2.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        dr2 = cmd2.ExecuteReader();
        rptr_GalleryDetail.DataSource = dr2;
        rptr_GalleryDetail.DataBind();
        rptr_GalleryArt.DataSource = dr;
        rptr_GalleryArt.DataBind();

        connect.connectToDB().Close();

        string art = Request.QueryString["art"];

        if (art != null)
        {
            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
    }
}
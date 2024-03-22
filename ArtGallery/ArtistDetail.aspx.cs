using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ArtistDetail : System.Web.UI.Page
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

        string artist = Request.QueryString["artist"];

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr, dr2;

        cmd.CommandText = "SELECT AR.[artID],AR.[title],AR.[image] " +
            "FROM [dbo].[Art] AS AR INNER JOIN [dbo].[Artist] AS A ON AR.artistID = A.artistID " +
            "WHERE AR.artistID='" + artist + "'";

        cmd2.CommandText = "SELECT * FROM [dbo].[Artist] WHERE artistID='" + artist + "'";

        cmd.Connection = connect.connectToDB();
        cmd2.Connection = connect.connectToDB();
        dr2 = cmd2.ExecuteReader();
        dr = cmd.ExecuteReader();

        rptr_ArtistArt.DataSource = dr;
        rptr_ArtistArt.DataBind();
        rptr_ArtistDetail.DataSource = dr2;
        rptr_ArtistDetail.DataBind();

        connect.connectToDB().Close();

        string art = Request.QueryString["art"];

        if (art != null)
        {
            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
    }
}
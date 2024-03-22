using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
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

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr, dr2;
        cmd.CommandText = "SELECT* FROM[dbo].[Exhibition] AS E INNER JOIN[dbo].[Gallery] AS G ON G.galleryID = E.galleryID INNER JOIN[dbo].[ArtType] AS A ON A.artTypeID = E.[type] WHERE E.startDate >= CONVERT(DATE, getdate()) ORDER BY E.startDate ASC";

        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        rptr_HomeExhib.DataSource = dr;
        rptr_HomeExhib.DataBind();

        SqlCommand cmd2 = new SqlCommand();
        cmd2.CommandText = "SELECT TOP 4 * FROM [dbo].[Art] AS ART INNER JOIN [dbo].[Artist] AS A ON A.artistID = ART.artistID ORDER BY NEWID()";
        cmd2.Connection = connect.connectToDB();
        dr2 = cmd2.ExecuteReader();
        rptr_RandomArts.DataSource = dr2;
        rptr_RandomArts.DataBind();

        connect.connectToDB().Close();

        string art = Request.QueryString["art"];

        if (art != null)
        {
            Response.Redirect("ArtDetail.aspx?art=" + art);
        }
    }
}
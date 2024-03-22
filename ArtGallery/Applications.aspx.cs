using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Applications : System.Web.UI.Page
{
    Control connect = new Control();
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

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        cmd.CommandText = "SELECT A.[applicationID],AR.[artistID],AR.[name],AR.[surname],A.[titleOfArt],A.[yearOfArt],ART.[artType],SUBSTRING(A.[history],1,85) AS history FROM [dbo].[Application] AS A INNER JOIN [dbo].[Artist] AS AR ON AR.artistID = A.artistID  INNER JOIN[dbo].[ArtType] AS ART ON ART.artTypeID = A.artTypeID";

        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        rptr_Applications.DataSource = dr;
        rptr_Applications.DataBind();

        connect.connectToDB().Close();

        string artist = Request.QueryString["artist"];

        if (artist != null)
        {
            Response.Redirect("ArtistDetail.aspx?artist=" + artist);
        }

        string application = Request.QueryString["application"];

        if (application != null)
        {
            Response.Redirect("ApplicationDetail.aspx?application=" + application);
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class MyApplications : System.Web.UI.Page
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
        cmd.CommandText = "SELECT A.[titleOfArt],a.[yearOfArt],ART.[artType],G.[gname],A.[statusOfApplication],SUBSTRING(A.[history],1,85) AS history,G.[galleryID] FROM [dbo].[Application] AS A INNER JOIN [dbo].[Gallery] AS G ON G.[galleryID]=A.[galleryID] INNER JOIN [dbo].[ArtType] AS ART ON ART.[artTypeID] = A.[artTypeID] INNER JOIN[dbo].[UserArtist] AS UA ON UA.[artistID] = A.[artistID] WHERE UA.userID=" + Session["ID"];
        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        rptr_MyApplications.DataSource = dr;
        rptr_MyApplications.DataBind();

        connect.connectToDB().Close();

        string gallery = Request.QueryString["gallery"];

        if (gallery != null)
        {
            Response.Redirect("GalleryDetail.aspx?gallery=" + gallery);
        }
    }
}
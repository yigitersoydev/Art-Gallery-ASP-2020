using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Exhibitions : System.Web.UI.Page
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
        SqlDataReader dr;
        cmd.CommandText = "SELECT * FROM [dbo].[Exhibition] AS E INNER JOIN [dbo].[Gallery] AS G ON G.galleryID = E.galleryID INNER JOIN [dbo].[ArtType] AS A ON A.artTypeID = E.[type]";

       cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        rptr_Exhibitions.DataSource = dr;
        rptr_Exhibitions.DataBind();

        connect.connectToDB().Close();

        string gallery = Request.QueryString["gallery"];

        if (gallery != null)
        {
            Response.Redirect("galleryDetail.aspx?gallery=" + gallery);
        }
    }
}
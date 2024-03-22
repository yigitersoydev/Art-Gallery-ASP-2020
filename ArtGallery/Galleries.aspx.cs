using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Galleries : System.Web.UI.Page
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
        cmd.CommandText = "SELECT * FROM [dbo].[Gallery]";
        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        rptr_Galleries.DataSource = dr;
        rptr_Galleries.DataBind();

        connect.connectToDB().Close();

        string gallery = Request.QueryString["gallery"];

        if (gallery != null)
        {
            Response.Redirect("galleryDetail.aspx?gallery=" + gallery);
        }
    }
}
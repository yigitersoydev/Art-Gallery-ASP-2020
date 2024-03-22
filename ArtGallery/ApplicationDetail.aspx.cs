using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class ApplicationDetail : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {

            string application = Request.QueryString["application"];

            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            cmd.CommandText = "SELECT A.[applicationID],AR.[artistID],AR.[name],AR.[surname],A.[titleOfArt],A.[yearOfArt],ART.[artType],A.[history],A.[image],G.[gname],G.[galleryID] FROM [dbo].[Application] AS A INNER JOIN [dbo].[Artist] AS AR ON AR.artistID = A.artistID  INNER JOIN[dbo].[ArtType] AS ART ON ART.artTypeID = A.artTypeID INNER JOIN[dbo].[Gallery] AS G ON G.galleryID = A.galleryID WHERE A.[applicationID]=" + application;

            cmd.Connection = connect.connectToDB();
            dr = cmd.ExecuteReader();
            rptr_AppDetail.DataSource = dr;
            rptr_AppDetail.DataBind();

            connect.connectToDB().Close();

        }

        string gallery = Request.QueryString["gallery"];

        if (gallery != null)
        {
            Response.Redirect("GalleryDetail.aspx?gallery=" + gallery);
        }

    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        string application = Request.QueryString["application"];
        int defaultVal = 0;

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        cmd.CommandText = "SELECT A.[applicationID],AR.[artistID],AR.[name],AR.[email],AR.[surname],A.[titleOfArt],A.[yearOfArt],ART.[artType],A.[history],A.[image],A.[artTypeID],G.[gname],G.[galleryID] FROM [dbo].[Application] AS A INNER JOIN [dbo].[Artist] AS AR ON AR.artistID = A.artistID  INNER JOIN[dbo].[ArtType] AS ART ON ART.artTypeID = A.artTypeID INNER JOIN[dbo].[Gallery] AS G ON G.galleryID = A.galleryID WHERE A.[applicationID]=" + application;

        cmd.Connection = connect.connectToDB();
        dr = cmd.ExecuteReader();
        dr.Read();

        SqlCommand cmd2 = new SqlCommand();
        cmd2.CommandText = "INSERT INTO [dbo].[Art]([title],[date],[artistID],[likes],[dislikes],[image],[artTypeID],[history]) VALUES(@title,@date,@artistID,@likes,@dislikes,@image,@artTypeID,@history)";
        cmd2.Parameters.AddWithValue("@title", dr["titleOfArt"]);
        cmd2.Parameters.AddWithValue("@date", Convert.ToDateTime(dr["yearOfArt"]).ToString("yyyy-MM-dd"));
        cmd2.Parameters.AddWithValue("@artistID", dr["artistID"]);
        cmd2.Parameters.AddWithValue("@likes", defaultVal);
        cmd2.Parameters.AddWithValue("@dislikes", defaultVal);
        cmd2.Parameters.AddWithValue("@image", dr["image"]);
        cmd2.Parameters.AddWithValue("@artTypeID", dr["artTypeID"]);
        cmd2.Parameters.AddWithValue("@history", dr["history"]);

        cmd2.Connection = connect.connectToDB();
        cmd2.ExecuteNonQuery();

        SqlCommand cmd4 = new SqlCommand();
        SqlDataReader dr2;
        cmd4.CommandText = "SELECT TOP 1 [artID] FROM [dbo].[Art] ORDER BY [artID] DESC";
        cmd4.Connection = connect.connectToDB();
        dr2 = cmd4.ExecuteReader();
        dr2.Read();

        SqlCommand cmd3 = new SqlCommand();
        cmd3.CommandText = "INSERT INTO [dbo].[GalleryArt]([galleryID],[artID]) VALUES(@galleryID,@artID)";
        cmd3.Parameters.AddWithValue("@galleryID",dr["galleryID"]);
        cmd3.Parameters.AddWithValue("@artID", dr2["artID"]);

        cmd3.Connection = connect.connectToDB();
        cmd3.ExecuteNonQuery();

        MailMessage msg = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        msg.From = new MailAddress("informationartgallery@gmail.com", "ART GALLERY");
        msg.To.Add(new MailAddress(dr["email"].ToString()));
        msg.Subject = "About your application";
        msg.IsBodyHtml = true;
        msg.Body = "Hi " + dr["name"].ToString() + " " + dr["surname"].ToString() + ",<br/><br/>Congratulations!<br/><br/>Thank you for your application.!<br/><br/> We enjoyed getting to know more about your artwork. We appreciate you sharing information about yourself and your artwork with us.<br/><br/>Your application has been approved.<br/><br/>our artwork will be exhibited in the '" + dr["gname"] + "' in the next few days. We would like to see you among us on the day it will be exhibited.<br/><br/>If you have any questions or run into any problems, you can reach out to us directly at informationartgallery@gmail.com<br/><br/>I wish you best of luck!<br/><br/>Sincerely,<br/><br/>Art Gallery Administrator";
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("informationartgallery@gmail.com", "ArtGallery2020");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(msg);
        MessageBox.Show("Mail has been sent successfully.!");

        SqlCommand cmd5 = new SqlCommand();
        cmd5.CommandText = "UPDATE [dbo].[Application] SET [statusOfApplication]=1 WHERE [applicationID]=" + application;
        cmd5.Connection = connect.connectToDB();
        cmd5.ExecuteNonQuery();

        connect.connectToDB().Close();

        Response.Redirect("Applications.aspx");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        string application = Request.QueryString["application"];

        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        cmd2.CommandText = "SELECT AR.[name],AR.[surname],AR.[email] FROM [dbo].[Application] AS A INNER JOIN [dbo].[Artist] AS AR ON AR.artistID = A.artistID  INNER JOIN[dbo].[ArtType] AS ART ON ART.artTypeID = A.artTypeID WHERE A.[applicationID]=" + application;
        cmd2.Connection = connect.connectToDB();
        dr = cmd2.ExecuteReader();
        dr.Read();

        MailMessage msg = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        msg.From = new MailAddress("informationartgallery@gmail.com","ART GALLERY");
        msg.To.Add(new MailAddress(dr["email"].ToString()));
        msg.Subject = "About your application";
        msg.IsBodyHtml = true;
        msg.Body = "Hi " + dr["name"].ToString() + " " + dr["surname"].ToString() + ",<br/><br/>Thank you for your application.!<br/><br/> We enjoyed getting to know more about your artwork. We appreciate you sharing information about yourself and your artwork with us.<br/><br/>Selection of works to be exhibited in the gallery is always a difficult decision and is based on many factors.<br/><br/>I regret to inform you that your art won't be exhibited in the gallery.<br/><br/>I wish you best of luck!<br/><br/>Sincerely,<br/><br/>Art Gallery Administrator";
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("informationartgallery@gmail.com", "ArtGallery2020");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(msg);
        MessageBox.Show("Mail has been sent successfully.!");

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE FROM [dbo].[Application] WHERE [applicationID]=" + application;
        cmd.Connection = connect.connectToDB();
        cmd.ExecuteNonQuery();

        connect.connectToDB().Close();


        Response.Redirect("Applications.aspx");
    }
}
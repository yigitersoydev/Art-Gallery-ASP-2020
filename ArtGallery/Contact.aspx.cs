using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Panel pnlLogSign = (System.Web.UI.WebControls.Panel)Master.FindControl("pnlLogSign");
        System.Web.UI.WebControls.Panel pnlLogout = (System.Web.UI.WebControls.Panel)Master.FindControl("pnlLogout");

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
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string email = txtEmail.Text;
        string message = txtMessage.Text;

        MailMessage msg = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        msg.From = new MailAddress("SENDER_EMAIL");   
        msg.To.Add(new MailAddress("YOUR_EMAIL"));      
        msg.Subject = "Feedback mail from user";
        msg.IsBodyHtml = true; 
        msg.Body = "This message was sent by " + name + " " + surname + ". <br/>Email: "+email +" <br/>The message is: <br/>" + message + ".";
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("SENDER_EMAIL", "SENDER_PASSWORD");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.Send(msg);
        MessageBox.Show("Mail has been sent successfully.!");

        Response.Redirect("Contact.aspx");
    }
}
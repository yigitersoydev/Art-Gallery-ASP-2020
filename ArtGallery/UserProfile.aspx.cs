﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class UserProfile : System.Web.UI.Page
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
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlCommand cmd4 = new SqlCommand();
        SqlCommand cmd5 = new SqlCommand();

        SqlDataReader dr, dr2, dr3, dr4, dr5;

        cmd2.CommandText = "SELECT * FROM [dbo].[User] WHERE [userID]=" + Session["ID"] + "AND [userTypeID]=1";
        cmd3.CommandText = "SELECT * FROM [dbo].[User] WHERE [userID]=" + Session["ID"] + "AND [userTypeID]=2";
        cmd4.CommandText = "SELECT * FROM [dbo].[UserArtist] WHERE [userID]='" + Session["ID"] + "'";
        cmd2.Connection = connect.connectToDB();
        cmd3.Connection = connect.connectToDB();
        cmd4.Connection = connect.connectToDB();
        dr2 = cmd2.ExecuteReader();
        dr3 = cmd3.ExecuteReader();
        dr4 = cmd4.ExecuteReader();

        while (dr4.Read())
        {
            cmd5.CommandText = "SELECT * FROM [dbo].[UserArtist] WHERE [artistID]='" + dr4["artistID"] + "'";
            cmd5.Connection = connect.connectToDB();
            dr5 = cmd5.ExecuteReader();

            if (dr5.HasRows)
            {
                Response.Redirect("ArtistProfile.aspx");
            }
        }

        if (dr2.HasRows)
        {
            btnApplication.Visible = false;
            btnApplications.Visible = true;
            btnAddGalery.Visible = true;
            btnAddArtist.Visible = true;
            btnAddArt.Visible = true;
        }
        else if (dr3.HasRows)
        {
            btnApplication.Visible = true;
            btnApplications.Visible = false;
            btnAddGalery.Visible = false;
            btnAddArtist.Visible = false;
            btnAddArt.Visible = false;
        }
        else
        {
            btnApplication.Visible = false;
            btnApplications.Visible = false;
            btnAddGalery.Visible = false;
            btnAddArtist.Visible = false;
            btnAddArt.Visible = false;
        }

        if (Session["ID"] != null)
        {
            pnlLogout.Visible = true;
            pnlLogSign.Visible = false;


            cmd.CommandText = "SELECT * FROM [dbo].[User] WHERE [userID]='" + Session["ID"] + "'";
            cmd.Connection = connect.connectToDB();

            dr = cmd.ExecuteReader();
            rptr_Profile.DataSource = dr;
            rptr_Profile.DataBind();

            connect.connectToDB().Close();

        }

        string user = Request.QueryString["user"];

        if (user != null)
        {
            Response.Redirect("UpdateProfile.aspx?user=" + user);
        }

        string userC = Request.QueryString["userC"];

        if (userC != null)
        {
            Response.Redirect("ChangePassword.aspx?userC=" + userC);
        }

    }

    protected void btnAddGalery_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddGallery.aspx");
    }

    protected void btnApplication_Click(object sender, EventArgs e)
    {
        Response.Redirect("ArtApplication.aspx");
    }

    protected void btnApplications_Click(object sender, EventArgs e)
    {
        Response.Redirect("Applications.aspx");
    }

    protected void btnAddArtist_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddArtist.aspx");
    }

    protected void btnAddArt_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddArt.aspx");
    }
}
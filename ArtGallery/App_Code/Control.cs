using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Control
/// </summary>
public class Control
{
    public Control()
    {
       
    }

    public SqlConnection connectToDB()
    {
        string conn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        return (connection);
    }

    public string CreateRandomChar()
    {
        string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789-";
        Random randNum = new Random((int)DateTime.Now.Ticks);
        char[] chars = new char[7];

        for (int i = 0; i < 7; i++)
        {
            chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
        }
        return new string(chars);
    }
}
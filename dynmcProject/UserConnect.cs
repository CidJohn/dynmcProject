using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace dynmcProject
{
    internal class UserConnect
    {
        SqlConnection conn;
        SqlCommand Command;
        public void UserAttempt()
        {
            conn = new SqlConnection(FrmParent.ConnectionString);
            Command = new SqlCommand("spUserAttemp", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@Username", FrmLogin.txtUser);
            Command.Parameters.AddWithValue("@Password",FrmLogin. txtPass);
            Command.Parameters.AddWithValue("@UserID", FrmLogin.sndID);
            Command.Parameters.AddWithValue("@userType", FrmLogin.sndType);
            Command.Parameters.AddWithValue("@userlock", 1);

            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();

        }
        public void UserTimeIn(int modif, string userid)
        {
            conn = new SqlConnection(FrmParent.ConnectionString);
            Command = new SqlCommand("spActiveMenu", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@userID", userid);
            Command.Parameters.AddWithValue("@Modify", modif);

            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
        public void Active(int modif, string userid)
        {
            conn = new SqlConnection(FrmParent.ConnectionString);
            Command = new SqlCommand("spActiveMenu", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@userID", userid);
            Command.Parameters.AddWithValue("@Modify", modif);

            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();

        }
       
    }

}

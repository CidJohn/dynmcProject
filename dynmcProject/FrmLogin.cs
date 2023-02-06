using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynmcProject
{
    public partial class FrmLogin : Form
    {
        SqlConnection conn;
        SqlCommand Command;
        public static string sndName;
        public static string sndType;
        public static string sndID;
        public static string txtUser;
        public static string txtPass;
          
        int attmpt = 1;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(attmpt <= 3)
            { 
                conn = new SqlConnection(FrmParent.ConnectionString);
                Command = new SqlCommand("spValidateUserData", conn);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@Username", txtUsername.Text);
                Command.Parameters.AddWithValue("@Password", "");
                Command.Parameters.AddWithValue("@UserID", "");
                Command.Parameters.AddWithValue("@IDENTITY", 0);
                
                DataTable dtTable = new DataTable();
                conn.Open();
                dtTable.Load(Command.ExecuteReader());
                conn.Close();
                sndName = dtTable.Rows[0]["UserName"].ToString();
                sndType = dtTable.Rows[0]["userType"].ToString();
                sndID = dtTable.Rows[0]["UserID"].ToString();
                txtUser = txtUsername.Text;
                txtPass = txtPassword.Text;
                 if (dtTable.Rows.Count > 0 && Convert.ToInt32(dtTable.Rows[0]["LockOut"].ToString()) == 1)
                {
                    MessageBox.Show("Your Account is Lock due to Login attempt !");
                }
                else if ( dtTable.Rows[0]["Password"].ToString() == txtPassword.Text)
                   {
                    UserConnect usertime = new UserConnect();
                    usertime.UserTimeIn(1,sndID);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                      this.Close();
                   } 
                else if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
                    {
                        MessageBox.Show("Username and Password are Empty","Required",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                else
                    {
                        MessageBox.Show("Try Again! No. of Attempt : "+attmpt, "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else 
            {
               
                Command.Parameters.AddWithValue("@IDENTITY", 3);
                MessageBox.Show("Login Exceeded!");
                UserConnect user = new UserConnect();
                user.UserAttempt();
                txtPassword.Enabled= false;
                txtUsername.Enabled= false;
                btnLogin.Enabled= false;
                btnChangPass.Enabled = false;
            }
             attmpt++;
            //Command.Parameters.AddWithValue("@IDENTITY", 3);
        }

        private void btnChangPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            conn = new SqlConnection(FrmParent.ConnectionString);
            Command = new SqlCommand("spValidateUserData", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@Username", txtUsername.Text);
            Command.Parameters.AddWithValue("@Password", "");
            Command.Parameters.AddWithValue("@UserID", "");
            Command.Parameters.AddWithValue("@IDENTITY", 0);
            DataTable dtTable = new DataTable();
            conn.Open();
            dtTable.Load(Command.ExecuteReader());
            conn.Close();
            if(dtTable.Rows.Count > 0)
            {
                sndName = dtTable.Rows[0]["UserName"].ToString();
                sndType = dtTable.Rows[0]["userType"].ToString();
                sndID = dtTable.Rows[0]["UserID"].ToString();
                
                FrmChngPass frm = new FrmChngPass();
                frm.ShowDialog();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                MessageBox.Show("Your Username is Invalid","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (showpass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != string.Empty)
            {
                btnChangPass.Enabled = true;
            }
            else
            {
                btnChangPass.Enabled = false;
            }
        }
    }
}

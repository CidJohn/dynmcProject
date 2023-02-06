using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dynmcProject
{
    public partial class FrmChngPass : Form
    {
        SqlConnection conn;
        SqlCommand Command;
        DataTable dtTable;
        public FrmChngPass()
        {
            InitializeComponent();
        }

        // Form Load
        private void FrmChngPass_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(FrmParent.ConnectionString);
            Command = new SqlCommand("spPasswordPolicy", conn);
            Command.CommandType = CommandType.StoredProcedure;
            userName.Text = FrmLogin.sndName;
            userType.Text = FrmLogin.sndType;
            dtTable = new DataTable();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            Command.Parameters.AddWithValue("@Mode", 0);
            Command.Parameters.AddWithValue("@Criteria", "");
            Command.Parameters.AddWithValue("@CriteriaDesc", "");
            adapter.Fill(dtTable);

            
            if (dtTable.Rows.Count > 0)
            {
                charMax8.Text =  dtTable.Rows[0]["Criteria"].ToString() + " " + dtTable.Rows[0]["CriteriaDesc"].ToString();
                oneUpCase.Text = dtTable.Rows[1]["Criteria"].ToString() + " " + dtTable.Rows[1]["CriteriaDesc"].ToString();
                oneLowCase.Text = dtTable.Rows[2]["Criteria"].ToString() + " " + dtTable.Rows[2]["CriteriaDesc"].ToString();
                oneNum.Text = dtTable.Rows[3]["Criteria"].ToString() + " " + dtTable.Rows[3]["CriteriaDesc"].ToString();
                oneSimble.Text = dtTable.Rows[4]["Criteria"].ToString() + " " + dtTable.Rows[4]["CriteriaDesc"].ToString();
            }

            conn.Close();

            //Command.Parameters.AddWithValue("@Pw_Min", charMax8.Text);

            /*charMax8.Text = "Password should not be lesser than 8 or greater than 15 characters.";
            oneUpCase.Text = "Password should contain at least one upper case letter.";
            oneLowCase.Text = "Password should contain at least one lower case letter.";
            oneNum.Text = "Password should contain at least one numeric value.";
            oneSimble.Text = "Password should contain at least one special case character.";*/
            btnSubmit.Enabled= false;
        }

        // Cancel Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
        }
        // Submit Button
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            // SQL connection Selecing User
            conn = new SqlConnection(FrmParent.ConnectionString);
            Command = new SqlCommand("spValidateUserData", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@Username", FrmLogin.sndName);
            Command.Parameters.AddWithValue("@Password", "");
                    Command.Parameters.AddWithValue("@UserID", "");
            Command.Parameters.AddWithValue("@IDENTITY", 0);
             dtTable = new DataTable();
            conn.Open();
            dtTable.Load(Command.ExecuteReader());
            conn.Close();

            
            if(dtTable.Rows.Count > 0 && txtOldPass.Text != dtTable.Rows[0]["Password"].ToString() )
            {
                MessageBox.Show("OLd Password does not Match","Warning",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Password does not Match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(txtOldPass.Text == string.Empty || txtNewPass.Text == string.Empty || txtConfirmPass.Text == string.Empty)
            {
                MessageBox.Show("txtNewPass.Text field is Required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                {
                    // Validating User Pass if exist 
                    conn = new SqlConnection(FrmParent.ConnectionString);
                    Command = new SqlCommand("spValidateUserData", conn);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@Username", FrmLogin.sndName);
                    Command.Parameters.AddWithValue("@Password", txtConfirmPass.Text);
                    Command.Parameters.AddWithValue("@UserID", FrmLogin.sndID);
                    Command.Parameters.AddWithValue("@IDENTITY", 2);
                    dtTable = new DataTable();
                    conn.Open();
                    dtTable.Load(Command.ExecuteReader());
                    conn.Close();

                if (dtTable.Rows.Count > 0 && txtConfirmPass.Text == dtTable.Rows[0]["Password"].ToString())
                    {
                    MessageBox.Show("You Already Used This Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                else
                {
                    // Update the User Pass
                    this.Hide();
                    conn = new SqlConnection(FrmParent.ConnectionString);
                    Command = new SqlCommand("spValidateUserData", conn);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@Username", FrmLogin.sndName);
                    Command.Parameters.AddWithValue("@Password", txtConfirmPass.Text);
                    Command.Parameters.AddWithValue("@UserID", FrmLogin.sndID);
                    Command.Parameters.AddWithValue("@IDENTITY", 1);
                    conn.Open();
                    Command.ExecuteNonQuery();
                    conn.Close();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    MessageBox.Show("Password Change Successfully!");
                    FrmParent frm = new FrmParent();
                    frm.ShowDialog();
                }

            }

            
        }
        // User Pass strong Validation
        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            Valid();
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");


            if (hasLowerChar.IsMatch(txtNewPass.Text) && hasUpperChar.IsMatch(txtNewPass.Text) && hasMiniMaxChars.IsMatch(txtNewPass.Text)
           && hasNumber.IsMatch(txtNewPass.Text) && hasNumber.IsMatch(txtNewPass.Text) && hasSymbols.IsMatch(txtNewPass.Text))
            {
                // Activate Submit Button
                btnSubmit.Enabled= true;
                
            }
        }
        void Valid()
        {
            // Validation Proccess
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            int textbox = txtNewPass.TextLength;
            char[] txtchar = txtNewPass.Text.ToCharArray();
            string txt = txtNewPass.Text;
            if (textbox >= 8 && textbox <= 15)
            {
                charMax8.ForeColor = Color.Green;
            }
            else if (txt.Any(char.IsUpper))
            {
                oneUpCase.ForeColor = Color.Green;
            }
            else if (txt == string.Empty)
            {
                /*charMax8.Text = "-";
                oneUpCase.Text = "-";
                oneLowCase.Text = "-";
                oneSimble.Text = "-";
                oneNum.Text = "-";*/
                charMax8.ForeColor = Color.Red;
                oneUpCase.ForeColor = Color.Red;
                oneLowCase.ForeColor = Color.Red;
                oneSimble.ForeColor = Color.Red;
                oneNum.ForeColor = Color.Red;
            }
            else
            {
                charMax8.ForeColor = Color.Red;
                oneUpCase.ForeColor = Color.Red;
                oneLowCase.ForeColor = Color.Red;
                oneSimble.ForeColor = Color.Red;
                oneNum.ForeColor = Color.Red;
            }
            foreach (char n in specialCh)
            {
                if (txt.Contains(n))
                {
                    oneSimble.ForeColor = Color.Green;
                }
            }
            foreach (char n in txtchar)
            {
                if (n >= '0' && n <= '9')
                {
                    oneNum.ForeColor = Color.Green;
                }
            }
            foreach (char n in txtchar)
            {
                if (n >= 'a' && n <= 'z')
                {
                    oneLowCase.ForeColor = Color.Green;
                }
            }

        }
    }
}

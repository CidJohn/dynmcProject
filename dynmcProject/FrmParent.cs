using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dynmcProject
{
    public partial class FrmParent : Form //IMessageFilter
    {
        public static int UserID = -1;
        public static string ConnectionString = "Data Source=DESKTOP-G0TGK68\\SQLEXPRESS;Initial Catalog=db_project;User ID=sa;Password=P@ssw0rd";
        public static string parent;
       // static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
       // static int alarmCounter = 1;
       // static bool exitFlag = false;

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        SqlConnection conn;
        SqlCommand Command;
        TreeNode parentNode;
        public FrmParent()
        {
            InitializeComponent();
            
            
        }
        bool exitApp = false;
        // Form Load
        private void FrmParent_Load(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            DialogResult reply = frm.ShowDialog();
            while (reply == System.Windows.Forms.DialogResult.Ignore)
            {
                reply = frm.ShowDialog();
            }

            if (reply == System.Windows.Forms.DialogResult.Cancel)
            {
                exitApp = true;
                this.Close();
            }

            else if (reply == System.Windows.Forms.DialogResult.OK)
            {
                exitApp = false;
                foreach (Form frm2 in this.MdiChildren)
                    frm2.Close();
                Refresher();
                tvwMenu.ExpandAll();
                this.Show();
                Timer timer = new Timer();
                timer.Interval = 1000;  // check every second
                timer.Tick += new EventHandler(FormRefresher);
                timer.Start();
                conn = new SqlConnection(ConnectionString);
                    Command = new SqlCommand("spActiveMenu", conn);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@userID", FrmLogin.sndID);
                    Command.Parameters.AddWithValue("@Modify", 0);

                    DataTable dtTable = new DataTable();
                    conn.Open();
                    dtTable.Load(Command.ExecuteReader());
                    conn.Close();

                    if (dtTable.Rows.Count > 0 && Convert.ToInt32(dtTable.Rows[0]["Active"].ToString()) == 0)
                    {
                        exitApp = true;
                        this.Hide();
                    }
            }
           


        }
        private void FrmForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
      
            if (!exitApp)
            {
                e.Cancel = true;
                this.Hide();
                FrmLogin frm = new FrmLogin();
                DialogResult reply = frm.ShowDialog();
                while (reply == System.Windows.Forms.DialogResult.Ignore)
                {
                    reply = frm.ShowDialog();
                }

                if (reply == System.Windows.Forms.DialogResult.Cancel)
                {
                    exitApp = true;
                    this.Close();
                }
                else if (reply == System.Windows.Forms.DialogResult.OK)
                {
                    exitApp = false;
                    foreach (Form frm2 in this.MdiChildren)
                        frm2.Close();

                    tvwMenu.ExpandAll();
                    this.Show();
                }
            }
        }
        void Refresher()
        {

            conn = new SqlConnection(ConnectionString);
            Command = new SqlCommand("spMenuName", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@userID", "");
            Command.Parameters.AddWithValue("@identity", 0);
            Command.Parameters.AddWithValue("@parent", "");
            DataTable dtTable = new DataTable();
            conn.Open();
            dtTable.Load(Command.ExecuteReader());
            conn.Close();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                /*  parentNode = new TreeNode();
                  parentNode.Text = dtTable.Rows[i]["menuParent"].ToString();
                  parentNode.Name = dtTable.Rows[i]["menuParent"].ToString();*/
                //TreeNode  childNode = parentNode.Nodes.Add(dtTable.Rows[i]["menuChild"].ToString());
                //MessageBox.Show(parent);
                //tvwMenu.Nodes.Add(parentNode);
                parentNode = tvwMenu.Nodes.Add(dtTable.Rows[i]["menuParent"].ToString());
                parent = dtTable.Rows[i]["menuParent"].ToString();
                GetChildRow( parentNode);
               
            }

        }
        void GetChildRow( TreeNode childNode)
        {
            conn = new SqlConnection(ConnectionString);
            Command = new SqlCommand("spMenuName", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@userID", FrmLogin.sndID);
            Command.Parameters.AddWithValue("@identity", 1);
            Command.Parameters.AddWithValue("@parent", parent);
            DataTable dtTable = new DataTable();
            conn.Open();
            dtTable.Load(Command.ExecuteReader());
            conn.Close();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                /*  childNode = new TreeNode();
                  childNode.Text = dtTable.Rows[i]["menuChild"].ToString();
                  childNode.Name = dtTable.Rows[i]["menuChild"].ToString();*/
                //tvwMenu.Nodes.Add(childNode);
                //MessageBox.Show(parent);

                if (parentNode == null)
                    childNode = tvwMenu.Nodes.Add(dtTable.Rows[i]["menuParent"].ToString());
                else
                    childNode = parentNode.Nodes.Add(dtTable.Rows[i]["menuChild"].ToString());
            }
        }

        void FormRefresher(Object myObj, EventArgs e)
        {

            uint idleTime = GetIdleTime();
            conn = new SqlConnection(ConnectionString);
            Command = new SqlCommand("spUserInterval", conn);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@userID", FrmLogin.sndID);
            DataTable dtTable = new DataTable();
            conn.Open();
            dtTable.Load(Command.ExecuteReader());
            conn.Close();
            if(dtTable.Rows.Count > 0)
            {
                int timer = int.Parse(dtTable.Rows[0]["Interval"].ToString());
                if (idleTime >= timer * 60 * 1000)  // 6 seconds (6000 milliseconds)
                {
                    // PC has been idle for more than 6 seconds, close the form

                    UserConnect act = new UserConnect();
                    act.Active(2, FrmLogin.sndID);
                    this.Close();
                }
            }
           
        } 
        private uint GetIdleTime()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            GetLastInputInfo(ref lastInputInfo);
            return ((uint)Environment.TickCount - lastInputInfo.dwTime);
        }

    }
       
    
}

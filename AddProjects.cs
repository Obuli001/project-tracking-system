using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectTrackingSystem
{
    public partial class AddProjects : Form
    {
        string connString = "Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Int32 columnSize = 0;
        int i;

        public AddProjects()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assign objUI = new Assign();
            objUI.Show();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            String Id = txtPid.Text;
            String name = txtPName.Text;
            String DOS = txtDOS.Text;
            String owner = txtOwner.Text;
            String loc = txtLoc.Text;

            String lang = cmbLang.Text;
            String prior = cmbPri.Text;
            String assign = "";

            

            con.Open();
            string strQuery1 = "insert into projects(pid,name,DOS,owner,location,language,periority,assign) values (@pid,@name,@DOS,@owner,@location,@language,@periority,@assign)";
            SqlCommand cmd1 = new SqlCommand(strQuery1, con);
            cmd1.Parameters.Add("@pid", SqlDbType.VarChar).Value = Id;
            cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            cmd1.Parameters.Add("@DOS", SqlDbType.VarChar).Value = DOS;
            cmd1.Parameters.Add("@owner", SqlDbType.VarChar).Value = owner;
            cmd1.Parameters.Add("@location", SqlDbType.VarChar).Value = loc;
            cmd1.Parameters.Add("@language", SqlDbType.VarChar).Value = lang;
            cmd1.Parameters.Add("@periority", SqlDbType.VarChar).Value = prior;
            cmd1.Parameters.Add("@assign", SqlDbType.VarChar).Value = assign;


   

            cmd1.ExecuteNonQuery();
            con.Close();

        }

        private void AddProjects_Load(object sender, EventArgs e)
        {
            string sql = "select COUNT(*) FROM [ProjectTracking].[dbo].[projects]";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    columnSize = (Int32)cmd.ExecuteScalar();
                    txtPid.Text = "P" + (columnSize + 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProjStatus objUI = new ProjStatus();
            objUI.Show();
        }
    }
}

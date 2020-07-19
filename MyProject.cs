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

    public partial class MyProject : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public MyProject()
        {
            InitializeComponent();
        }

        private void MyProject_Load(object sender, EventArgs e)
        {
            String eid = "c2";
            //cmd = new SqlCommand("Select EnquiryNo,EnqDate,StudentName,College,Degree,Dept,Year,MobileNo,MobileNo1,MailId,MailId1 from Enquiry where EnqDate='" + lblDate.Text + "' and status=0", con);
            cmd = new SqlCommand("Select pid,name,DOS,language,periority from projects where assign='" + eid + "'", con);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "projects");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "projects";

            //txtStat.Text=
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String eid = "c2";
            String pid=lblPid.Text;
            String stat = edtStat.Text;
            cmd = new SqlCommand("insert into assignment values('" + eid + "','" + pid + "','" + stat + "')", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int i;
        //    i = e.RowIndex;
        //    lblPid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
        //    lblDos.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            lblPid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            lblDos.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            lblPid.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            lblDos.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

    }
}

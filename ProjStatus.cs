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
    public partial class ProjStatus : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public ProjStatus()
        {
            InitializeComponent();
        }

        private void ProjStatus_Load(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("Select EnquiryNo,EnqDate,StudentName,College,Degree,Dept,Year,MobileNo,MobileNo1,MailId,MailId1 from Enquiry where EnqDate='" + lblDate.Text + "' and status=0", con);
            cmd = new SqlCommand("Select projid,empid,status from assignment", con);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "assignment");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "assignment";

            string cnn = "Data Source=salemcrisp2;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection connection = new SqlConnection(cnn.ToString());

            SqlCommand command = new SqlCommand("Select pid FROM projects", connection);

            try
            {
                connection.Open();
                {
                    SqlDataReader drd = command.ExecuteReader();

                    while (drd.Read())
                    {
                        this.cmbPlist.Items.Add(drd.GetString(0) + "");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }

            connection.Close();
        }

        private void cmbPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("Select EnquiryNo,EnqDate,StudentName,College,Degree,Dept,Year,MobileNo,MobileNo1,MailId,MailId1 from Enquiry where EnqDate='" + lblDate.Text + "' and status=0", con);
            cmd = new SqlCommand("Select projid,empid,status from assignment where projid='"+cmbPlist.Text+"'", con);

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "assignment");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "assignment";
        }
    }
}

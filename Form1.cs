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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        string name, fid;
        public static String id;
        public Login()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Registration r1 = new Registration();
            r1.ShowDialog();
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            id = txtId.Text;
            string pwd = txtPwd.Text;

            if (id.Equals("admin"))
            {
                AddProjects objUI = new AddProjects();
                objUI.Show();
            }
            else
            {


                cmd = new SqlCommand("select * from register where emp_Id='" + id + "' and Password='" + pwd + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login success!");

                    MyProject objUI = new MyProject();
                    objUI.Show();

                }
                else
                {
                    MessageBox.Show("Invalid details!");
                }
                con.Close();
            }
        }
    }
}

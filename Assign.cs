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
    public partial class Assign : Form
    {

        SqlDataReader dr;
        SqlDataReader dr1;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();

        public Assign()
        {
            InitializeComponent();
        }

        private void Assign_Load(object sender, EventArgs e)
        {
            string cnn = "Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection connection = new SqlConnection(cnn.ToString());
            SqlCommand command = new SqlCommand("Select emp_Id FROM register", connection);

            try
            {
                connection.Open();
                {
                    SqlDataReader drd = command.ExecuteReader();

                    while (drd.Read())
                    {
                        this.cmbEassign.Items.Add(drd.GetString(0).ToString());
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
            connection.Close();
            command = new SqlCommand("Select pid FROM projects", connection);

            try
            {
                connection.Open();
                {
                    SqlDataReader drd = command.ExecuteReader();

                    while (drd.Read())
                    {
                        this.cmbPassign.Items.Add(drd.GetString(0)+"");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pid = cmbPassign.SelectedItem.ToString();
            String eid = cmbEassign.SelectedItem.ToString();

            cmd = new SqlCommand(" UPDATE projects  SET assign ='" + eid + "' Where pid ='" + pid + "'", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



        }
    }
}

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
    public partial class Registration : Form
    {
        string emp_Id, Cname, Address, Password, RePwd, DOB, Gender, Email, Mobile, City;
        string connString = "Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V5HGEU3\\SQLEXPRESS;Initial Catalog=ProjectTracking;Persist Security Info=True;User ID=sa;Password=123");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Int32 columnSize = 0;
        int i;

        public Registration()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            emp_Id = txtRid.Text;
            Cname = txtName.Text;
            Address = txtAddress.Text;
            Password = txtPass.Text;
            RePwd = txtRePass.Text;
            DOB = txtDOB.Text;
            Gender = cmbGender.Text;
            Email = txtMail.Text;
            Mobile = txtMobNo.Text;
            City = txtCity.Text;

            con.Open();
            string strQuery1 = "insert into register(emp_Id,Name,DOB,Address,City,Mobile,Gender,Email,Password,RePwd) values (@emp_Id,@Name,@DOB,@Address,@City,@Mobile,@Gender,@Email,@Password,@RePwd)";
            SqlCommand cmd1 = new SqlCommand(strQuery1, con);
            cmd1.Parameters.Add("@emp_Id", SqlDbType.VarChar).Value = emp_Id;
            cmd1.Parameters.Add("@Name", SqlDbType.VarChar).Value = Cname;
            cmd1.Parameters.Add("@DOB", SqlDbType.VarChar).Value = DOB;
            cmd1.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
            cmd1.Parameters.Add("@City", SqlDbType.VarChar).Value = City;

            cmd1.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = Mobile;
            cmd1.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            cmd1.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            cmd1.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            cmd1.Parameters.Add("@RePwd", SqlDbType.VarChar).Value = RePwd;

            cmd1.ExecuteNonQuery();
            con.Close();

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            string sql = "select COUNT(*) FROM [ProjectTracking].[dbo].[register]";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    columnSize = (Int32)cmd.ExecuteScalar();
                    txtRid.Text = "C" + (columnSize + 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
           
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }


    
    }
}

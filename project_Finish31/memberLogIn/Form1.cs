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

namespace memberLogIn
{
    public partial class Form1 : Form
    {
        public bool isLogin = false;
        public string userName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnJoinpage_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string bg = "Data Source=DESKTOP-OCL2P1H\\SQLEXPRESS;Initial Catalog=HomeWork;Integrated Security=True";
            using (SqlConnection cn = new SqlConnection(bg))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "select * from MemberDataTest where Account = @Account"; // and PassWord = '@p2'";
                        cmd.Parameters.AddWithValue("@Account", txtEmail.Text);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds, "memberAccount");
                        if (ds.Tables["memberAccount"].Rows.Count==1)
                        {
                            //cmd.CommandText = "select * from MemberDataTest where  PassWord =@p2";
                            //cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
                            //DataSet ds2 = new DataSet();
                            //da.Fill(ds2, "memberPw");
                            string passW = ds.Tables["memberAccount"].Rows[0]["PassWord"].ToString();

                            if (passW.Trim() == txtPassword.Text)
                            {
                                userName = ds.Tables["memberAccount"].Rows[0]["Name"].ToString();
                                MessageBox.Show($"歡迎{userName}，您已成功登入");
                                //Form3 form = new Form3();
                                //form.
                                isLogin = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("密碼錯誤！請重新輸入");
                            }
                        }
                        else
                        {
                            MessageBox.Show("查無該帳號，請重新輸入");
                        }
                    }
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text=="")
            {
                lblAccountF.Visible = true;
                lblAccountF.Enabled = true;
            }
            else
            {
                lblAccountF.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                lblPasswordF.Visible = true;
                lblPasswordF.Enabled = true;
            }
            else
            {
                lblPasswordF.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}

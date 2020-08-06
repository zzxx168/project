using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace memberLogIn
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtBirthday_MouseClick(object sender, MouseEventArgs e)
        {
            if (monthCalendar1.Visible == false)
            {
                monthCalendar1.Visible = true;
                monthCalendar1.Top = 90;
                monthCalendar1.Left = 240;
            }
            else
            {
                monthCalendar1.Visible = false;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //string DateTime = this.monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");
            string DateTime = this.monthCalendar1.SelectionStart.ToShortDateString();
            this.txtBirthday.Text = DateTime;
            this.monthCalendar1.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMemberJoin_Click(object sender, EventArgs e)
        {
            //帳號驗證
            if (IsValid(txtEmail.Text) == false)
            {
                MessageBox.Show("此Emai格式有誤，請重新確認");
                return;
            }
            string bg = "Data Source=DESKTOP-OCL2P1H\\SQLEXPRESS;Initial Catalog=HomeWork;Integrated Security=True";

            using (SqlConnection cn = new SqlConnection(bg))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    //判斷帳號有沒有被註冊過
                    cmd.Connection = cn;
                    cmd.CommandText = "Select Count(*)  From MemberDataTest Where Account = '＠Account'";
                    cmd.Parameters.AddWithValue("@Account", txtEmail.Text);
                    int MemberNum = (Int32)cmd.ExecuteScalar();
                    if (MemberNum > 0)
                    {
                        MessageBox.Show("此Email帳號已註冊，請想想密碼，或重新註冊一個");
                        return;
                    }

                    //手機檢查
                    if (txtPhone.Text.Length != 10 || txtPhone.Text == "")
                    {
                        lblPrompt.Text = "手機輸入格式錯誤，請重新輸入";
                        txtPhone.Focus();
                        return;
                    }
                    //密碼檢查
                    if (txtPassword.Text.Length < 8 || txtPassword.Text.Length > 10 || txtPassword.Text == "")
                    {
                        lblPrompt.Text = "密碼格式錯誤，請重新輸入";
                        txtPassword.Focus();
                        txtPassCheck.Text = string.Empty;
                        return;
                    }
                    //密碼檢查是否相符
                    if (txtPassCheck.Text != txtPassword.Text || txtPassCheck.Text == "")
                    {
                        lblPrompt.Text = "請再次輸入密碼";
                        txtPassCheck.Focus();
                        return;
                    }
                    //姓名檢查
                    if (txtName.Text.Length > 20 || txtName.Text == "")
                    {
                        lblPrompt.Text = "請輸入姓名";
                        txtName.Focus();
                        return;
                    }
                    //生日檢查
                    if (txtBirthday.Text.Length > 20 || txtBirthday.Text == "")
                    {
                        lblPrompt.Text = "請選取生日";
                        txtBirthday.Focus();
                        return;
                    }
                    //縣市檢查
                    if (cbxCity.SelectedIndex == 0)
                    {
                        lblPrompt.Text = "請選取居住縣市";
                        cbxCity.Focus();
                        return;
                    }


                    cmd.CommandText = $"insert into MemberDataTest " +
                        $"(Account,PassWord,Name,PhoneNumber,Gender,BirthDate,City,Status) " +
                        $"values(@Account, @PassWord, @Name, @PhoneNumber, @Gender, @BirthDate, @City,GETDATE()); ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Account", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@PassWord", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    if (rdbMale.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "M");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Gender", "F");
                    }
                    cmd.Parameters.AddWithValue("@BirthDate", txtBirthday.Text);
                    cmd.Parameters.AddWithValue("@City", cbxCity.SelectedItem);
                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        MessageBox.Show("您已註冊成功！");
                    }
                    else
                    {
                        MessageBox.Show("資料異常，請確認後重新註冊！");
                    }
                }
            }
        }
        public static bool IsValid(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請輸入8-10位數密碼";
                lblPrompt.Visible = true;
                lblPrompt.Enabled = true;
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }

        }

        private void txtPassCheck_TextChanged(object sender, EventArgs e)
        {
            if (txtPassCheck.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請再次輸入密碼";
                lblPrompt.Visible = true;
                lblPrompt.Enabled = true;
                if (txtPassword.Text == txtPassCheck.Text)
                {
                    label4.Text = "密碼相符";
                    lblPrompt.Text = string.Empty;
                }
                if (txtPassword.Text != txtPassCheck.Text)
                {
                    label4.Text = "密碼檢查";
                    lblPrompt.Text = "請再次輸入密碼";
                }
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請輸入要註冊的E-mail信箱";
                lblPrompt.Enabled = true;
                lblPrompt.Visible = true;
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }
        }


        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請輸入10位數手機號碼";
                lblPrompt.Enabled = true;
                lblPrompt.Visible = true;
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請輸入顯示使用者名稱";
                lblPrompt.Enabled = true;
                lblPrompt.Visible = true;
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }
        }

        private void txtBirthday_TextChanged(object sender, EventArgs e)
        {
            if (txtBirthday.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請選取生日";
                lblPrompt.Enabled = true;
                lblPrompt.Visible = true;
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }
        }

        private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBirthday.Focused == true)
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
                lblPrompt.Text = "請選取居住縣市";
                lblPrompt.Enabled = true;
                lblPrompt.Visible = true;
            }
            else
            {
                lblPrompt.Enabled = false;
                lblPrompt.Visible = false;
            }
        }
    }
}

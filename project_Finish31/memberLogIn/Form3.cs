using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memberLogIn
{
    public partial class Form3 : Form
    {
        bool isLogin = false;
        string userName = string.Empty;

        int[] outNum = new int[4] { 0, 0, 0, 0 };

        public Form3()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("猜數字遊戲開始");
            btnStart.Text = "重新開始新的猜數字";
            lblGuess.Enabled = true;
            lblHistory.Enabled = true;
            lblResult.Enabled = true;
            txtGuessHistory.Enabled = true;
            txtGuessNumber.Enabled = true;
            txtGuessResult.Enabled = true;
            btnSubmit.Enabled = true;
            txtGuessNumber.Focus();
            txtGuessHistory.Text = string.Empty;



            Random rd = new Random();
            outNum[0] = rd.Next(0, 10); //Next包含最小值，不包含最大值;
            outNum[1] = rd.Next(0, 10); //Next包含最小值，不包含最大值;
            outNum[2] = rd.Next(0, 10); //Next包含最小值，不包含最大值;
            outNum[3] = rd.Next(0, 10); //Next包含最小值，不包含最大值;

            while (outNum[1] == outNum[0])//亂數生成一組四位數不動複的數值開始
            {
                outNum[1] = rd.Next(0, 10);
            }
            while (outNum[2] == outNum[1] || outNum[2] == outNum[0])
            {
                outNum[2] = rd.Next(0, 10);
            }
            while (outNum[3] == outNum[2] || outNum[3] == outNum[1] || outNum[3] == outNum[0])
            {
                outNum[3] = rd.Next(0, 10);
            }

            txtGuessNumber.Text = string.Empty;
            txtGuessResult.Text = "請用0-9輸入四位不重複數字";
            btnSubmit.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "登入")
            {
                Form1 form = new Form1();
                form.ShowDialog();

                isLogin = form.isLogin;
                userName = form.userName;
                btnRegister.Visible = false;
                lblRegister.Visible = false;

                if (isLogin == true)
                {
                    btnStart.Enabled = true;
                    lblLogin.Text = "UserName :" + userName;
                    btnLogin.Text = "登出";
                }
            }
            else
            {
                btnStart.Visible = false;
                btnRegister.Visible = true;
                lblRegister.Visible = true;
                lblLogin.Text = "會員請先登入";
                btnLogin.Text = "登入";
                btnStart.Enabled = false;
                lblGuess.Enabled = false;
                lblHistory.Enabled = false;
                lblResult.Enabled = false;
                txtGuessHistory.Enabled = false;
                txtGuessHistory.Text = string.Empty;
                txtGuessNumber.Enabled = false;
                txtGuessNumber.Text = string.Empty;
                txtGuessResult.Enabled = false;
                txtGuessResult.Text = string.Empty;
                btnSubmit.Enabled = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string numIn = txtGuessNumber.Text;

            if ((numIn.Length != 4) || CheckDuplicate(numIn))
            {
                txtGuessResult.Text = "請重新使用0-9輸入不重複之四位數字";
                return;
            }

            int tmpValue = 0;
            if (int.TryParse(numIn, out tmpValue) == false)
            {
                txtGuessResult.Text = "所輸入的不是數字，請重新輸入";
                return;
            }

            int[] inNum = { 0, 0, 0, 0 };
            inNum[0] = Convert.ToInt32(numIn.Substring(0, 1));
            inNum[1] = Convert.ToInt32(numIn.Substring(1, 1));
            inNum[2] = Convert.ToInt32(numIn.Substring(2, 1));
            inNum[3] = Convert.ToInt32(numIn.Substring(3, 1));
            int addA = 0;
            int addB = 0;
            //int[] outNum = { temp1, temp2, temp3, temp4 };
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (inNum[i] == outNum[k])
                    {
                        if (i == k)
                            addA += 1;
                        else if (i != k)
                            addB += 1;
                    }
                }
            }

            if (addA == 4)
            {
                txtGuessResult.Text = $"你猜對了！正確數字是{inNum[0]}{inNum[1]}{ inNum[2]}{ inNum[3] }";
                btnSubmit.Enabled = false;
            }
            else
            {
                string tmp = $"你猜的{inNum[0]}{inNum[1]}{ inNum[2]}{ inNum[3] }結果是{ addA}A{addB }B";
                txtGuessResult.Text = tmp;
                txtGuessHistory.Text = tmp + System.Environment.NewLine + txtGuessHistory.Text;
                txtGuessNumber.Text = string.Empty;

            }
        }

        static bool CheckDuplicate(string value)
        {
            for (int i = 0; i < 3; ++i)
            {
                char c = value[i];

                if (value.LastIndexOf(c) != i)
                    return true;
            }

            return false;
        }
    }
}

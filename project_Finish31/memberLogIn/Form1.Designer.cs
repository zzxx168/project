namespace memberLogIn
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnJoinpage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPasswordF = new System.Windows.Forms.Label();
            this.lblAccountF = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(30, 64);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(61, 29);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "帳號";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 61);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(347, 36);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(30, 117);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 29);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "密碼";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(54, 190);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(167, 39);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登入";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 114);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(347, 36);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnJoinpage
            // 
            this.btnJoinpage.Location = new System.Drawing.Point(259, 190);
            this.btnJoinpage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnJoinpage.Name = "btnJoinpage";
            this.btnJoinpage.Size = new System.Drawing.Size(173, 39);
            this.btnJoinpage.TabIndex = 5;
            this.btnJoinpage.Text = "註冊會員";
            this.btnJoinpage.UseVisualStyleBackColor = true;
            this.btnJoinpage.Click += new System.EventHandler(this.btnJoinpage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPasswordF);
            this.groupBox1.Controls.Add(this.lblAccountF);
            this.groupBox1.Controls.Add(this.btnJoinpage);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.lblAccount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(487, 259);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "會員登入";
            // 
            // lblPasswordF
            // 
            this.lblPasswordF.AutoSize = true;
            this.lblPasswordF.BackColor = System.Drawing.SystemColors.Window;
            this.lblPasswordF.Location = new System.Drawing.Point(208, 117);
            this.lblPasswordF.Name = "lblPasswordF";
            this.lblPasswordF.Size = new System.Drawing.Size(179, 24);
            this.lblPasswordF.TabIndex = 7;
            this.lblPasswordF.Text = "請輸入8-10位數密碼";
            this.lblPasswordF.Click += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblAccountF
            // 
            this.lblAccountF.AutoSize = true;
            this.lblAccountF.BackColor = System.Drawing.SystemColors.Window;
            this.lblAccountF.Location = new System.Drawing.Point(208, 64);
            this.lblAccountF.Name = "lblAccountF";
            this.lblAccountF.Size = new System.Drawing.Size(177, 24);
            this.lblAccountF.TabIndex = 6;
            this.lblAccountF.Text = "請輸入註冊的E-mail";
            this.lblAccountF.Click += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 303);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnJoinpage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPasswordF;
        private System.Windows.Forms.Label lblAccountF;
    }
}


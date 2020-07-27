namespace memberLogIn
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtGuessResult = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtGuessNumber = new System.Windows.Forms.TextBox();
            this.lblGuess = new System.Windows.Forms.Label();
            this.txtGuessHistory = new System.Windows.Forms.TextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(109, 149);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(204, 71);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(264, 38);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 28);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登入";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(33, 38);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(124, 24);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "會員請先登入";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(264, 82);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 28);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "註冊";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.Location = new System.Drawing.Point(33, 82);
            this.lblRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(143, 24);
            this.lblRegister.TabIndex = 4;
            this.lblRegister.Text = "非會員請先註冊";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Enabled = false;
            this.lblResult.Location = new System.Drawing.Point(37, 298);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(38, 16);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "結果";
            // 
            // txtGuessResult
            // 
            this.txtGuessResult.Enabled = false;
            this.txtGuessResult.Location = new System.Drawing.Point(89, 295);
            this.txtGuessResult.Name = "txtGuessResult";
            this.txtGuessResult.ReadOnly = true;
            this.txtGuessResult.Size = new System.Drawing.Size(275, 22);
            this.txtGuessResult.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(264, 240);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 33);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "送出";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtGuessNumber
            // 
            this.txtGuessNumber.Enabled = false;
            this.txtGuessNumber.Location = new System.Drawing.Point(89, 247);
            this.txtGuessNumber.Multiline = true;
            this.txtGuessNumber.Name = "txtGuessNumber";
            this.txtGuessNumber.Size = new System.Drawing.Size(87, 26);
            this.txtGuessNumber.TabIndex = 8;
            // 
            // lblGuess
            // 
            this.lblGuess.AutoSize = true;
            this.lblGuess.Enabled = false;
            this.lblGuess.Location = new System.Drawing.Point(22, 250);
            this.lblGuess.Name = "lblGuess";
            this.lblGuess.Size = new System.Drawing.Size(53, 16);
            this.lblGuess.TabIndex = 9;
            this.lblGuess.Text = "猜數字";
            // 
            // txtGuessHistory
            // 
            this.txtGuessHistory.Enabled = false;
            this.txtGuessHistory.Location = new System.Drawing.Point(89, 337);
            this.txtGuessHistory.Multiline = true;
            this.txtGuessHistory.Name = "txtGuessHistory";
            this.txtGuessHistory.ReadOnly = true;
            this.txtGuessHistory.Size = new System.Drawing.Size(275, 135);
            this.txtGuessHistory.TabIndex = 10;
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Enabled = false;
            this.lblHistory.Location = new System.Drawing.Point(36, 340);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(38, 16);
            this.lblHistory.TabIndex = 11;
            this.lblHistory.Text = "記錄";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 514);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.txtGuessHistory);
            this.Controls.Add(this.lblGuess);
            this.Controls.Add(this.txtGuessNumber);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtGuessResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtGuessResult;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtGuessNumber;
        private System.Windows.Forms.Label lblGuess;
        private System.Windows.Forms.TextBox txtGuessHistory;
        private System.Windows.Forms.Label lblHistory;
    }
}
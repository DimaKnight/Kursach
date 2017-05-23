namespace WindowsFormsApplication5
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.ButReg = new System.Windows.Forms.Button();
            this.ButEnter = new System.Windows.Forms.Button();
            this.WrName = new System.Windows.Forms.TextBox();
            this.WrPass = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Label();
            this.Enter1 = new System.Windows.Forms.Label();
            this.Okenter = new System.Windows.Forms.Button();
            this.Reges = new System.Windows.Forms.Label();
            this.Reges1 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.Okreg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButReg
            // 
            this.ButReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButReg.Location = new System.Drawing.Point(70, 109);
            this.ButReg.Name = "ButReg";
            this.ButReg.Size = new System.Drawing.Size(100, 26);
            this.ButReg.TabIndex = 0;
            this.ButReg.Text = "Регистрация";
            this.ButReg.UseVisualStyleBackColor = true;
            this.ButReg.Click += new System.EventHandler(this.Reg);
            // 
            // ButEnter
            // 
            this.ButEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButEnter.Location = new System.Drawing.Point(70, 65);
            this.ButEnter.Name = "ButEnter";
            this.ButEnter.Size = new System.Drawing.Size(100, 25);
            this.ButEnter.TabIndex = 1;
            this.ButEnter.Text = "Вход";
            this.ButEnter.UseVisualStyleBackColor = true;
            this.ButEnter.Click += new System.EventHandler(this.LogIn);
            // 
            // WrName
            // 
            this.WrName.Location = new System.Drawing.Point(70, 65);
            this.WrName.Name = "WrName";
            this.WrName.Size = new System.Drawing.Size(100, 20);
            this.WrName.TabIndex = 2;
            // 
            // WrPass
            // 
            this.WrPass.Location = new System.Drawing.Point(70, 109);
            this.WrPass.Name = "WrPass";
            this.WrPass.Size = new System.Drawing.Size(100, 20);
            this.WrPass.TabIndex = 3;
            this.WrPass.UseSystemPasswordChar = true;
            // 
            // Enter
            // 
            this.Enter.AutoSize = true;
            this.Enter.Location = new System.Drawing.Point(62, 49);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(108, 13);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "Введите свой логин";
            // 
            // Enter1
            // 
            this.Enter1.AutoSize = true;
            this.Enter1.Location = new System.Drawing.Point(62, 91);
            this.Enter1.Name = "Enter1";
            this.Enter1.Size = new System.Drawing.Size(115, 13);
            this.Enter1.TabIndex = 5;
            this.Enter1.Text = "Введите свой пароль";
            // 
            // Okenter
            // 
            this.Okenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Okenter.Location = new System.Drawing.Point(147, 162);
            this.Okenter.Name = "Okenter";
            this.Okenter.Size = new System.Drawing.Size(75, 23);
            this.Okenter.TabIndex = 6;
            this.Okenter.Text = "Ok";
            this.Okenter.UseVisualStyleBackColor = true;
            this.Okenter.Click += new System.EventHandler(this.OkLogIn);
            // 
            // Reges
            // 
            this.Reges.AutoSize = true;
            this.Reges.Location = new System.Drawing.Point(62, 49);
            this.Reges.Name = "Reges";
            this.Reges.Size = new System.Drawing.Size(116, 13);
            this.Reges.TabIndex = 7;
            this.Reges.Text = "Введите новый логин";
            // 
            // Reges1
            // 
            this.Reges1.AutoSize = true;
            this.Reges1.Location = new System.Drawing.Point(62, 93);
            this.Reges1.Name = "Reges1";
            this.Reges1.Size = new System.Drawing.Size(123, 13);
            this.Reges1.TabIndex = 8;
            this.Reges1.Text = "Введите новый пароль";
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Location = new System.Drawing.Point(26, 162);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 9;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.Back);
            // 
            // Okreg
            // 
            this.Okreg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Okreg.Location = new System.Drawing.Point(147, 162);
            this.Okreg.Name = "Okreg";
            this.Okreg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Okreg.Size = new System.Drawing.Size(75, 23);
            this.Okreg.TabIndex = 10;
            this.Okreg.Text = "Ok";
            this.Okreg.UseVisualStyleBackColor = true;
            this.Okreg.Click += new System.EventHandler(this.OkReg);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 212);
            this.Controls.Add(this.Okreg);
            this.Controls.Add(this.back);
            this.Controls.Add(this.Reges1);
            this.Controls.Add(this.Reges);
            this.Controls.Add(this.Okenter);
            this.Controls.Add(this.Enter1);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.WrPass);
            this.Controls.Add(this.WrName);
            this.Controls.Add(this.ButEnter);
            this.Controls.Add(this.ButReg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(264, 250);
            this.MinimumSize = new System.Drawing.Size(264, 250);
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogInForm_Closing);
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogInForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox WrName;
        private System.Windows.Forms.TextBox WrPass;
        private System.Windows.Forms.Label Enter;
        private System.Windows.Forms.Label Enter1;
        private System.Windows.Forms.Button Okenter;
        private System.Windows.Forms.Label Reges;
        private System.Windows.Forms.Label Reges1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button Okreg;
        public System.Windows.Forms.Button ButReg;
        public System.Windows.Forms.Button ButEnter;
    }
}
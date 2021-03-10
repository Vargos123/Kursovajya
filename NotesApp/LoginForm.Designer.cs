namespace NotesApp
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.hide = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.createAcc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butLogin = new System.Windows.Forms.Button();
            this.passF = new System.Windows.Forms.TextBox();
            this.loginF = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::NotesApp.Properties.Resources.Login1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.hide);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.createAcc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.butLogin);
            this.panel1.Controls.Add(this.passF);
            this.panel1.Controls.Add(this.loginF);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 605);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(168, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "Войти без Логина";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // hide
            // 
            this.hide.BackColor = System.Drawing.Color.Transparent;
            this.hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide.ForeColor = System.Drawing.Color.White;
            this.hide.Location = new System.Drawing.Point(410, 2);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(24, 22);
            this.hide.TabIndex = 29;
            this.hide.Text = "-";
            this.hide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            this.hide.MouseEnter += new System.EventHandler(this.hide_MouseEnter);
            this.hide.MouseLeave += new System.EventHandler(this.hide_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(356, 352);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(22, 13);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "/32";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(330, 352);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.Size = new System.Drawing.Size(26, 13);
            this.richTextBox1.TabIndex = 30;
            this.richTextBox1.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(356, 242);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(22, 13);
            this.textBox4.TabIndex = 29;
            this.textBox4.Text = "/16";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox2.Location = new System.Drawing.Point(330, 242);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox2.Size = new System.Drawing.Size(26, 13);
            this.richTextBox2.TabIndex = 28;
            this.richTextBox2.Text = "0";
            // 
            // createAcc
            // 
            this.createAcc.AutoSize = true;
            this.createAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createAcc.ForeColor = System.Drawing.Color.White;
            this.createAcc.Location = new System.Drawing.Point(173, 532);
            this.createAcc.Name = "createAcc";
            this.createAcc.Size = new System.Drawing.Size(141, 18);
            this.createAcc.TabIndex = 8;
            this.createAcc.Text = "Создать аккаунт";
            this.createAcc.Click += new System.EventHandler(this.createAcc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(82)))), ((int)(((byte)(222)))));
            this.label2.Location = new System.Drawing.Point(128, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 34);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(82)))), ((int)(((byte)(222)))));
            this.label1.Location = new System.Drawing.Point(128, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "Login";
            // 
            // butLogin
            // 
            this.butLogin.BackColor = System.Drawing.Color.Transparent;
            this.butLogin.BackgroundImage = global::NotesApp.Properties.Resources.Вход1;
            this.butLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLogin.FlatAppearance.BorderSize = 0;
            this.butLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(55)))), ((int)(((byte)(128)))));
            this.butLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(186)))));
            this.butLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLogin.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butLogin.Location = new System.Drawing.Point(150, 470);
            this.butLogin.Name = "butLogin";
            this.butLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butLogin.Size = new System.Drawing.Size(186, 53);
            this.butLogin.TabIndex = 3;
            this.butLogin.UseVisualStyleBackColor = false;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // passF
            // 
            this.passF.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passF.Location = new System.Drawing.Point(134, 364);
            this.passF.MaxLength = 32;
            this.passF.Name = "passF";
            this.passF.Size = new System.Drawing.Size(245, 39);
            this.passF.TabIndex = 2;
            this.passF.UseSystemPasswordChar = true;
            this.passF.TextChanged += new System.EventHandler(this.passF_TextChanged);
            // 
            // loginF
            // 
            this.loginF.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.loginF.Location = new System.Drawing.Point(134, 254);
            this.loginF.MaxLength = 16;
            this.loginF.Multiline = true;
            this.loginF.Name = "loginF";
            this.loginF.Size = new System.Drawing.Size(245, 37);
            this.loginF.TabIndex = 1;
            this.loginF.TextChanged += new System.EventHandler(this.loginF_TextChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(444, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 22);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(474, 605);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.TextBox passF;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label createAcc;
        public System.Windows.Forms.TextBox loginF;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label hide;
        private System.Windows.Forms.Label label3;
    }
}
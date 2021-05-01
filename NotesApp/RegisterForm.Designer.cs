
namespace NotesApp
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.hide = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passF = new System.Windows.Forms.TextBox();
            this.loginF = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.goToLogin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butRegister = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.emailF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hide
            // 
            this.hide.BackColor = System.Drawing.Color.Transparent;
            this.hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.hide.ForeColor = System.Drawing.Color.White;
            this.hide.Location = new System.Drawing.Point(409, 3);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(24, 22);
            this.hide.TabIndex = 30;
            this.hide.Text = "-";
            this.hide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            this.hide.MouseEnter += new System.EventHandler(this.hide_MouseEnter);
            this.hide.MouseLeave += new System.EventHandler(this.hide_MouseLeave);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(443, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 22);
            this.CloseButton.TabIndex = 29;
            this.CloseButton.Text = "X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(82)))), ((int)(((byte)(222)))));
            this.label2.Location = new System.Drawing.Point(124, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 34);
            this.label2.TabIndex = 32;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(82)))), ((int)(((byte)(222)))));
            this.label1.Location = new System.Drawing.Point(123, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 34);
            this.label1.TabIndex = 31;
            this.label1.Text = "Login";
            // 
            // passF
            // 
            this.passF.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passF.Location = new System.Drawing.Point(128, 368);
            this.passF.MaxLength = 32;
            this.passF.Name = "passF";
            this.passF.Size = new System.Drawing.Size(270, 39);
            this.passF.TabIndex = 2;
            this.passF.UseSystemPasswordChar = true;
            this.passF.TextChanged += new System.EventHandler(this.passF_TextChanged);
            // 
            // loginF
            // 
            this.loginF.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginF.Location = new System.Drawing.Point(128, 286);
            this.loginF.MaxLength = 16;
            this.loginF.Multiline = true;
            this.loginF.Name = "loginF";
            this.loginF.Size = new System.Drawing.Size(270, 39);
            this.loginF.TabIndex = 1;
            this.loginF.TextChanged += new System.EventHandler(this.loginF_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(375, 356);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(22, 13);
            this.textBox1.TabIndex = 38;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "/32";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(349, 356);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.Size = new System.Drawing.Size(26, 13);
            this.richTextBox1.TabIndex = 37;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(375, 274);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(22, 13);
            this.textBox4.TabIndex = 36;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "/16";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox2.Location = new System.Drawing.Point(349, 274);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox2.Size = new System.Drawing.Size(26, 13);
            this.richTextBox2.TabIndex = 35;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "0";
            // 
            // goToLogin
            // 
            this.goToLogin.AutoSize = true;
            this.goToLogin.BackColor = System.Drawing.Color.Transparent;
            this.goToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goToLogin.ForeColor = System.Drawing.Color.White;
            this.goToLogin.Location = new System.Drawing.Point(282, 528);
            this.goToLogin.Name = "goToLogin";
            this.goToLogin.Size = new System.Drawing.Size(55, 18);
            this.goToLogin.TabIndex = 4;
            this.goToLogin.Text = "Войти";
            this.goToLogin.Click += new System.EventHandler(this.goToLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(161, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Есть аккаунт?";
            // 
            // butRegister
            // 
            this.butRegister.BackColor = System.Drawing.Color.Transparent;
            this.butRegister.BackgroundImage = global::NotesApp.Properties.Resources.Регистр;
            this.butRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butRegister.FlatAppearance.BorderSize = 0;
            this.butRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(55)))), ((int)(((byte)(128)))));
            this.butRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(186)))));
            this.butRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRegister.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butRegister.Location = new System.Drawing.Point(150, 470);
            this.butRegister.Name = "butRegister";
            this.butRegister.Size = new System.Drawing.Size(192, 53);
            this.butRegister.TabIndex = 3;
            this.butRegister.UseVisualStyleBackColor = false;
            this.butRegister.Click += new System.EventHandler(this.butRegister_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(368, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(29, 13);
            this.textBox2.TabIndex = 45;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "/200";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox3.Location = new System.Drawing.Point(343, 195);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox3.Size = new System.Drawing.Size(25, 13);
            this.richTextBox3.TabIndex = 44;
            this.richTextBox3.TabStop = false;
            this.richTextBox3.Text = "0";
            // 
            // emailF
            // 
            this.emailF.Font = new System.Drawing.Font("Times New Roman", 20.25F);
            this.emailF.Location = new System.Drawing.Point(129, 207);
            this.emailF.MaxLength = 200;
            this.emailF.Name = "emailF";
            this.emailF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.emailF.Size = new System.Drawing.Size(269, 39);
            this.emailF.TabIndex = 0;
            this.emailF.TextChanged += new System.EventHandler(this.emailF_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(82)))), ((int)(((byte)(222)))));
            this.label4.Location = new System.Drawing.Point(124, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 34);
            this.label4.TabIndex = 42;
            this.label4.Text = "Email";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NotesApp.Properties.Resources.Регистрация;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(474, 605);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.emailF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.goToLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butRegister);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.passF);
            this.Controls.Add(this.loginF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RF_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RF_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hide;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passF;
        private System.Windows.Forms.TextBox loginF;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label goToLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butRegister;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.TextBox emailF;
        private System.Windows.Forms.Label label4;
    }
}
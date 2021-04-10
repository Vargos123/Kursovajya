
namespace NotesApp
{
    partial class EmailConf
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
            this.confirms = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.goToLogin = new System.Windows.Forms.Label();
            this.CloseBttn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirms
            // 
            this.confirms.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirms.Location = new System.Drawing.Point(12, 35);
            this.confirms.MaxLength = 4;
            this.confirms.Multiline = true;
            this.confirms.Name = "confirms";
            this.confirms.Size = new System.Drawing.Size(76, 35);
            this.confirms.TabIndex = 34;
            this.confirms.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "Введите код подтверждения";
            // 
            // goToLogin
            // 
            this.goToLogin.AutoSize = true;
            this.goToLogin.BackColor = System.Drawing.Color.Transparent;
            this.goToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goToLogin.ForeColor = System.Drawing.Color.White;
            this.goToLogin.Location = new System.Drawing.Point(100, 40);
            this.goToLogin.Name = "goToLogin";
            this.goToLogin.Size = new System.Drawing.Size(158, 18);
            this.goToLogin.TabIndex = 42;
            this.goToLogin.Text = "Отправить ещё раз";
            this.goToLogin.Click += new System.EventHandler(this.goToLogin_Click);
            // 
            // CloseBttn
            // 
            this.CloseBttn.Location = new System.Drawing.Point(183, 80);
            this.CloseBttn.Name = "CloseBttn";
            this.CloseBttn.Size = new System.Drawing.Size(75, 23);
            this.CloseBttn.TabIndex = 43;
            this.CloseBttn.Text = "Отмена";
            this.CloseBttn.UseVisualStyleBackColor = true;
            this.CloseBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmailConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NotesApp.Properties.Resources.Main;
            this.ClientSize = new System.Drawing.Size(270, 114);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CloseBttn);
            this.Controls.Add(this.goToLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.confirms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmailConf";
            this.Text = "EmailConf";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmailConf_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EmailConf_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox confirms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label goToLogin;
        private System.Windows.Forms.Button CloseBttn;
        private System.Windows.Forms.Button button1;
    }
}
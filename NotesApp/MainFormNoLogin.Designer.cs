namespace NotesApp
{
    partial class MainFormNoLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormNoLogin));
            this.hide = new System.Windows.Forms.Label();
            this.bttExit = new System.Windows.Forms.Button();
            this.bttDelAll = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.bttFind = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Label();
            this.bttRead = new System.Windows.Forms.Button();
            this.bttNew = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.bttSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttDelete = new System.Windows.Forms.Button();
            this.bttReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // hide
            // 
            this.hide.BackColor = System.Drawing.Color.Transparent;
            this.hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hide.ForeColor = System.Drawing.Color.White;
            this.hide.Location = new System.Drawing.Point(717, 2);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(28, 26);
            this.hide.TabIndex = 49;
            this.hide.Text = "-";
            this.hide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            this.hide.MouseEnter += new System.EventHandler(this.hide_MouseEnter);
            this.hide.MouseLeave += new System.EventHandler(this.hide_MouseLeave);
            // 
            // bttExit
            // 
            this.bttExit.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttExit.Location = new System.Drawing.Point(667, 401);
            this.bttExit.Name = "bttExit";
            this.bttExit.Size = new System.Drawing.Size(76, 25);
            this.bttExit.TabIndex = 47;
            this.bttExit.Text = "Выйти";
            this.bttExit.UseVisualStyleBackColor = false;
            this.bttExit.Click += new System.EventHandler(this.bttExit_Click);
            // 
            // bttDelAll
            // 
            this.bttDelAll.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttDelAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttDelAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttDelAll.Location = new System.Drawing.Point(516, 432);
            this.bttDelAll.Name = "bttDelAll";
            this.bttDelAll.Size = new System.Drawing.Size(87, 26);
            this.bttDelAll.TabIndex = 46;
            this.bttDelAll.Text = "Очистить все";
            this.bttDelAll.UseVisualStyleBackColor = false;
            this.bttDelAll.Click += new System.EventHandler(this.bttDelAll_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(95)))), ((int)(((byte)(188)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(227, 98);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(22, 13);
            this.textBox4.TabIndex = 45;
            this.textBox4.Text = "/50";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(95)))), ((int)(((byte)(188)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox2.Location = new System.Drawing.Point(201, 98);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox2.Size = new System.Drawing.Size(26, 13);
            this.richTextBox2.TabIndex = 44;
            this.richTextBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(95)))), ((int)(((byte)(188)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(711, 182);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(32, 13);
            this.textBox3.TabIndex = 43;
            this.textBox3.Text = "/500";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(95)))), ((int)(((byte)(188)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(685, 182);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.Size = new System.Drawing.Size(26, 13);
            this.richTextBox1.TabIndex = 42;
            this.richTextBox1.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::NotesApp.Properties.Resources.Сообщение;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(331, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(412, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::NotesApp.Properties.Resources.Название;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(53, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.HotPink;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Location = new System.Drawing.Point(609, 210);
            this.textBoxSearch.MaxLength = 50;
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(134, 25);
            this.textBoxSearch.TabIndex = 39;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // bttFind
            // 
            this.bttFind.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttFind.Location = new System.Drawing.Point(639, 241);
            this.bttFind.Name = "bttFind";
            this.bttFind.Size = new System.Drawing.Size(104, 36);
            this.bttFind.TabIndex = 38;
            this.bttFind.Text = "Найти";
            this.bttFind.UseVisualStyleBackColor = false;
            this.bttFind.Click += new System.EventHandler(this.bttFind_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(748, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(27, 21);
            this.CloseButton.TabIndex = 37;
            this.CloseButton.Text = "X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // bttRead
            // 
            this.bttRead.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttRead.Location = new System.Drawing.Point(639, 283);
            this.bttRead.Name = "bttRead";
            this.bttRead.Size = new System.Drawing.Size(104, 36);
            this.bttRead.TabIndex = 35;
            this.bttRead.Text = "Прочитать";
            this.bttRead.UseVisualStyleBackColor = false;
            this.bttRead.Click += new System.EventHandler(this.bttRead_Click);
            // 
            // bttNew
            // 
            this.bttNew.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttNew.Location = new System.Drawing.Point(53, 104);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(119, 36);
            this.bttNew.TabIndex = 34;
            this.bttNew.Text = "Создать";
            this.bttNew.UseVisualStyleBackColor = false;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.Color.HotPink;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageBox.Location = new System.Drawing.Point(331, 62);
            this.messageBox.MaxLength = 500;
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(412, 120);
            this.messageBox.TabIndex = 33;
            this.messageBox.TextChanged += new System.EventHandler(this.messageBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.Color.HotPink;
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(53, 62);
            this.nameBox.MaxLength = 50;
            this.nameBox.Multiline = true;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(196, 36);
            this.nameBox.TabIndex = 32;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // bttSave
            // 
            this.bttSave.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttSave.Location = new System.Drawing.Point(53, 146);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(119, 36);
            this.bttSave.TabIndex = 31;
            this.bttSave.Text = "Добавить";
            this.bttSave.UseVisualStyleBackColor = false;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.HotPink;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Message});
            this.dataGridView1.Location = new System.Drawing.Point(53, 210);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 216);
            this.dataGridView1.TabIndex = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 25;
            // 
            // Title
            // 
            this.Title.HeaderText = "Название";
            this.Title.MaxInputLength = 50;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Message.HeaderText = "Сообщение";
            this.Message.MaxInputLength = 500;
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // bttDelete
            // 
            this.bttDelete.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttDelete.Location = new System.Drawing.Point(654, 325);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(89, 26);
            this.bttDelete.TabIndex = 53;
            this.bttDelete.Text = "Очистить";
            this.bttDelete.UseVisualStyleBackColor = false;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttReload
            // 
            this.bttReload.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bttReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttReload.Location = new System.Drawing.Point(178, 117);
            this.bttReload.Name = "bttReload";
            this.bttReload.Size = new System.Drawing.Size(71, 23);
            this.bttReload.TabIndex = 54;
            this.bttReload.Text = "Обновить";
            this.bttReload.UseVisualStyleBackColor = false;
            this.bttReload.Click += new System.EventHandler(this.bttReload_Click);
            // 
            // MainFormNoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NotesApp.Properties.Resources.Main;
            this.ClientSize = new System.Drawing.Size(785, 463);
            this.Controls.Add(this.bttReload);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.bttExit);
            this.Controls.Add(this.bttDelAll);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.bttFind);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.bttRead);
            this.Controls.Add(this.bttNew);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormNoLogin";
            this.Text = "MainFormNoLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormNoLogin_FormClosed);
            this.Load += new System.EventHandler(this.MainFormNoLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFormNoLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormNoLogin_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hide;
        private System.Windows.Forms.Button bttExit;
        private System.Windows.Forms.Button bttDelAll;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button bttFind;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.Button bttRead;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}
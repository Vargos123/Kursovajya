using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class ReadEdit : Form
    {
        DataB db = new DataB();
        public ReadEdit(string nameBox, string messageBox, int index, string log)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.nameBox = nameBox;
            this.messageBox = messageBox;
            this.index = index;
            this.log = log;
            LoadData();
        }
        string nameBox, messageBox, log;
        int index;

        private void LoadData()
        {
            message.ReadOnly = true;
            name.ReadOnly = true;
            name.Text = nameBox;
            message.Text = messageBox;         
        }

        Point lastPoint;
        private void ReadEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black; // черный крестик при наводе мышкой
        }
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White; // белый крестик
        }
        private void hide_MouseEnter(object sender, EventArgs e)
        {
            hide.ForeColor = Color.Black; // черный - при наводе мышкой на 
        }
        private void hide_MouseLeave(object sender, EventArgs e)
        {
            hide.ForeColor = Color.White; // белый -
        }
        private void name_TextChanged(object sender, EventArgs e)
        {
            name.ScrollBars = ScrollBars.Vertical;
            richTextBox2.Text = name.Text.Length.ToString();
        }
        private void message_TextChanged(object sender, EventArgs e)
        {
            message.ScrollBars = ScrollBars.Vertical;

            richTextBox1.Text = message.Text.Length.ToString();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        private void bttEdit_Click(object sender, EventArgs e)
        {           
            message.ReadOnly = false;
            name.ReadOnly = false;
        }
        private void ReadEdit_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void bttSave_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `" + log + "` SET Title = @title, Message = @message WHERE id = @Id", db.getConn()); // Удаляем выделенную строку по индексу
            command.Parameters.AddWithValue("title", name.Text);
            command.Parameters.AddWithValue("message", message.Text);
            command.Parameters.AddWithValue("Id", index);
            db.openConn();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно обновлили данные!");
            }
            else
                MessageBox.Show("Вы не смогли обновить данные!");
            db.closeConn();
            
        }

        private void hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

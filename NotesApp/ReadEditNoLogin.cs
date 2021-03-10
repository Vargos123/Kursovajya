using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class ReadEditNoLogin : Form
    {
        SqlConnection sqlConnection;
        public ReadEditNoLogin(string nameBox, string messageBox, int index)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.nameBox = nameBox;
            this.messageBox = messageBox;
            this.index = index;
            LoadData();
        }
        string nameBox, messageBox;
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
            if (name.TextLength == 50)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 50");               
            }
        }

        private void message_TextChanged(object sender, EventArgs e)
        {
            message.ScrollBars = ScrollBars.Vertical;

            richTextBox1.Text = message.Text.Length.ToString();

            if (message.TextLength == 500)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 500");
                
            }
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

        private void ReadEditNoLogin_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void ReadEditNoLogin_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);            
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE [Table] SET [Title]=@Title, [Message]=@Message WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", index);
            command.Parameters.AddWithValue("Title", name.Text);
            command.Parameters.AddWithValue("Message", message.Text);
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

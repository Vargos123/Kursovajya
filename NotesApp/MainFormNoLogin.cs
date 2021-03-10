using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;

namespace NotesApp
{
    public partial class MainFormNoLogin : Form
    {
        SqlConnection sqlConnection;
        SqlDataReader reader;

        public MainFormNoLogin()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }               
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите выйти? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Выход", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
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
        private void hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void MainFormNoLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainFormNoLogin_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }



        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.TextLength == 50)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 50!");
                return;
            }
        }

        private void bttFind_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                if (textBoxSearch.Text == "")
                {
                    MessageBox.Show("Вы не ввели данные для поиска.");
                    return;
                }
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBoxSearch.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            else
            {
                MessageBox.Show("Нет записей для поиска. Добавьте записи!");
                return;
            }
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int n = dataGridView1.CurrentCell.RowIndex;
                string name = (string)dataGridView1.Rows[n].Cells[1].Value;
                string message = (string)dataGridView1.Rows[n].Cells[2].Value;
                int index = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                ReadEditNoLogin readE = new ReadEditNoLogin(name, message, index);
                readE.ShowDialog();
            }
            else
            {
                MessageBox.Show("Нет записей для чтения. Добавьте записи!");
                return;
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выделенную запись?", "Удаление", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            else
            {
                MessageBox.Show("Нет записей для удаления!");
                return;
            }
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            bttAndTextVisible();
            nameBox.Clear();
            messageBox.Clear();            
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите выйти? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Выход", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.Hide();
                    LoginForm logF = new LoginForm();
                    logF.Show();
                }
            }
            else
            {
                this.Hide();
                LoginForm logF = new LoginForm();
                logF.Show();
            }            
        }    


        private void bttSave_Click(object sender, EventArgs e)
        {          
            try
            {
                if (dataGridView1.Rows.Count == 100)
                {
                    MessageBox.Show("Вы не можете добавить больше 100 записей!");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBox.Show("Вы не ввели Название!");
                    return;
                }
                else if (nameBox.TextLength > 50)
                {
                    MessageBox.Show("Длина Названия превышает допустимую норму. Максимальная длина 50 символов.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(messageBox.Text))
                {
                    MessageBox.Show("Вы не ввели Сообщение!");
                    return;
                }
                else
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Table] (Title, Message) VALUES (@Title, @Message)", sqlConnection);
                    command.Parameters.AddWithValue("Title", nameBox.Text);
                    command.Parameters.AddWithValue("Message", messageBox.Text);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Вы успешно добавили данные");
                    ReloadData();
                    nameBox.Clear();
                    messageBox.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить данные.");
                return;
            }
        }

        private void bttDelAll_Click(object sender, EventArgs e)
        {
            bttAndTextVisible();

            if (dataGridView1.RowCount > 0)
            {
                    if (MessageBox.Show("Вы действительно хотите удалить все записи?", "Удаление", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        dataGridView1.Rows.Clear();
                        SqlCommand command = new SqlCommand("TRUNCATE TABLE [Table]", sqlConnection);
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                        MessageBox.Show("Все записи были успешно удаленны!");
                    }
            }
            else
            {
                MessageBox.Show("Нет записей для удаления!");
                return;
            }
        }
        private void bttAndTextVisible()
        {
            bttReload.Visible = true;
            bttSave.Visible = true;
            messageBox.ReadOnly = false;
            nameBox.ReadOnly = false;
        }

        

        private void bttEdit_Click(object sender, EventArgs e)
        {
            bttAndTextVisible();
            if (dataGridView1.RowCount > 0)
            {
                SqlCommand command = new SqlCommand("UPDATE [Table] SET [Title]=@Title, [Message]=@Message WHERE [Id]=@Id", sqlConnection);
                int x = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                command.Parameters.AddWithValue("Id", x);
                command.Parameters.AddWithValue("Title", nameBox.Text);
                command.Parameters.AddWithValue("Message", messageBox.Text);
                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
                ReloadData();
                MessageBox.Show("Вы успешно редактировали данные!");

            }
            else
            {
                MessageBox.Show("Нет записей для редактирования. Добавьте записи!");
                return;
            }
        }

        private void bttDelete_Click_1(object sender, EventArgs e)
        {
            bttAndTextVisible();
            if (dataGridView1.RowCount > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выделенную запись?", "Удаление", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {                    
                    SqlCommand command = new SqlCommand("DELETE FROM [Table] WHERE id = @Id", sqlConnection); // Удаляем строку по индексу
                    string x = (string)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                    command.Parameters.AddWithValue("Id", x);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    ReloadData();
                }
            }
            else
            {
                MessageBox.Show("Нет записей для удаления!");
                return;
            }
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {
            messageBox.ScrollBars = ScrollBars.Vertical;

            richTextBox1.Text = messageBox.Text.Length.ToString();

            if (messageBox.TextLength == 500)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 500");
                return;
            }
        }

        private void MainFormNoLogin_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            sqlConnection.Open();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Table] ORDER BY id", sqlConnection);
                reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();

                }
                reader.Close();
                sqlConnection.Close();
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
            catch
            {
                this.Close();
                LoginForm logF = new LoginForm();
                logF.Show();
                MessageBox.Show("Непредвиденная ошибка!");
            }
        }

        private void ReloadData()
        {
            dataGridView1.Rows.Clear();
            sqlConnection.Open();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void saveEdit_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            nameBox.ScrollBars = ScrollBars.Vertical;
            richTextBox2.Text = nameBox.Text.Length.ToString();
            if (nameBox.TextLength == 50)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 50");
            }
        }
    }
}

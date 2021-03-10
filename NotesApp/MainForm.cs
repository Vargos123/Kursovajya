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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class MainForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server = remotemysql.com; port = 3306; Username = ed5dW7gcoL; Password = 0Gm5En5jkl; database = ed5dW7gcoL; charset = utf8");
        DataB db = new DataB();
        MySqlCommand command;
        MySqlDataReader reader;

        public MainForm(string log)
        {
            // Стартовая позиция по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            this.log = log;
            LoadData();
        }
        string log;

        private void LoadData()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM  `" + log + "` ORDER BY `id`";
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[2]);
                    data[data.Count - 1][0] = reader[1].ToString();
                    data[data.Count - 1][1] = reader[2].ToString();

                }
                reader.Close();
                connection.Close();
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

            private void bttSave_Click(object sender, EventArgs e)
            {            
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (dataGridView1.Rows.Count == 100)
                {
                    MessageBox.Show("Вы можете добавить не больше 100 записей!");
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
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = nameBox.Text;
                    dataGridView1.Rows[n].Cells[1].Value = messageBox.Text;
                }

                MySqlCommand command = new MySqlCommand("INSERT INTO `" + log + "` (`Title`, `Message`) VALUES (@Title, @Message)", db.getConn());

                command.Parameters.Add("@Title", MySqlDbType.VarChar).Value = nameBox.Text;
                command.Parameters.Add("@Message", MySqlDbType.VarChar).Value = messageBox.Text;

                db.openConn();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Вы успешно добавили данные");
                else
                    MessageBox.Show("Не удалось добавить данные");

                db.closeConn();
                nameBox.Clear();
                messageBox.Clear();
            }
            else
            {
                MessageBox.Show("Не удалось сохранить данные. Проверьте доступ к интернету!");
            }            
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
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) & string.IsNullOrWhiteSpace(messageBox.Text))
            {
                nameBox.Clear();
                messageBox.Clear();
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите создать запись? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Создать", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    nameBox.Clear();
                    messageBox.Clear();
                }
            }            
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (dataGridView1.RowCount > 0)
                {
                    try
                    {
                        if (dataGridView1.SelectedCells.Count == 0) //поверяю выбрана ли запись
                        {
                            MessageBox.Show("Вы не выбрали запись для чтения!");
                        }
                        else
                        {
                            int n = dataGridView1.CurrentCell.RowIndex;
                            string name = (string)dataGridView1.Rows[n].Cells[0].Value;
                            string message = (string)dataGridView1.Rows[n].Cells[1].Value;
                            int index = dataGridView1.SelectedCells[0].RowIndex + 1;
                            ReadEdit readE = new ReadEdit(name, message, index, log);
                            readE.ShowDialog();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!");
                    }

                }
                else
                {
                    MessageBox.Show("Нет записей для чтения. Добавьте записи!");
                }
            }
            else
            {
                MessageBox.Show("Не удалось удалить данные. Проверьте доступ к интернету!");                
            }
        }

        private void bttFind_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    MessageBox.Show("Вы не ввели данные для поиска");
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
            }
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {
            messageBox.ScrollBars = ScrollBars.Vertical;

            richTextBox1.Text = messageBox.Text.Length.ToString();

            if (messageBox.TextLength == 500)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 500");                
            }
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

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (dataGridView1.SelectedCells.Count == 0) //поверяем выбрана ли запись
                    {
                        MessageBox.Show("Вы не выбрали запись для удаления!");
                    }
                    else
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выделенную запись?", "Удаление", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                            {
                                int index = dataGridView1.SelectedCells[0].RowIndex + 1;
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);

                                MySqlCommand comman2 = new MySqlCommand("DELETE FROM `" + log + "` WHERE id = " + index + "", db.getConn()); // Удаляем выделенную строку по индексу
                                MySqlCommand comman1 = new MySqlCommand("ALTER TABLE `" + log + "` DROP id;" +
                                "ALTER TABLE `" + log + "`" +
                                "ADD id INT UNSIGNED NOT NULL AUTO_INCREMENT FIRST," +
                                "ADD PRIMARY KEY(id)", db.getConn()); // Обновляем ид от 1
                                db.openConn();
                                comman2.ExecuteNonQuery();
                                comman1.ExecuteNonQuery();
                                db.closeConn();
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить данные. Проверьте доступ к интернету!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для удаления!");                    
                }
            }
            else
            {
                MessageBox.Show("Не удалось удалить данные. Проверьте доступ к интернету!");                
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.TextLength == 50)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 50!");                
            }
        }

        private void bttDelAll_Click(object sender, EventArgs e)
        {
            bttSave.Visible = true;
            messageBox.ReadOnly = false;
            nameBox.ReadOnly = false;
            if (dataGridView1.RowCount > 0)
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить все записи?", "Удаление", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                                
                            
                                dataGridView1.Rows.Clear();
                                using (MySqlCommand commanS = new MySqlCommand("TRUNCATE TABLE `" + log + "`", db.getConn()))
                                {
                                    db.openConn();
                                    commanS.ExecuteNonQuery();
                                    db.closeConn();
                                }
                                MessageBox.Show("Все записи были успешно удаленны!");
                                
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить данные. Проверьте доступ к интернету!");                        
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для удаления!");                    
                }
            
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            messageBox.ReadOnly = false;
            nameBox.ReadOnly = false;

                if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
                {
                    if (MessageBox.Show("Вы действительно хотите выйти? Несохранённые данные будут утеряны!", "Выход", MessageBoxButtons.OKCancel,
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

        private void bttDelAcc_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (MessageBox.Show("Вы действительно хотите удалить свой аккаунт? ", "Удаление", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (MessageBox.Show("Аккаунт восстановлению не принадлежит!                           Вы действительно хотите продолжить?! ", "Удаление", MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        {
                            MySqlCommand comman1 = new MySqlCommand(" DELETE FROM `AllUsersLogPass` WHERE `login` = @log", db.getConn());
                            MySqlCommand comman2 = new MySqlCommand(" DROP TABLE `" + log + "`", db.getConn());
                            comman1.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;

                            db.openConn();
                            comman1.ExecuteNonQuery();
                            comman2.ExecuteNonQuery();
                            db.closeConn();

                            this.Hide();
                            LoginForm logF = new LoginForm();
                            logF.Show();
                            MessageBox.Show("Ваш аккаунт был успешно удален!");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить аккаунт. Проверьте доступ к интернету!");                            
                        }
                    }
                }                
            }
            else
            {
                MessageBox.Show("Не удалось удалить аккаунт. Проверьте доступ к интернету!");                
            }
        }

        private void bttEdit_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                bttSave.Visible = true;
                messageBox.ReadOnly = false;
                nameBox.ReadOnly = false;
                if (dataGridView1.RowCount > 0)
                {
                    int n = dataGridView1.CurrentCell.RowIndex;
                    if (n > -1)
                    {
                        nameBox.Text = (string)dataGridView1.Rows[n].Cells[0].Value;
                        messageBox.Text = (string)dataGridView1.Rows[n].Cells[1].Value;                        
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей для редактирования. Добавьте записи!");
                }                                          
            }
            else
            {
                MessageBox.Show("Не удалось редактировать данные. Проверьте доступ к интернету!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex + 1;
                    MySqlCommand command = new MySqlCommand("UPDATE `" + log + "` SET Title = @title, Message = @message WHERE id = @Id", db.getConn()); // Удаляем выделенную строку по индексу
                    command.Parameters.AddWithValue("title", nameBox.Text);
                    command.Parameters.AddWithValue("message", nameBox.Text);
                    command.Parameters.AddWithValue("Id", index);
                    MySqlCommand command1 = new MySqlCommand("ALTER TABLE `" + log + "` DROP id;" +
                               "ALTER TABLE `" + log + "`" +
                               "ADD id INT UNSIGNED NOT NULL AUTO_INCREMENT FIRST," +
                               "ADD PRIMARY KEY(id)", db.getConn()); // Обновляем ид от 1 на всякий
                    db.openConn();
                    command.ExecuteNonQuery();
                    command1.ExecuteNonQuery();
                    db.closeConn();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при обновлении данных!");
                }
            }
            else
            {
                MessageBox.Show("Не удалось редактировать данные. Проверьте доступ к интернету!");
            }
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

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
        // Подключение к базе данных
        MySqlConnection connection = new MySqlConnection("server = remotemysql.com; port = 3306; Username = ed5dW7gcoL; Password = 0Gm5En5jkl; database = ed5dW7gcoL; charset = utf8");
        
        DataB db = new DataB();

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
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Открываем соединение
                    connection.Open();

                    // Выбираем данные из таблицы пользователя сортированные по ID
                    string query = "SELECT * FROM  `" + log + "` ORDER BY `id`";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Считываем данные из базы данных
                    MySqlDataReader reader = command.ExecuteReader();

                    // Создаем список строкового масива
                    List<string[]> data = new List<string[]>();

                    // Вносим данные в таблицу
                    while (reader.Read())
                    {
                        // Добавляем новую строку состоящую с двух елементов в список
                        data.Add(new string[2]);

                        // Вносим первый елемент масива в Название
                        data[data.Count - 1][0] = reader[1].ToString();

                        // Вносим второй елемент масива в Сообщение
                        data[data.Count - 1][1] = reader[2].ToString();

                    }
                    reader.Close();

                    // Закрываем соединение
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
            else 
            {
                this.Close();
                LoginForm logF = new LoginForm();
                logF.Show();
                MessageBox.Show("Проверьте доступ к интернету");
            }
        }

            private void bttSave_Click(object sender, EventArgs e)
            {            
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) // Проверяем наличие интернета
            {
                    try
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
                            MySqlCommand command = new MySqlCommand("INSERT INTO `" + log + "` (`Title`, `Message`) VALUES (@Title, @Message)", db.getConn()); // Вносим данные в базу
                            command.Parameters.Add("@Title", MySqlDbType.VarChar).Value = nameBox.Text;
                            command.Parameters.Add("@Message", MySqlDbType.VarChar).Value = messageBox.Text;                             
                            
                            db.openConn();
                            if (command.ExecuteNonQuery() == 1) // Проверяем выполнилась ли команда
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = nameBox.Text;
                                dataGridView1.Rows[n].Cells[1].Value = messageBox.Text;
                                MessageBox.Show("Вы успешно добавили данные");
                            }
                            else
                                MessageBox.Show("Не удалось добавить данные");
                            db.closeConn();

                            nameBox.Clear(); 
                            messageBox.Clear();
                        }                                      
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!");
                    }
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
            // Черный крестик при наводе мышкой на кнопку закрытия
            CloseButton.ForeColor = Color.Black;
        }
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            // Белый крестик закрытия при снятии мышки с кнопки
            CloseButton.ForeColor = Color.White;
        }
        private void hide_MouseEnter(object sender, EventArgs e)
        {
            // Смена цвета кнопки Свернуть на черный при наведении мышки
            hide.ForeColor = Color.Black;
        }
        private void hide_MouseLeave(object sender, EventArgs e)
        {
            // Смена цвета кнопки Свернуть на белый при снятии мышки с кнопки
            hide.ForeColor = Color.White;
        }
        private void hide_Click(object sender, EventArgs e)
        {
            // Сворачивание приложения при нажатии на кнопку
            this.WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {           
            // Проверяем зажата ли левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // Передвигаем форму за мышкой
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Записываем координаты курсора мышки
            lastPoint = new Point(e.X, e.Y);
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            // Проверка на наличие текста в полях Название и Сообщение
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {   
                if (MessageBox.Show("Создать новую запись? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Создать", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    nameBox.Clear();
                    messageBox.Clear();
                }
            }          
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Проверка на наличия строк в таблице
                if (dataGridView1.RowCount > 0)
                {
                    try
                    {
                        // Поверяем выбрана ли запись
                        if (dataGridView1.SelectedCells.Count == 0)
                        {
                            MessageBox.Show("Вы не выбрали запись для чтения!");
                        }
                        else
                        {
                            // Вносим выбранную строку по индексу
                            int n = dataGridView1.CurrentCell.RowIndex;

                            // Вносим в name текст из Названия
                            string name = (string)dataGridView1.Rows[n].Cells[0].Value;

                            // Вносим в message текст из Сообщение
                            string message = (string)dataGridView1.Rows[n].Cells[1].Value;

                            // Вносим в index номер выделенной строки
                            int index = dataGridView1.SelectedCells[0].RowIndex + 1;

                            // Передаем данные на форму
                            ReadEdit readE = new ReadEdit(name, message, index, log);

                            // После закрытия формы Просмотра обновляем основую форму
                            readE.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

                            // Показываем форму Просмотра
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

        private void bttFind_Click_1(object sender, EventArgs e) // Ищем данные в таблице
        {
            // Проверяем наличие строк в таблице
            if (dataGridView1.RowCount > 0)
            {
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    MessageBox.Show("Вы не ввели данные для поиска");
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
            // Добавляем Полоса прокрутки для Сообщения
            messageBox.ScrollBars = ScrollBars.Vertical;

            // Считываем количество символов и записываем снизу поля
            richTextBox1.Text = messageBox.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (messageBox.TextLength == 500)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 500");                
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            // Добавляем Полоса прокрутки для Названия
            nameBox.ScrollBars = ScrollBars.Vertical;

            // Считываем количество символов и записываем снизу поля
            richTextBox2.Text = nameBox.Text.Length.ToString();

            // Проверяем количество введённых символов
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
                                try
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
                                catch
                                {
                                    this.Close();
                                    LoginForm logF = new LoginForm();
                                    logF.Show();
                                    MessageBox.Show("Произошла ошибка!");
                                }
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
            if (dataGridView1.RowCount > 0)
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить все записи?", "Удаление", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                            {
                                try
                                {                             
                                    dataGridView1.Rows.Clear();
                                    MySqlCommand command = new MySqlCommand("TRUNCATE TABLE `" + log + "`", db.getConn());
                                    db.openConn();
                                    if(command.ExecuteNonQuery() == 1)
                                        MessageBox.Show("Все записи были успешно удаленны!");
                                    else
                                        MessageBox.Show("Не удалсь удалить данные");
                                    db.closeConn();                            
                                }
                                catch
                                {
                                    MessageBox.Show("При удалении данных произошла ошибка!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить данные. Проверьте доступ к интернету!");
                            }
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
                if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
                {
                    if (MessageBox.Show("Вы действительно хотите выйти? Несохранённые данные будут утеряны!", "Выход", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        this.Close();
                        LoginForm logF = new LoginForm();
                        logF.ShowDialog();
                    }
                }
                else
                {
                    this.Close();
                    LoginForm logF = new LoginForm();
                    logF.ShowDialog();
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
                            try
                            {
                                MySqlCommand command1 = new MySqlCommand(" DELETE FROM `AllUsersLogPass` WHERE `login` = @log", db.getConn());
                                MySqlCommand command2 = new MySqlCommand(" DROP TABLE `" + log + "`", db.getConn());
                                command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
                                db.openConn();
                                command1.ExecuteNonQuery();
                                command2.ExecuteNonQuery();
                                db.closeConn();
                                this.Hide();
                                LoginForm logF = new LoginForm();
                                logF.Show();
                                MessageBox.Show("Ваш аккаунт был успешно удален!");
                            }
                            catch
                            {
                                MessageBox.Show("Произошла ошибка!");
                            }
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
                try
                {
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
                catch
                {
                    MessageBox.Show("Произошла ошибка!");
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();//Код для обновления
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

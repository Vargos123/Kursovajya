using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        DataB db = new DataB();
        string log;

        public MainForm(string log)
        {
            // Стартовая позиция по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            // Получаем логин из вкладки авторизации
            this.log = log;

            // Загружаем таблицу
            LoadData();
        }        

        // Загрузка таблицы 
        private void LoadData()
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Открываем соединение
                    db.openConn();

                    // Выбираем данные из таблицы пользователя сортированные по ID
                    MySqlCommand command = new MySqlCommand("SELECT * FROM  `" + log + "` ORDER BY `id`", db.getConn());

                    // Считываем данные из базы данных
                    MySqlDataReader reader = command.ExecuteReader();

                    // Создаем список строкового масива
                    List<string[]> data = new List<string[]>();

                    // Получаем данные
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
                    db.closeConn();

                    // Выводим данные в таблицу
                    foreach (string[] s in data)
                        dataGridView1.Rows.Add(s);
                }
                catch 
                {
                    // Закрываем форму
                    this.Close();
                    // Выводим форму авторизации
                    LoginForm logF = new LoginForm();
                    logF.Show();
                    MessageBox.Show("Непредвиденная ошибка!");
                }
                
            }
            else 
            {
                // Закрываем форму
                this.Close();
                // Выводим форму авторизации
                LoginForm logF = new LoginForm();
                logF.Show();
                MessageBox.Show("Проверьте доступ к интернету");
            }
        }

        // Добавление данных
        private void bttSave_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Проверяем ввод данных
                    if (dataGridView1.Rows.Count == 500)
                    {
                        MessageBox.Show("Вы не можете добавить больше 500 записей!");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(nameBox.Text))
                    {
                        MessageBox.Show("Вы не ввели Название!");
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(messageBox.Text))
                    {
                        MessageBox.Show("Вы не ввели Сообщение!");
                        return;
                    }
                    else
                    {
                        // Вносим данные в базу данных
                        MySqlCommand command = new MySqlCommand("INSERT INTO `" + log + "` (`Title`, `Message`) VALUES (@Title, @Message)", db.getConn()); // Вносим данные в базу
                        command.Parameters.Add("@Title", MySqlDbType.VarChar).Value = nameBox.Text;
                        command.Parameters.Add("@Message", MySqlDbType.VarChar).Value = messageBox.Text;

                        // Открываем соединение к базе даннных
                        db.openConn();

                        // Проверяем удачно ли выполнилась команда
                        if (command.ExecuteNonQuery() == 1)
                        {
                            // Добавляем данные в таблицу с полей
                            int n = dataGridView1.Rows.Add();
                            dataGridView1.Rows[n].Cells[0].Value = nameBox.Text;
                            dataGridView1.Rows[n].Cells[1].Value = messageBox.Text;
                            MessageBox.Show("Вы успешно добавили данные");

                            // Очищаем поля 'Название' и 'Сообщение'
                            nameBox.Clear();
                            messageBox.Clear();
                        }
                        else
                            MessageBox.Show("Не удалось добавить данные");

                        // Закрываем соединение к базе даннных
                        db.closeConn();
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

        // Закрытие приложения
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Проверяем наличие текста в полях 'Название' и 'Сообщение'
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
            // Свернуть приложения при нажатии на кнопку
            this.WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {           
            // Проверяем нажата ли левая кнопка мышки
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
            // Проверяем наличие текста в полях 'Название' и 'Сообщение'
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {   
                if (MessageBox.Show("Создать новую запись? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Создать", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // Очищаем поля 'Название' и 'Сообщение'
                    nameBox.Clear();
                    messageBox.Clear();
                }
            }          
        }

        // Просмотр и редактирование текста
        private void bttRead_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Проверяем наличие строк в таблице
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

                            // Вносим в name текст с таблицы с поля Названия
                            string name = (string)dataGridView1.Rows[n].Cells[0].Value;

                            // Вносим в message текст с таблицы с поля Сообщение
                            string message = (string)dataGridView1.Rows[n].Cells[1].Value;

                            // Вносим в index номер выделенной строки
                            int index = dataGridView1.SelectedCells[0].RowIndex + 1;

                            // Передаем данные на форму чтения и редактирования
                            ReadEdit readE = new ReadEdit(name, message, index, log);

                            // После закрытия формы 'Прочитать' обновляем основую форму
                            readE.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

                            // Показываем форму 'Прочитать'
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


        // Поиск данных
        private void bttFind_Click_1(object sender, EventArgs e) // Ищем данные в таблице
        {
            // Проверяем наличие строк в таблице
            if (dataGridView1.RowCount > 0)
            {
                // Проверяем наличие текста в строке поиска
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    MessageBox.Show("Вы не ввели данные для поиска");
                    return;
                }           
                
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    // Придаем количество выделенных строк нулю
                    dataGridView1.Rows[i].Selected = false;

                    // Ищем данные в таблице 
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            // Проверяем есть ли данные в таблице
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBoxSearch.Text))
                            {
                                // Выделяем строку с данными
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }                            
                        }
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
            // Добавляем полосу прокрутки для поля Сообщение
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
            // Добавляем Полосу прокрутки для поля Название
            nameBox.ScrollBars = ScrollBars.Vertical;

            // Считываем количество символов и записываем снизу поля
            richTextBox2.Text = nameBox.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (nameBox.TextLength == 50)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 50");                
            }
        }

        // Удаление данных
        private void bttDelete_Click(object sender, EventArgs e)
        {
            // Проверяем наличине интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Проверяем наличие строк в таблице
                if (dataGridView1.RowCount > 0)
                {
                    //поверяем выбрана ли запись
                    if (dataGridView1.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Вы не выбрали запись для удаления!");
                    }
                    else
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выделенную запись?", "Удаление", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            // Снова проверяем наличине интернета
                            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                            {
                                try
                                {
                                    // Присваиваем значению номер выделенной строки
                                    int index = dataGridView1.SelectedCells[0].RowIndex + 1;

                                    // Удаляем выделенную строку по индексу с базы данных
                                    MySqlCommand command1 = new MySqlCommand("DELETE FROM `" + log + "` WHERE id = " + index + "", db.getConn());

                                    // Обновляем id в таблице базы данных
                                    MySqlCommand command2 = new MySqlCommand("ALTER TABLE `" + log + "` DROP id;" +
                                    "ALTER TABLE `" + log + "`" +
                                    "ADD id INT UNSIGNED NOT NULL AUTO_INCREMENT FIRST," +
                                    "ADD PRIMARY KEY(id)", db.getConn());

                                    // Открываем соединение
                                    db.openConn();
                                    // Выполняем комманды
                                    command1.ExecuteNonQuery();
                                    command2.ExecuteNonQuery();                                 
                                    // Закрываем соединение
                                    db.closeConn();

                                    // Удаляем выеделнную строку из таблицы
                                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                                    MessageBox.Show("Вы успешно удалили данные");
                                }
                                catch
                                {
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
            // Проверяем количество символов в поле Поиска
            if (textBoxSearch.TextLength == 100)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 100!");                
            }            
        }

        // Удаление всех записей
        private void bttDelAll_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Проверка на наличие строк в таблице
                if (dataGridView1.RowCount > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить все записи?", "Удаление", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // Снова проверяем наличие интернета
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        {
                            try
                            {
                                // Очищаем таблицу в базе данных
                                MySqlCommand command = new MySqlCommand("TRUNCATE TABLE `" + log + "`", db.getConn());
                                // Открываем соединение
                                db.openConn();
                                // Выполняем комманду
                                command.ExecuteNonQuery();                                    
                                // Закрываем соединение
                                db.closeConn();

                                // Очищаем таблицу в приложении
                                dataGridView1.Rows.Clear();
                                MessageBox.Show("Все записи были успешно удаленны!");
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
                    MessageBox.Show("Нет записей для удаления!");
                }
            }
            else
            {
                MessageBox.Show("Не удалось удалить данные. Проверьте доступ к интернету!");
            }

        }

        // Закрываем приложение
        private void bttExit_Click(object sender, EventArgs e)
        {
            // Проверяем наличие текста в полях 'Название' и 'Сообщение'
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите выйти?\nНесохранённые данные будут утеряны!", "Выход", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.Close();
                    LoginForm logF = new LoginForm();
                    logF.Show();
                }
            }
            else
            {
                this.Close();
                LoginForm logF = new LoginForm();
                logF.Show();
            }
        }

        // Удаление аккаунта
        private void bttDelAcc_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (MessageBox.Show("Вы действительно хотите удалить свой аккаунт? ", "Удаление", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (MessageBox.Show("Аккаунт восстановлению не принадлежит!\nВы действительно хотите продолжить?! ", "Удаление", MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        // Снова проверяем наличие интернета
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        {
                            try
                            {
                                // Удаляем логин, пароль и таблицу пользователя с базы данных
                                MySqlCommand command1 = new MySqlCommand(" DELETE FROM `AllUsersLogPass` WHERE `login` = @log", db.getConn());
                                MySqlCommand command2 = new MySqlCommand(" DROP TABLE `" + log + "`", db.getConn());
                                command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;


                                // Открываем соединени
                                db.openConn();
                                // Выполняем комманды
                                command1.ExecuteNonQuery();
                                command2.ExecuteNonQuery();
                                // Закрываем соединение
                                db.closeConn();

                                // Скрываем форму и открываем форму авторизации

                                this.Dispose();
                                LoginForm logF = new LoginForm();
                                logF.Show();
                                this.Close();
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

        // Кнопка Обновить ( Обновляет записи в таблице )
        private void bttUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // Очищаем таблицу
            LoadData(); // Снова добавляем данные с базы данных
        }

        // Обновление записей при закрытии формы Чтения
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataGridView1.Rows.Clear(); // Очищаем таблицу
            LoadData(); // Снова данные с базы данных
        }
    }
}

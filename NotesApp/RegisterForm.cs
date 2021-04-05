using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class RegisterForm : Form
    {
        // Переходим на сайт который показывает ip. Считываем и записываем его в IP
        string IP = new WebClient().DownloadString("http://icanhazip.com/");

        public RegisterForm()
        {
            InitializeComponent();
        }

        // Подключаем базу данных
        DataB db = new DataB();

        // Кнопка закрытия приложения
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Выход из приложения
            Application.Exit();
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

        // Кнопка Свернуть приложение
        private void hide_Click(object sender, EventArgs e)
        {
            // Свернуть приложения при нажатии на кнопку
            this.WindowState = FormWindowState.Minimized;
        }

        private void hide_MouseEnter(object sender, EventArgs e)
        {
            // Смена цвета кнопки Свернуть на черный при наведении мышки
            hide.ForeColor = Color.Black;
        }
        private void hide_MouseLeave(object sender, EventArgs e)
        {
            // Смена цвета кнопки Свернуть на белый при снятии мышки с кнопки
            hide.ForeColor = Color.White; //
        }

        Point lastPoint;
        private void RF_MouseMove(object sender, MouseEventArgs e)
        {
            // Проверяем нажата ли левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // Передвигаем форму за мышкой
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void RF_MouseDown(object sender, MouseEventArgs e)
        {
            // Записываем координаты курсора мышки
            lastPoint = new Point(e.X, e.Y);
        }

        // Кнопка Зарегистрироваться 
        private void butRegister_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Проверяем введён ли логин и пароль и их длину
                    if (string.IsNullOrWhiteSpace(loginF.Text))
                    {
                        MessageBox.Show("Вы не ввели Логин!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(passF.Text))
                    {
                        MessageBox.Show("Вы не ввели Пароль!");
                        return;
                    }
                    else if (loginF.TextLength < 4 || passF.TextLength < 4)
                    {
                        MessageBox.Show("Длина Логина или Пароля меньше допустимой нормы. Минимальная длина 4 символа.");
                        return;
                    }

                    // Проверяем сколько зарегистрировано аккаунтов. Больше 100 - не регистрируем
                    if (CheckIp())
                        return;

                    // Проверяем свободный ли логин. Если нет, выходим из функции 
                    if (isUser())
                        return;

                    try
                    {
                        // Создаем таблицу в базе данных в которой будут хранится все записи пользователя
                        MySqlCommand createT = new MySqlCommand("CREATE TABLE `" + loginF.Text + "` LIKE PrimerTable", db.getConn());
                        db.openConn();  // Открываем соединение
                        createT.ExecuteNonQuery();  // Выполняем комманду
                        db.closeConn(); // Закрывем соединение           
                    }
                    catch
                    {
                        MessageBox.Show("Данный Логин не может быть использован!");
                        return;
                    }

                    // Добавляем Логин и Пароль пользователя в общую базу 
                    MySqlCommand command = new MySqlCommand("INSERT INTO `AllUsersLogPass` (`login`, `pass`, `ip`) VALUES (@login, @pass, @ip)", db.getConn());

                    // Снимаем заглушки
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginF.Text;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passF.Text;
                    command.Parameters.Add("@ip", MySqlDbType.VarChar).Value = IP;

                    db.openConn();  // Открываем соединение
                    if (command.ExecuteNonQuery() == 1)
                        MessageBox.Show("Вы успешно зарегистрировались!\nОбязательно запомните свой Логин и пароль!\nВы не сможете создать больше 100 аккаунтов!");
                    else
                    {
                        MessageBox.Show("Вы не зарегистрировались, проверьте ввод даных!");

                        // В случае неудачи удаляем созданную раннее таблицу
                        MySqlCommand command1 = new MySqlCommand("DROP TABLE `" + loginF.Text + "`", db.getConn());
                        command1.ExecuteNonQuery();
                    }
                    db.closeConn(); // Закрываем соединение
                }
                catch
                {
                    // В случае ошибки выводим сообщение
                    MessageBox.Show("Произошла ошибка!");
                }
            }
            else
            {
                // В случае отсутствия интернета выводим сообщение
                MessageBox.Show("Не удалось зарегистрироваться. Проверьте доступ к интернету!");
            }
        }

        public Boolean CheckIp()
        {
            // Проверяем наличине интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Создаем таблицу в которой будут проверяться данные
                    DataTable table = new DataTable();

                    // Получаем и Сохраняем данные в adapter
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    
                    // Ищем в базе данных Логин который ввёл пользователь раннее
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `AllUsersLogPass` WHERE `ip` = @IP", db.getConn());
                    command.Parameters.Add("@IP", MySqlDbType.VarChar).Value = IP;

                    adapter.SelectCommand = command;    // Выполняем комманду
                    adapter.Fill(table);    // Записываем итог выполения комманды в таблицу
                    if (table.Rows.Count > 99)   // Проверяем сколько зарегистрировано аккаунтов
                    {
                        MessageBox.Show("Вы не можете зарегистрировать больше 100 аккаунтов с одного IP");
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка!");
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Проверьте доступ к интернету!\nНе удалось подключится к сети.");
                return true;
            }
        }

        // Проверяем свободный ли логин
        public Boolean isUser()
        {
            // Проверяем наличине интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Создаем таблицу в которой будут проверяться данные
                    DataTable table = new DataTable();

                    // Получаем и Сохраняем данные в adapter
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    // Ищем в базе данных Логин который ввёл пользователь раннее
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `AllUsersLogPass` WHERE `login` = @userL", db.getConn());
                    command.Parameters.Add("@userL", MySqlDbType.VarChar).Value = loginF.Text;

                    adapter.SelectCommand = command;    // Выполняем комманду
                    adapter.Fill(table);    // Записываем итог выполения комманды в таблицу
                    if (table.Rows.Count > 0)   // Проверяем есть ли совпадения с логином
                    {
                        MessageBox.Show("Даный Логин уже зарегистрирован!");
                        return true;
                    }
                    else
                        return false;
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка!");
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Проверьте доступ к интернету!\nНе удалось подключится к сети.");
                return true;
            }
        }

        // Кнопка открытия формы авторизации
        private void goToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm logF = new LoginForm();
            logF.Show();

        }

        private void loginF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем снизу поля
            richTextBox2.Text = loginF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (loginF.TextLength == 16)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 16!");
            }
        }

        private void passF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем снизу поля
            richTextBox1.Text = passF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (passF.TextLength == 32)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 32!");
            }
        }
    }
}


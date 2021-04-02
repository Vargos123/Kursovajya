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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            // Стартовая позиция по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

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
            hide.ForeColor = Color.White;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Проверяем нажата ли левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // Передвигаем форму за мышкой
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Записываем координаты курсора мышки
            lastPoint = new Point(e.X, e.Y);
        }

        // Кнопка Ввойти
        private void butLogin_Click(object sender, EventArgs e)
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Проверяем введён ли логин и пароль
                if (string.IsNullOrWhiteSpace(loginF.Text))
                {
                    MessageBox.Show("Вы не ввели Логин!");
                    return;
                }
                if(string.IsNullOrWhiteSpace(passF.Text))
                {
                    MessageBox.Show("Вы не ввели Пароль!");
                    return;
                }

                String Login = loginF.Text;
                String Pass = passF.Text;

                // Подключаем базу данных
                DataB db = new DataB();

                // Создаем таблицу для хранения введённыъ данных
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                // ввод логина и пароля и сравнение логина с БД 
                try
                {
                    // Выбираем Логин и Пароль из базы данных
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `AllUsersLogPass` WHERE `login` = @userL AND `pass` = @userP", db.getConn());       
                    // Расшифровка заглушек
                    command.Parameters.Add("@userL", MySqlDbType.VarChar).Value = Login;
                    command.Parameters.Add("@userP", MySqlDbType.VarChar).Value = Pass;   
                    
                    // Выполняем комманду
                    adapter.SelectCommand = command;

                    // Записываем полученные данные в table 
                    adapter.Fill(table);

                    // Проверяем количество рядов
                    if (table.Rows.Count > 0)
                    {
                        // Скрываем форму авторизации
                        this.Hide();

                        // Открывем основую форму и передаём в неё Логин пользователя
                        MainForm mainF = new MainForm(this.loginF.Text);
                        mainF.Show();

                    }
                    else
                        MessageBox.Show("Не правильный логин или пароль!\nПроверьте правильность ввода даных.");
                }
                catch
                {
                    MessageBox.Show("Не правильный логин или пароль!\nПроверьте правильность ввода даных.");
                }
            }
            else
            {
                MessageBox.Show("Не удалось войти в аккаунт. Проверьте доступ к интернету!");
            }
        }

        // Кнопка Создать аккаунт
        private void createAcc_Click(object sender, EventArgs e)
        {
            // Скрываем форму авторизации и открываем форму регистрации
            this.Hide();
            RegisterForm regF = new RegisterForm();
            regF.Show();
        }


        private void passF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем снизу поля
            richTextBox1.Text = passF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (passF.TextLength == 32)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 32.");
            }
        }

        private void loginF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем снизу поля
            richTextBox2.Text = loginF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (loginF.TextLength == 16)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 16.");
            }
        }

        // Вход без Логина
        private void label3_Click(object sender, EventArgs e)
        {
            // Скрываем форму авторизации и открываем главную форму
            this.Hide();
            MainFormNoLogin mainF = new MainFormNoLogin();
            mainF.Show();
        }
    }
}

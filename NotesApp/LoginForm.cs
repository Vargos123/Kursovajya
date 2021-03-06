using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            // Форма по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        // Кнопка закрытия приложения
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Закрываем программу
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

        private void Login()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // Проверяем введён ли логин и пароль
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

                String Login = loginF.Text;
                String Pass = passF.Text;

                // Подключаем базу данных
                DataB db = new DataB();

                // Создаем таблицу для хранения введённых данных
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                // ввод логина и пароля и сравнение логина с БД 
                try
                {
                    // Выбираем Логин и Пароль с базы данных
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `AllUsersLogPass` WHERE `login` = @userL AND `pass` = @userP", db.getConn());
                    // Расшифровка заглушек
                    command.Parameters.Add("@userL", MySqlDbType.VarChar).Value = Login;
                    command.Parameters.Add("@userP", MySqlDbType.VarChar).Value = Pass;

                    // Выполняем комманду
                    adapter.SelectCommand = command;

                    // Записываем полученные данные в table 
                    adapter.Fill(table);

                    // Проверяем количество рядов (совпадений)
                    if (table.Rows.Count > 0)
                    {
                        // Открывем основую форму и передаём в неё Логин пользователя
                        MainForm mainF = new MainForm(this.loginF.Text);

                        // Скрываем форму авторизации
                        this.Close();

                        // Открываем главную форму
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
                MessageBox.Show("Не удалось войти в аккаунт!\nПроверьте доступ к интернету!");
            }
        }

        // Кнопка Ввойти
        private void butLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        // Кнопка Создать аккаунт
        private void createAcc_Click(object sender, EventArgs e)
        {
            // Закрываем форму авторизации и открываем форму регистрации   
            this.Close();                     
            RegisterForm regF = new RegisterForm();            
            regF.Show();            
        }
        private void passF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем сверху поля
            richTextBox1.Text = passF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (passF.TextLength == 32)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 32!");
            }
        }
        private void loginF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем сверху поля
            richTextBox2.Text = loginF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (loginF.TextLength == 16)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 16!");
            }
        }
        // Вход без Логина
        private void label3_Click(object sender, EventArgs e)
        {
            // Скрываем форму авторизации и открываем главную форму
            MainFormNoLogin mainF = new MainFormNoLogin();
            mainF.Show();
            this.Close();
        }
    }
}

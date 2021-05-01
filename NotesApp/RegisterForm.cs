using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class RegisterForm : Form
    {
        // Подключаем базу данных
        DataB db = new DataB();

        public RegisterForm()
        {
            // Форма по центру экрана
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

        private void Email()
        {
            Random m = new Random();
            int x = m.Next(1000, 9999);
            SmtpClient sm = new SmtpClient("smtp.gmail.com", 587);
            sm.UseDefaultCredentials = false;
            sm.Credentials = new NetworkCredential("menoteapp@gmail.com", "M$$&(En0T3");
            sm.EnableSsl = true;
            sm.DeliveryMethod = SmtpDeliveryMethod.Network;
            sm.Send("menoteapp@gmail.com", "" + emailF.Text + "", "MeNote - Подтверждение Email", "Ваш код подтверждения: " + Convert.ToString(x) + "\nВведите его для завержения регистрации!");
            // Открываем форму подтверждения емейла и регистрируем пользователя там
            EmailConf EC = new EmailConf(this.emailF.Text, this.loginF.Text, this.passF.Text, x);
            MessageBox.Show("На вашу почту был выслан код для подтверждения Email!\nВведите его для подтверждения регистрации!");
            EC.ShowDialog();
        }

        private void Register()
        {
            // Проверяем наличие интернета
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    // Проверяем введён ли  email, логин и пароль
                    if (string.IsNullOrWhiteSpace(emailF.Text))
                    {
                        MessageBox.Show("Вы не ввели Email!");
                        return;
                    }
                    if (!IsValid(emailF.Text))
                    {
                        MessageBox.Show("Вы ввели не верный Email!");
                        return;
                    }
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

                    // Проверяем свободный ли Email. Если нет, выходим из функции 
                    if (isEmail())
                        return;

                    // Проверяем свободный ли логин. Если нет, выходим из функции 
                    if (isUser())
                        return;

                    // Проверяем возможно ли создать таблицу с введённыи логином и удаляем её. Сделано для проверки т.к некоторые ники не пропускает!
                    try
                    {
                        // Создаем таблицу в базе данных в которой будут хранится все записи пользователя
                        MySqlCommand createT = new MySqlCommand("CREATE TABLE `" + loginF.Text + "` LIKE PrimerTable", db.getConn());
                        MySqlCommand dellT = new MySqlCommand("DROP TABLE `" + loginF.Text + "`", db.getConn());
                        db.openConn();  // Открываем соединение
                        createT.ExecuteNonQuery();  // Выполняем комманду
                        dellT.ExecuteNonQuery();    // Выполняем комманду
                        db.closeConn(); // Закрывем соединение                                      
                    }
                    catch
                    {
                        MessageBox.Show("Данный Логин не может быть использован!");
                        return;
                    }

                    try
                    {
                        // Отправляем код продтверждения Емейл на почту
                        Email();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!");
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка! Проверьте правильность ввода данных!");
                }

            }
            else
            {
                // В случае отсутствия интернета выводим сообщение
                MessageBox.Show("Не удалось зарегистрироваться. Проверьте доступ к интернету!");
            }
        }

        // Кнопка Зарегистрироваться 
        private void butRegister_Click(object sender, EventArgs e)
        {
            Register();            
        }


        // Проверка на емейл
        public bool IsValid(string emailaddress)
        {
            // Проверяем емейл на правильность ввода символов
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(emailaddress);
            if (match.Success)
                return true;
            else
                return false;
        }
        public Boolean isEmail()
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
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `AllUsersLogPass` WHERE `email` = @email", db.getConn());
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailF.Text;

                    adapter.SelectCommand = command;    // Выполняем комманду
                    adapter.Fill(table);    // Записываем итог выполения комманды в таблицу
                    if (table.Rows.Count > 0)   // Проверяем есть ли совпадения с логином
                    {
                        MessageBox.Show("Данный Email уже зарегистрирован!");
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
                        MessageBox.Show("Данный Логин уже зарегистрирован!");
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

        private void emailF_TextChanged(object sender, EventArgs e)
        {
            // Считываем количество символов и записываем снизу поля
            richTextBox3.Text = emailF.Text.Length.ToString();

            // Проверяем количество введённых символов
            if (emailF.TextLength == 200)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 200!");
            }
        }
    }
}


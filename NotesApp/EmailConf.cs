using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class EmailConf : Form
    {
        string email, login, pass;
        int confirm, Random;
        

        DataB db = new DataB();       

        public EmailConf(string email, string login, string pass, int confirm)
        {
            // Форма по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            this.email = email;
            this.login = login;
            this.pass = pass;
            this.confirm = confirm;            
        }

        private void CloseBttn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите отменить регистрацию?", "Выход", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        int click1 = -1;
        private void goToLogin_Click(object sender, EventArgs e)
        {
            click1++;
            if (click1 >= 3)
            {
                MessageBox.Show("Вы не смогли подтвердить почту. Попробуйте позже!");
                this.Close();
                return;
            }

            Random m = new Random();
            int xEE = m.Next(1000, 9999);
            Random = xEE;

            SmtpClient sm = new SmtpClient("smtp.gmail.com", 587);
            sm.UseDefaultCredentials = false;
            sm.Credentials = new NetworkCredential("menoteapp@gmail.com", "M$$&(En0T3");
            sm.EnableSsl = true;
            sm.DeliveryMethod = SmtpDeliveryMethod.Network;
            sm.Send("menoteapp@gmail.com", "" + email + "", "MeNote - Подтверждение Email", " Ваш код подтверждения: " + Convert.ToString(xEE) + " \n Введите его для завержения регистрации!");
            MessageBox.Show("На ваш Email был выслан новый код подтверждения!");
        }

        Point lastPoint;
        private void EmailConf_MouseMove(object sender, MouseEventArgs e)
        {
            // Проверяем нажата ли левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // Передвигаем форму за мышкой
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void EmailConf_MouseDown(object sender, MouseEventArgs e)
        {
            // Записываем координаты курсора мышки
            lastPoint = new Point(e.X, e.Y);
        }

        // Переменные для подсчета количества нажатий на кнопку.
        int click = -1, quantity = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            click++;
            if (click >= 3)
            {
                MessageBox.Show("Не удалось подтвердить Email. Проверьте правильность ввода данных!");
                this.Close();
                return;
            }

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (confirms.Text == Convert.ToString(confirm) || confirms.Text == Convert.ToString(Random))
                {
                    // Добавляем Логин и Пароль пользователя в общую базу 
                    MySqlCommand command = new MySqlCommand("INSERT INTO `AllUsersLogPass` (`email`, `login`, `pass`) VALUES (@email, @login, @pass)", db.getConn());
                    MySqlCommand createT = new MySqlCommand("CREATE TABLE `" + login + "` LIKE PrimerTable", db.getConn());
                    // Снимаем заглушки
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
                    try
                    { 
                        db.openConn();  // Открываем соединение
                        createT.ExecuteNonQuery();
                        command.ExecuteNonQuery();
                        db.closeConn(); // Закрываем соединение
                        SmtpClient sm = new SmtpClient("smtp.gmail.com", 587);
                        sm.UseDefaultCredentials = false;
                        sm.Credentials = new NetworkCredential("menoteapp@gmail.com", "M$$&(En0T3");
                        sm.EnableSsl = true;
                        sm.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sm.Send("menoteapp@gmail.com", "" + email + "", "MeNote", " Спасибо за регистрацию!\n Ваш Логин: " + login + "\n Ваш Пароль: " + pass + " \n Используйте их, для авторизации в приложении!");
                        MessageBox.Show("Вы успешно зарегистрировались!\nНа вашу почту был отправлен Логин и Пароль.\nНе забудьте их запомнить!");
                        this.Close();
                    }
                    catch
                    {

                        MessageBox.Show("Вы не смогли зарегистрироваться! Проверьте ввод данных!");
                        this.Close();
                    }                    
                }
                else
                {
                    if(quantity == 0)
                    {
                        MessageBox.Show("Вы ввели не верный код. У вас не осталось попыток!");
                    }
                    else
                        MessageBox.Show("Вы ввели не верный код. У вас осталось: "+ quantity-- +" попытки");
                }
            }
        }
    }
}
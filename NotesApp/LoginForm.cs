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
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.passF.AutoSize = false;
            this.passF.Size = new Size(this.passF.Size.Width, 37);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Выход из приложения
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
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //  перемещение приложения по робочему столу за курсором
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void loginF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                removeSpaces();
            }
            //Handle Ctrl+Ins
            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.Insert)
            {
                removeSpaces();
            }
        }

        private void removeSpaces()
        {
            loginF.Text = loginF.Text.Replace(" ", string.Empty);
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {

                if (string.IsNullOrWhiteSpace(loginF.Text) || string.IsNullOrWhiteSpace(passF.Text))
                {
                    MessageBox.Show("Вы не ввели Логин или Пароль!");
                    return;
                }

                String Login = loginF.Text;
                String Pass = passF.Text;

                DataB db = new DataB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                // ввод логина и пароля и сравнение логина с БД 

                try
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `AllUsersLogPass` WHERE `login` = @userL AND `pass` = @userP", db.getConn());
                    command.Parameters.Add("@userL", MySqlDbType.VarChar).Value = Login;
                    command.Parameters.Add("@userP", MySqlDbType.VarChar).Value = Pass;

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        this.Hide();
                        MainForm mainF = new MainForm(this.loginF.Text);
                        mainF.Show();

                    }
                    else
                        MessageBox.Show("Не правильный логин или пароль! Проверьте правильность ввода даных.");
                }
                catch
                {
                    MessageBox.Show("Не правильный логин или пароль! Проверьте правильность ввода даных.");
                }
            }
            else
            {
                MessageBox.Show("Не удалось войти в аккаунт. Проверьте доступ к интернету!");
            }
        }

        private void createAcc_Click(object sender, EventArgs e)
        {
            // скрывать окно и регистрироваться
            this.Hide();
            RegisterForm regF = new RegisterForm();
            regF.Show();
        }

        private void passF_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = passF.Text.Length.ToString();
            if (passF.TextLength == 32)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 32.");
                return;
            }
        }

        private void loginF_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = loginF.Text.Length.ToString();
            if (loginF.TextLength == 16)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 16.");
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainFormNoLogin mainF = new MainFormNoLogin();
            mainF.Show();
        }
    }
}

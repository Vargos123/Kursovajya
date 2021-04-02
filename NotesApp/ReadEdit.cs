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
    public partial class ReadEdit : Form
    {
        private bool SaveButtonWasClicked = false;

        // Подключение к базе данных
        DataB db = new DataB();

        string log, nameB, messageB;
        int index;

        public ReadEdit(string nameBox, string messageBox, int index, string log)
        {
            // Стартовая позиция по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            name.Text = nameBox;
            message.Text = messageBox;
            this.index = index;
            this.log = log;
            nameB = nameBox;
            messageB = messageBox;
        }

        // Кнопка закрытия приложения
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (!SaveButtonWasClicked)
            {
                // Проверяем меняли ли текст в полях 'Название' и 'Сообщение' 
                if (name.Text != nameB || message.Text != messageB)
                {
                    // Если текст меняли - выдаем предупреждение
                    if (MessageBox.Show("Возможно у вас есть несохранённые данные!\nВы подтверждаете выход?", "Выход", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
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
        private void ReadEdit_MouseMove(object sender, MouseEventArgs e)
        {
            // Проверяем нажата ли левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // Передвигаем форму за мышкой
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void ReadEdit_MouseDown_1(object sender, MouseEventArgs e)
        {
            // Записываем координаты курсора мышки
            lastPoint = new Point(e.X, e.Y);
        }


        private void name_TextChanged(object sender, EventArgs e)
        {
            // Добавляем полосу прокрутки для поля 'Название'
            name.ScrollBars = ScrollBars.Vertical;

            // Считываем количество символов и записываем снизу поля
            richTextBox2.Text = name.Text.Length.ToString();

            // Проверяем, не писали ли текст после нажатия на кнопку Сохранить
            if (name.Text.Length != 0)
            {
                SaveButtonWasClicked = false;
            }
        }


        private void message_TextChanged(object sender, EventArgs e)
        {
            // Добавляем полосу прокрутки для поля 'Сообщение'
            message.ScrollBars = ScrollBars.Vertical;

            // Считываем количество символов и записываем снизу поля
            richTextBox1.Text = message.Text.Length.ToString();

            // Проверяем, не писали ли текст после нажатия на кнопку Сохранить
            if (message.Text.Length != 0)
            {
                SaveButtonWasClicked = false;
            }
        }

        // Кнопка Сохранить
        private void bttSave_Click(object sender, EventArgs e)
        {
            // Проверяем менял ли пользователь данные
            if (name.Text != nameB || message.Text != messageB)
            {
                // Проверяем наличие интернета
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    try
                    {
                        // Проверяем не пусты ли поля 'Название' и 'Сообщение' 
                        if (string.IsNullOrWhiteSpace(name.Text))
                        {
                            MessageBox.Show("Название не может быть пустым!");
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(message.Text))
                        {
                            MessageBox.Show("Сообщение не может быть пустым!");
                            return;
                        }

                        // Обновляем таблицу внося новые данные вместо старых
                        MySqlCommand command = new MySqlCommand("UPDATE `" + log + "` SET Title = @title, Message = @message WHERE id = @Id", db.getConn());
                        command.Parameters.AddWithValue("title", name.Text);
                        command.Parameters.AddWithValue("message", message.Text);
                        command.Parameters.AddWithValue("Id", index);

                        db.openConn();  // Открываем соединени
                        if (command.ExecuteNonQuery() == 1)
                        {
                            SaveButtonWasClicked = true;
                            MessageBox.Show("Вы успешно обновлили данные!");
                        }

                        else
                            MessageBox.Show("Вы не смогли обновить данные!");
                        db.closeConn(); // Закрываем соединени
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!");
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось обновить данные. Проверьте доступ к интернету!");
                }
            }
            else
            {
                MessageBox.Show("Вы не изменяли текст!");
            }
        }
    }
}

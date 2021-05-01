using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace NotesApp
{
    public partial class MainFormNoLogin : Form
    {
        // Переменная для определения была ли нажата кнопка Открытия
        int update;


        public MainFormNoLogin()
        {
            // Форма по центру экрана
            this.StartPosition = FormStartPosition.CenterScreen;


            InitializeComponent();
            CheckFile();
        }  

        private void CheckFile()
        {
            if (File.Exists(@"" + Application.StartupPath.ToString() + "\\DataBaze.Data"))
            {
                OpenFile();
            }
            else
            {
                MessageBox.Show("К сожалению, ваш файл был повреждён или удалён. Мы успешно создали новый файл.\nК сожалению, все данные былы удалены. Проверьте корзину!");
                ConnectToTable();
            }
        }

        private void OpenFile()
        {

            string[] lines = File.ReadAllLines(@"" + Application.StartupPath.ToString() + "\\DataBaze.Data");
            string[] values;

            for(int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('|');
                string[] row = new string[values.Length];
                for(int j=0; j<values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridView1.Rows.Add(row);

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
        private void MainFormNoLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void MainFormNoLogin_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.TextLength == 50)
            {
                MessageBox.Show("Достигнуто максимальное количество символов: 50!");
            }
        }

        // Удаляем выделенные строки с таблицы
        private void CleadCellData()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }
        // Значение для проверки удалось ли найти данные
        bool IsSelected;
        private void bttFind_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                try
                {
                    // Убираем выделенные строки
                    CleadCellData();
                    if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                    {
                        MessageBox.Show("Вы не ввели данные для поиска.");
                        return;
                    }

                    IsSelected = false;
                    // Идём по строкам
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        // Убираем выделение строки
                        dataGridView1.Rows[i].Selected = false;
                        // Идем по количеству столбцам
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBoxSearch.Text.ToLower()))
                                {
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.MediumOrchid;
                                    break;
                                }                                
                            }
                    }

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        // Проверяем есть ли строка с данным цветом текста. Если есть значит данные успешно были найдены - выходим
                        if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.MediumOrchid) // Если нашли строку с цветом MediumOrchid - придаем значение TRUE
                        {
                            IsSelected = true;
                            break;
                        }
                    }
                    
                    if (!IsSelected)
                    {
                        MessageBox.Show("Вы не смоги найти данные: " + textBoxSearch.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("При попытке поиска данных произошла ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Нет записей для поиска. Добавьте записи!");
            }
        }

        private void bttRead_Click(object sender, EventArgs e)
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
                        // Вносим индекс выделенной строки в переменную и добавляем +1 т.к может быть выделена нулевая строка
                        update = dataGridView1.CurrentCell.RowIndex + 1;

                        // Выносим данные в Текстбоксы
                        nameBox.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        messageBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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

        private void bttNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {
                if (MessageBox.Show("Создать новую запись? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Создать", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    update = 0; // Присваиваем 0 количество выделенных строк
                    ClearBox(); // Очищаем поля Название и Сообщение
                    CleadCellData(); // Убираем выделенные строки
                }
            }
            else
            {
                update = 0; // Присваиваем 0 количество выделенных строк                            
                CleadCellData();    // Убираем выделенные строки
            }
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(messageBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите выйти? Несохранённые данные в полях 'Название' и 'Сообщение' будут утеряны!", "Выход", MessageBoxButtons.OKCancel,
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

        private void ClearBox()
        {
            nameBox.Clear();
            messageBox.Clear();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {          
            try
            {
                if (dataGridView1.Rows.Count == 100000)
                {
                    MessageBox.Show("Вы не можете добавить больше 100000 записей!");
                }
                else if (string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    MessageBox.Show("Вы не ввели Название!");    
                 }
                else if (nameBox.TextLength > 50)
                {
                    MessageBox.Show("Длина Названия превышает допустимую норму. Максимальная длина 50 символов.");
                }
                else if (string.IsNullOrWhiteSpace(messageBox.Text))
                {
                    MessageBox.Show("Вы не ввели Сообщение!");
                }
                else if ((nameBox.Text.Contains("|")) || (messageBox.Text.Contains("|"))) // Проверяем наличие символа |
                {
                    MessageBox.Show("К сожалению, вы не можете добавить символ: |");
                }
                else if (update > 0)  // Проверяем была ли нажата кнопка прочитать и выбралась ли строка
                {
                    // Заменяем данные в таблице
                    dataGridView1.Rows[update - 1].Cells[0].Value = nameBox.Text;
                    dataGridView1.Rows[update - 1].Cells[1].Value = messageBox.Text;
                    ClearBox();
                    ConnectToTable();
                    CleadCellData(); // Убираем выделенные строки
                    MessageBox.Show("Вы успешно обновили данные");

                    // Присваиваем переменной значение 0 - значит строка и кнопка Открыть ещё не нажата
                    update = 0;
                }
                else
                {
                    dataGridView1.Rows.Add(nameBox.Text, messageBox.Text);
                    ClearBox();
                    ConnectToTable(); // Обновляем данные в базе данных, 
                    CleadCellData(); // Убираем выделенные строки
                    MessageBox.Show("Вы успешно добавили данные");
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить данные!");
            }
        }

        private void bttDelAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить все записи? \nПоля Название и Сообщение так же будут очищены!", "Удаление", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    try
                    {
                        update = 0; // Присваиваем 0 количество выделенных строк
                        dataGridView1.Rows.Clear();
                        MessageBox.Show("Вы успешно очистили таблицу!");
                        ClearBox();
                        ConnectToTable();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет записей для удаления!");
            }
        }        

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                try
                {
                    if (dataGridView1.SelectedCells.Count == 0) //поверяем выбрана ли запись
                    {
                        MessageBox.Show("Вы не выбрали запись для удаления!");
                    }
                    else
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить выделенную запись? \nПоля Название и Сообщение так же будут очищены!", "Удаление", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            try
                            {
                                update = 0; // Присваиваем 0 количество выделенных строк
                                int delet = dataGridView1.SelectedCells[0].RowIndex;
                                dataGridView1.Rows.RemoveAt(delet);
                                MessageBox.Show("Вы успешно удалили данные.");
                                ClearBox();
                                ConnectToTable();

                            }
                            catch
                            {
                                MessageBox.Show("Произошла ошибка!");
                            }
                        }           
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Нет записей для удаления!");
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


        private void MainFormNoLogin_Load(object sender, EventArgs e)
        {

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

        // Добавление данных в БД. Открываем файл снова
        private void ConnectToTable()
        {
            try
            {
                StreamWriter file = new StreamWriter(@"" + Application.StartupPath.ToString() + "\\DataBaze.Data");
                string DataLine = "";
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dataGridView1.Columns.Count - 1; j++)
                    {
                        DataLine = DataLine + dataGridView1.Rows[i].Cells[j].Value;
                        if (j != dataGridView1.Columns.Count - 1)
                        {
                            DataLine = "\t" + DataLine + "\t" + "|" + "\t";
                        }
                    }
                    file.WriteLine(DataLine);
                    DataLine = "";
                }
                file.Close();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 124)
            {
                e.Handled = true;
                MessageBox.Show("К сожалению, вы не можете использовать символ: |");
            }

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Hide();
        }
    }
}


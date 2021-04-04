using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class Information : Form
    {
        // Подключаем базу данных
        DataB db = new DataB();

        string log;
        int index;
        public Information(int index, string log)
        {
            InitializeComponent();
            this.index = index; // Подставляем номер выделенной строки. Её id
            this.log = log; // Получаем Логин пользователя
            Info();
        }

        private void Info()
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("SELECT `DataCreate` FROM `" + log + "` WHERE id = @id", db.getConn());
                MySqlCommand command2 = new MySqlCommand("SELECT `DataChange` FROM `" + log + "` WHERE id = @id", db.getConn());
                command1.Parameters.AddWithValue("@id", index);
                command2.Parameters.AddWithValue("@id", index);

                // Открываем соединение к базе даннных
                db.openConn();

                // Проверяем удачно ли выполнилась команда
                string DataCreate = command1.ExecuteScalar().ToString();
                string DataChange = command2.ExecuteScalar().ToString();
                if (DataCreate != null && DataChange != null)
                {
                    DCreate.Text = DataCreate;
                    DChange.Text = DataChange;

                }
                else
                {
                    MessageBox.Show("Произошла ошибка");
                }
                // Закрываем соединение к базе даннных
                db.closeConn();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class MeNote : Form
    {
        public MeNote()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Рисуем квадрат поверх другого и к верхнему квадрату прибавляем длину +25
            Frontscale.Width += 20;

            // Когда ползунок дойдёт до конца открываем форму логина
            if (Frontscale.Width >= 590)
            {
                timer.Stop();
                LoginForm LF = new LoginForm();
                LF.Show();
                this.Hide();
            }
        }
    }
}

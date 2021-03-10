using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApp
{
    static class Program
    {
        //appGuid для Mutex-a
        private static string appGuid = "FB6B42D0-10D9-4563-AFF9-7123317FA272";
        [STAThread]
        static void Main()
        {
            //Mutex для запрета повторного запуска приложения
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Программа уже запущена. Повторный запуск программы невозможен", "Внимение:");
                    return;
                }
                GC.Collect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            }
        }
    }
}

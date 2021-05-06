using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    class SendEmail
    {
        DataB db = new DataB();
        string email, login, pass;
        int x;
        public void Send(string email, int x)
        {
            this.email = email;
            this.x = x;

            SmtpClient sm = new SmtpClient("smtp.gmail.com", 587);
            sm.UseDefaultCredentials = false;
            sm.Credentials = new NetworkCredential("menoteapp@gmail.com", "M$$&(En0T3");
            sm.EnableSsl = true;
            sm.DeliveryMethod = SmtpDeliveryMethod.Network;
            sm.Send("menoteapp@gmail.com", "" + email + "", "MeNote - Подтверждение Email", "Ваш код подтверждения: " + Convert.ToString(x) + "\nВведите его для завержения регистрации!");
        }
        public void RegistrationConfirm(string email, string login, string pass)
        {
            this.email = email;
            this.login = login;
            this.pass = pass;

            SmtpClient sm = new SmtpClient("smtp.gmail.com", 587);
            sm.UseDefaultCredentials = false;
            sm.Credentials = new NetworkCredential("menoteapp@gmail.com", "M$$&(En0T3");
            sm.EnableSsl = true;
            sm.DeliveryMethod = SmtpDeliveryMethod.Network;
            sm.Send("menoteapp@gmail.com", "" + email + "", "MeNote", " Спасибо за регистрацию!\n Ваш Логин: " + login + "\n Ваш Пароль: " + pass + " \n Используйте их, для авторизации в приложении!");
        }
        public void DeleteAccount(string login)
        {
            this.login = login;
            MySqlCommand command3 = new MySqlCommand("SELECT `email` FROM `AllUsersLogPass` WHERE `login` = @log", db.getConn());
            command3.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
            db.openConn();
            MySqlDataReader reader = command3.ExecuteReader();
            reader.Read();
            string emailname = reader[0].ToString();
            db.closeConn();
            SmtpClient sm = new SmtpClient("smtp.gmail.com", 587);
            sm.UseDefaultCredentials = false;
            sm.Credentials = new NetworkCredential("menoteapp@gmail.com", "M$$&(En0T3");
            sm.EnableSsl = true;
            sm.DeliveryMethod = SmtpDeliveryMethod.Network;
            sm.Send("menoteapp@gmail.com", "" + emailname + "", "MeNote - Удаление аккаунт", "Ваш аккаунт с ником: " + login + " , был успешно удалён! \nВсе данные были успешно удалены!");
        }
    }

}

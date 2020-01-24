using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Djudo
{
    public partial class Reset : Page
    {
        public Reset() => InitializeComponent();
        void Login_Click(object sender, RoutedEventArgs e) => QueryBD.Navigate(QueryBD.log);
        void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "" || TryPassword.Password == "" || Password.Password != TryPassword.Password) { Error.Content = "Error: Entry login, password, email, trypassword, password != trypassword"; return; }
            var users = QueryBD.bd.Users.Where(u => u.Login == Login.Text && u.Email == Email.Text);
            if (users.Count() == 0) { Error.Content = "Error: неверные данные."; return; }
            QueryBD.user = users.First();
            QueryBD.user.Password = QueryBD.GetMd5Hash(Password.Password);
            QueryBD.bd.SaveChanges();
            QueryBD.Navigate(QueryBD.log);
        }
        void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (QueryBD.reg == null) QueryBD.reg = new Registration();
            QueryBD.Navigate(QueryBD.reg);
        }
    }
}

using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Djudo
{
    public partial class Registration : Page
    {
        public Registration() => InitializeComponent();
        void Login_Click(object sender, RoutedEventArgs e) => QueryBD.Navigate(QueryBD.log);
        void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (QueryBD.res == null) QueryBD.res = new Reset();
            QueryBD.Navigate(QueryBD.res);
        }
        void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Email.Text == "" || Password.Password == "" || TryPassword.Password == "" || Password.Password != TryPassword.Password) { Error.Content = "Error: Entry login, email, password, trypassword, password != trypassword"; return; }
            if (QueryBD.bd.Users.Where(u => u.Login == Login.Text).Count() != 0) { Error.Content = "Error: такой логин существует."; return; }
            QueryBD.user = new User() { Login = Login.Text, Email = Email.Text, Password = QueryBD.GetMd5Hash(Password.Password) };
            QueryBD.bd.Users.Add(QueryBD.user);
            QueryBD.bd.SaveChanges();
            QueryBD.Navigate(QueryBD.log);
        }
    }
}
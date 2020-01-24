using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Djudo
{
    public partial class Login : Page
    {
        public Login() => InitializeComponent();
        void Login_Click(object o, RoutedEventArgs e)
        {
            if (login.Text == "" || Password.Password == "") return;
            var pass = QueryBD.GetMd5Hash(Password.Password);
            var uses = QueryBD.bd.Users.Where(u => u.Login == login.Text && u.Password == pass);
            if (uses.Count() != 0)
            {
                QueryBD.user = uses.First();
                if (QueryBD.mainctrl == null) QueryBD.mainctrl = new MainCtrl();
                QueryBD.Navigate(QueryBD.mainctrl);
            }
        }
        void Reg_Click(object o, RoutedEventArgs e)
        {
            if (QueryBD.reg == null) QueryBD.reg = new Registration();
            QueryBD.Navigate(QueryBD.reg);
        }
        void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (QueryBD.res == null) QueryBD.res = new Reset();
            QueryBD.Navigate(QueryBD.res);
        }
    }
}
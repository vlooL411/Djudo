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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            QueryBD.window = this;
            gr.Children.Add(QueryBD.fr);
            QueryBD.Navigate(QueryBD.log);
        }

        void Back_Click(object o, RoutedEventArgs e) => QueryBD.Back();

        void Button_Click(object o, RoutedEventArgs e)
        {
            QueryBD.user = null;
            QueryBD.tat = null;
            QueryBD.гручастник = null;
            QueryBD.участник = null;
            QueryBD.Navigate(QueryBD.log);
        }
    }
}

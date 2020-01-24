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
    public partial class Участники : Page
    {
        public Участники()
        {
            InitializeComponent();
            Update();
        }
        public void Update() => Uch.ItemsSource = QueryBD.bd.Uchastnicks.ToList();

        void Edit_Click(object o, RoutedEventArgs e)
        {
            if (Uch.SelectedItem != null) QueryBD.ModeУчастник(Uch.SelectedItem as Uchastnick);
            else MessageBox.Show("Выберите участника для модификации");
        }
        void Add_Click(object sender, RoutedEventArgs e) => QueryBD.ModeУчастник(null);
    }
}
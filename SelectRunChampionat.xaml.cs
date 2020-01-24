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
    public partial class SelectRunChampionat : Page
    {
        public SelectRunChampionat()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            Tat.ItemsSource = QueryBD.bd.ChampionatConfigs.ToList();
        }

        void Button_Click(object o, RoutedEventArgs e)
        {
            if (Tat.SelectedItem != null)
            {
                if (QueryBD.sorev == null) QueryBD.sorev = new SorevnovanieShow();
                QueryBD.Navigate2(QueryBD.sorev);
                QueryBD.sorev.Update(Tat.SelectedItem as ChampionatConfig);
            }
        }
    }
}

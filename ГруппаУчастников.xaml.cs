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
    public partial class ГруппаУчастников : Page
    {
        public ГруппаУчастников()
        {
            InitializeComponent();
            Champ.ItemsSource = QueryBD.bd.ChampionatConfigs.ToArray();
            if (Champ.Items.Count != 0) Champ.SelectedIndex = 0;
        }

        void Champ_SelectionChanged(object o, SelectionChangedEventArgs e)
        {
            TableStatistick.Children.Clear();
            TableStatistick.Children.Add(new TableStat(Champ.SelectedItem as ChampionatConfig));
        }
    }
}

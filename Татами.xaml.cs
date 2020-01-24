using System.Linq;
using System.Windows.Controls;

namespace Djudo
{
    public partial class Татами : Page
    {
        public Татами()
        {
            InitializeComponent();
            lb.ItemsSource = QueryBD.bd.Tatamis.ToArray();
            if (lb.Items.Count != 0) lb.SelectedIndex = 0;
            Update();
        }

        public void Update()
        {
            if (lb.Items.Count != 0)
            {
                var tat = (lb.SelectedItem as Tatami).ID;
                Tat.ItemsSource = QueryBD.bd.UchastChamps.Where(s => s.ChampionatConfig.Tatami.ID == tat).ToList();
            }
        }

        void lb_SelectionChanged(object o, SelectionChangedEventArgs e) => Update();
    }
}
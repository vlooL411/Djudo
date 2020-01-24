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
    public partial class TableStat : UserControl
    {
        public TableStat(ChampionatConfig conf)
        {
            InitializeComponent();
            if (conf == null) return;
            var uchs = new SortedDictionary<int?, UchastChamp>();
            foreach (var uch in conf.UchastChamps)
                uchs.Add(uch.OrderNum, uch);
            var luch = new List<UchastChamp>();
            foreach (var u in uchs)
                luch.Add(u.Value);
            for (int i = 0, j = 1; i < 6; i += 3)
            {
                if (i > luch.Count - 1) break;
                var tb = new TbGroup() { conf = conf, OrderGroup = j++ };
                tb.uch1 = luch[i];
                if (luch.Count > i + 1) tb.uch2 = luch[i + 1];
                if (luch.Count > i + 2) tb.uch3 = luch[i + 2];
                gr.Children.Add(new TableGroup(tb));
            }
            if (luch.Count > 3) gr.Children.Add(new TableGroupWin(luch, conf));
        }
    }
}

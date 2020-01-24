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
    public class Uch
    {
        public Uchastnick uch { get; set; }
        public int? I { get; set; }
        public int? V { get; set; }
        public int? W { get; set; }
    }
    public class Sorev
    {
        public ChampionatConfig conf { get; set; }
        public ChampionatConfig nextConf { get; set; }

        public Uch white { get; set; }
        public Uch red { get; set; }
        public double? Time { get; set; }

        public string nextWhite { get; set; }
        public string nextRed { get; set; }
    }
    public partial class ChampionatShow : Page
    {
        public ChampionatShow()
        {
            InitializeComponent();
        }
        public void Update(Sorevnovanie sor, Sorevnovanie nextSor)
        {
            if (sor == null) return;
            var s = new Sorev();
            s.conf = sor.UchastChamp.ChampionatConfig;

            s.white = new Uch();
            s.white.uch = sor.UchastChamp.Uchastnick;
            s.white.I = GetCountRule(sor.UchastChamp, "Ippon", sor.ID);
            s.white.V = GetCountRule(sor.UchastChamp, "Vazari", sor.ID);
            s.white.W = GetCountRule(sor.UchastChamp, "Warning", sor.ID);

            s.red = new Uch();
            s.red.uch = sor.UchastChamp1.Uchastnick;
            s.red.I = GetCountRule(sor.UchastChamp1, "Ippon", sor.ID);
            s.red.V = GetCountRule(sor.UchastChamp1, "Vazari", sor.ID);
            s.red.W = GetCountRule(sor.UchastChamp1, "Warning", sor.ID);

            s.Time = sor.TimeRound;

            if (nextSor != null)
            {
                s.nextConf = nextSor.UchastChamp.ChampionatConfig;
                s.nextWhite = nextSor.UchastChamp.Uchastnick.Name;
                s.nextRed = nextSor.UchastChamp.Uchastnick.Name;
            }

            DataContext = s;
        }
        int? GetCountRule(UchastChamp u, string rule, int IDSor) => u?.Rules.Where(r => r.IDSorevnovanie == IDSor && r.Name == rule).Count();

        void Next_Click(object o, RoutedEventArgs e) => QueryBD.sorev.Next();
    }
}

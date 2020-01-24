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
    public partial class TableGroupWin : UserControl
    {
        UchastChamp u1Win, u1Win2, u2Win, u2Win2;
        public TableGroupWin(List<UchastChamp> uchs, ChampionatConfig champ)
        {
            DataContext = champ;
            InitializeComponent();
            Fill(0, uchs, ref u1Win, ref u1Win2);
            WinGroup1.Content = u1Win?.Uchastnick.Name;
            Place2WinGroup1.Content = u1Win2?.Uchastnick.Name;
            Fill(3, uchs, ref u2Win, ref u2Win2);
            WinGroup2.Content = u2Win?.Uchastnick.Name;
            Place2WinGroup2.Content = u2Win2?.Uchastnick.Name;
        }
        int GetCountWinGroup(UchastChamp uc) => uc.Sorevnovanies.Where(u => u.Winner == 0 && u.Red == uc.ID || u.Winner == 1 && u.White == uc.ID).Count();
        void Fill(int i, List<UchastChamp> uchs, ref UchastChamp u1, ref UchastChamp u2)
        {
            if (uchs.Count < i + 1) return;
            int im = i + 1;
            int ie = i + 2;
            int countWinGr1 = GetCountWinGroup(uchs[i]);
            int countWinGr2 = uchs.Count > im ? GetCountWinGroup(uchs[im]) : 0;
            int countWinGr3 = uchs.Count > ie ? GetCountWinGroup(uchs[ie]) : 0;
            if (countWinGr1 == 0 && countWinGr2 == 0 && countWinGr3 == 0) return;
            else
            {
                var cW = new SortedDictionary<int, int>();
                cW.Add(i, countWinGr1); cW.Add(im, countWinGr2); cW.Add(ie, countWinGr3);
                var j = 0;
                foreach (var c in cW)
                {
                    if (j == 2) break;
                    else if (j == 0) u1 = uchs[c.Key];
                    else if (j == 1) u2 = uchs[c.Key];
                    j++;
                }
            }
        }
    }
}
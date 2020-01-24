using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Djudo
{
    public class TbGroup
    {
        public ChampionatConfig conf { get; set; }
        public int OrderGroup { get; set; }
        public UchastChamp uch1 { get; set; }
        public UchastChamp uch2 { get; set; }
        public UchastChamp uch3 { get; set; }
    }
    public class convert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                if ((value as string).IndexOf("m") != -1) return "Муж";
                else return "Жен";
            else return "Жен";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class TableGroup : UserControl
    {
        public TableGroup(TbGroup tb)
        {
            DataContext = tb;
            InitializeComponent();
            if (tb.uch1 != null && tb.uch2 != null || tb.uch3 != null)
            {
                if (tb.uch2 != null)
                {
                    Win12.Content = GetCountWinGroup(tb.uch1) != 0 ? tb.uch1.Uchastnick.Name : tb.uch2.Uchastnick.Name;
                    Win21.Content = Win12.Content;
                }
                if (tb.uch3 != null)
                {
                    Win13.Content = GetCountWinGroup(tb.uch1) != 0 ? tb.uch1.Uchastnick.Name : tb.uch3.Uchastnick.Name;
                    Win31.Content = Win13.Content;
                }
                if (tb.uch2 != null && tb.uch3 != null)
                {
                    Win23.Content = GetCountWinGroup(tb.uch2) != 0 ? tb.uch2.Uchastnick.Name : tb.uch3.Uchastnick.Name;
                    Win32.Content = Win23.Content;
                }
                int GetCountWinGroup(UchastChamp uc) => uc.Sorevnovanies.Where(u => u.Winner == 0 && u.Red == uc.ID || u.Winner == 1 && u.White == uc.ID).Count();
            }
        }
    }
}
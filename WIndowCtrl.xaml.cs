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
    public partial class WIndowCtrl : Page
    {
        public WIndowCtrl()
        {
            InitializeComponent();
            grFrame.Children.Add(QueryBD.fr2);
            if (QueryBD.selectRun == null) QueryBD.selectRun = new SelectRunChampionat();
            QueryBD.Navigate2(QueryBD.selectRun);
        }
    }
}

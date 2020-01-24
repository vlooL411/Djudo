using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Djudo
{
    class QueryBD
    {
        static public DjudoEntities bd = new DjudoEntities();
        static public Frame fr = new Frame() { NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden };
        static public Frame fr2 = new Frame() { NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden };
        static public User user;

        static public ChampionatShow champ;
        static public SorevnovanieShow sorev;
        static public WIndowCtrl wCtrl;
        static public SelectRunChampionat selectRun;
        static public MainWindow window;
        static public Reset res;
        static public Registration reg;
        static public Login log = new Login();

        static public MainCtrl mainctrl;
        static public Участники участник;
        static public ГруппаУчастников гручастник;
        static public Татами tat;
        static public УчастникMode uchMode;

        static public void Close() { window.Close(); }
        static public void Back() { if (fr.CanGoBack) fr.GoBack(); }
        static public void Navigate(object o) { fr.Navigate(o); }

        static public void Back2() { if (fr2.CanGoBack) fr2.GoBack(); }
        static public void Navigate2(object o) { fr2.Navigate(o); }

        static public void ModeУчастник(Uchastnick uch)
        {
            uchMode = new УчастникMode(uch);
            uchMode.Show();
        }

        static public string GetMd5Hash(string input)
        {
            var md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
    }
}

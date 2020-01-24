using System;
using System.Windows;

namespace Djudo
{
    public partial class УчастникMode : Window
    {
        Uchastnick uch;
        public УчастникMode(Uchastnick uc)
        {
            DataContext = uc;
            uch = uc;
            InitializeComponent();
            if (uch?.Gender[0] == 'f')
                GenderF.IsChecked = true;
        }

        void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (QueryBD.user == null) Close();
            if (name.Text == "" || Birthday.SelectedDate == null || Sportclub.Text == "" || WT.Text == "0") return;
            if (uch == null)
            {
                uch = new Uchastnick();
                QueryBD.bd.Uchastnicks.Add(uch);
            }

            uch.Name = name.Text;
            uch.Gender = GenderM.IsChecked.Value ? "f" : "m";
            uch.Birthday = Birthday.SelectedDate.Value.ToString();
            uch.Birthtown = Birthtown.Text;
            uch.Street = Street.Text;
            uch.Sportsclub = Sportclub.Text;
            uch.Hometown = Hometown.Text;
            uch.Weight_kg = Convert.ToByte(Convert.ToDouble(WT.Text) % 256);

            QueryBD.bd.SaveChanges();
            QueryBD.участник.Update();
            Close();
        }

        void Close_Click(object sender, RoutedEventArgs e) => Close();
    }
}
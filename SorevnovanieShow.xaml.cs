using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Djudo
{
    public partial class SorevnovanieShow : Page
    {
        bool run, end = false;
        int current = 0;
        float time = 0;
        float timeWait = 0;
        List<Sorevnovanie> sors;
        public SorevnovanieShow()
        {
            InitializeComponent();
            if (QueryBD.champ == null) QueryBD.champ = new ChampionatShow();
            frame.Navigate(QueryBD.champ);

            var t = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    if (run)
                    {
                        time += 0.1f;
                        try { Dispatcher.Invoke(() => Timer.Text = time.ToString()); } catch { }
                    }
                    else timeWait += 0.1f;
                    if (end) break;
                }
            });
            t.Start();
            QueryBD.window.Closed += (o, e) => t.Abort();
        }
        void Run_Timer(object o, RoutedEventArgs e) => run = true;
        void Wait_Timer(object o, RoutedEventArgs e) => run = false;

        public void Next()
        {
            time = 0;
            timeWait = 0;
            run = false;
            if (++current < sors.Count)
            {
                QueryBD.champ.Update(sors[current], current + 1 < sors.Count ? sors[current + 1] : null);
                EndFight.Content = sors[current].Start;
                if (current + 1 < sors.Count) BeginNextFight.Content = sors[current + 1].Start;
                UpdateRules();
            }
            else if (current == 0)
            {
                MessageBox.Show("Соревнований нет", "Внимание");
                QueryBD.Navigate2(QueryBD.selectRun);
            }
            else
            {
                MessageBox.Show("Конец", "Внимание");
                QueryBD.Navigate2(QueryBD.selectRun);
            }
        }

        public void Update(ChampionatConfig champ)
        {
            sors = champ.Sorevnovanies.OrderByDescending(r => r.NumGroup).ToList();
            current = -1;
            Next();
        }
        void UpdateRules()
        {
            WhiteR.ItemsSource = null;
            RedR.ItemsSource = null;
            WhiteR.ItemsSource = sors[current].Rules.Where(r => r.IDUchastCamp == sors[current].White).OrderByDescending(r => r.Time).ToList();
            RedR.ItemsSource = sors[current].Rules.Where(r => r.IDUchastCamp == sors[current].Red).OrderByDescending(r => r.Time).ToList();
            if (current < sors.Count) QueryBD.champ.Update(sors[current], current + 1 < sors.Count ? sors[current + 1] : null);
        }

        void AddingRule(string rule, bool b, int score)
        {
            if (current >= sors.Count || !run) return;
            sors[current].Rules.Add(LastInput = new Rule() { Name = rule, Score = Convert.ToByte(score), IDUchastCamp = b ? sors[current].White : sors[current].Red, Time = time });
            QueryBD.bd.SaveChanges();
            UpdateRules();
        }
        void WhiteVazari_Click(object o, RoutedEventArgs e) => AddingRule("Vazari", true, 5);
        void WhiteIpon_Click(object o, RoutedEventArgs e) => AddingRule("Ippon", true, 10);
        void WhiteWarnings_Click(object o, RoutedEventArgs e) => AddingRule("Warning", true, 2);
        void RedIpon_Click(object o, RoutedEventArgs e) => AddingRule("Ippon", false, 10);
        void RedWarnings_Click(object o, RoutedEventArgs e) => AddingRule("Warning", false, 2);
        void RedVazari_Click(object o, RoutedEventArgs e) => AddingRule("Vazari", false, 5);
        Rule LastInput;
        void ResetInput_Click(object o, RoutedEventArgs e)
        {
            if (current >= sors.Count || LastInput == null) return;
            sors[current].Rules.Remove(LastInput);
            LastInput = null;
            QueryBD.bd.SaveChanges();
            UpdateRules();
            if (current < sors.Count) QueryBD.champ.Update(sors[current], current + 1 < sors.Count ? sors[current + 1] : null);
        }
    }
}
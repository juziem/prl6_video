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
using System.Media;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;

namespace lab6_video
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MediaPlayer player = new MediaPlayer();
        System.Windows.Threading.DispatcherTimer Timer;
        TimeSpan ts;


        public MainWindow()
        {
            InitializeComponent();

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            head.Content = player.Position.Hours + ":" + player.Position.Minutes + ":" + player.Position.Seconds;
            slide.Value = player.Position.TotalSeconds;
        }

       
        private void play_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            //slide.Source = new Uri(dlg.FileName, UriKind.Relative);
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            Timer.Stop();
            head.Content = "";
        }
    }
}

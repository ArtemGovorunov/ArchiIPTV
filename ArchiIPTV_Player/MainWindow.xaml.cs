using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace ArchiIPTV_Player
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool FullScreen;

        public MainWindow()
        {

            while(string.IsNullOrEmpty(Properties.Settings.Default.M3UFile))
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.ShowDialog();
            }
            InitializeComponent();

            DataContext = new ViewModel.PlayerViewModel() { Player = myVLC };

            //DataContext = new ViewModel.ChanelsViewModel();
            /*
            string linkUrl = "tv.lan.ua";
            string result = string.Empty;

            WebClient client = new WebClient();
            try
            {
                using (Stream stream = client.OpenRead("http://" + linkUrl))
                {
                    using (StreamReader reader = new StreamReader(stream))
                        result = reader.ReadToEnd();
                }
                if (!string.IsNullOrEmpty(result))
                {
                    Properties.Settings.Default.M3UFile = result;
                    Properties.Settings.Default.CurrentChanalSet = 0;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    throw new Exception();
                }

            }
            catch
            {
                throw new Exception();
            }*/
            
        }

        private void VlcMenuTopScreen_Click(object sender, RoutedEventArgs e)
        {
            //    if (vlcMenuTopScreen.IsChecked)
            //        this.Topmost = true;
            //    else
            //        this.Topmost = false;
        }

        private void ButtonFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (!FullScreen)
            {
                //Переводим в фуллСкрин
                FullScreenButton.Content = Char.ConvertFromUtf32(0xE73F);
                FullScreen = true;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                if (WindowState == WindowState.Maximized)//Костыль. Это не хорошо...
                    WindowState = WindowState.Normal;
                WindowState = WindowState.Maximized;
                Topmost = true;
                SettingsButton.Visibility = Visibility.Hidden;
            }
            else
            {
                FullScreenButton.Content = Char.ConvertFromUtf32(0xE740);
                FullScreen = false;
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                WindowState = WindowState.Normal;
                Topmost = false;
                SettingsButton.Visibility = Visibility.Visible;
            }
        }

        private void ButtonPlaylist_Click(object sender, RoutedEventArgs e)
        {
            if (!(PlaylistPanel.Visibility == Visibility.Collapsed))
            {
                PlaylistPanel.Visibility = Visibility.Collapsed;
                PlaylistSplitter.Visibility = Visibility.Collapsed;

                Grid.SetColumnSpan(myVLC, 3);
                Grid.SetColumnSpan(ButtomPanel, 3);
            }
            else
            {
                PlaylistPanel.Visibility = Visibility.Visible;
                PlaylistSplitter.Visibility = Visibility.Visible;
                Grid.SetColumnSpan(myVLC, 1);
                Grid.SetColumnSpan(ButtomPanel, 1);
            }
        }

        private void MyVLC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            {//TODO: Придумать как оно должно работать через вьюМодель и по нормальному
                if (ButtomPanel.Visibility != Visibility.Collapsed)
                {
                    if (PlaylistPanel.Visibility == Visibility.Visible)
                        ButtonPlaylist_Click(sender, new RoutedEventArgs());
                    ButtomPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    //ButtonPlaylist_Click(sender, new RoutedEventArgs());
                    ButtomPanel.Visibility = Visibility.Visible;
                }

            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            string current = Properties.Settings.Default.M3UFile;
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            if (current != Properties.Settings.Default.M3UFile)
            {
                try
                {
                    ListBoxChanels.ItemsSource = CollectionViewSource.GetDefaultView(Chanels.GetChanelsFromM3U(Properties.Settings.Default.M3UFile));
                    ListBoxChanels.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Message + "\n" + ex.Data.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}

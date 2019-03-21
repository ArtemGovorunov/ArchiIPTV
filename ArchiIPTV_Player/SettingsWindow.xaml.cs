using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace ArchiIPTV_Player
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }
        private void Button_GetFromLocalM3U(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                Properties.Settings.Default.M3UFile = File.ReadAllText(ofd.FileName);
                Properties.Settings.Default.CurrentChanalSet = 0;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void Button_GetFromInternetUrl(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            WebClient client = new WebClient();
            try
            {
                using (Stream stream = client.OpenRead("http://" + linkUrl.Text))
                {
                    using (StreamReader reader = new StreamReader(stream))
                        result = reader.ReadToEnd();
                }
                if (!string.IsNullOrEmpty(result))
                {
                    Properties.Settings.Default.M3UFile = result;
                    Properties.Settings.Default.CurrentChanalSet = 0;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Ссылка активна, но плейлист не получен");
                }

            }
            catch
            {
                System.Windows.MessageBox.Show("M3U Плейлист не найден по этому адресу", "Ошибка получения плейлиста", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

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
        public MainWindow()
        {
            InitializeComponent();

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
        
    }
}

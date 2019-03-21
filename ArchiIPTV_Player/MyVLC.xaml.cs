using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для MyVLC.xaml
    /// </summary>
    public partial class MyVLC : UserControl
    {
        public MyVLC()
        {
            InitializeComponent();
            
        }
        
        public Chanel MediaSource
        {
            get { return (Chanel)GetValue(MediaSourceProperty); }
            set { SetValue(MediaSourceProperty, value); }
        }

        public static readonly DependencyProperty MediaSourceProperty =
            DependencyProperty.Register("MediaSource", typeof(Chanel), typeof(MyVLC), new PropertyMetadata(null,new PropertyChangedCallback(MediaSourcePropertyChangedCallback)));

        private static void MediaSourcePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyVLC originator = d as MyVLC;
            if (originator != null)
            {
                originator.OnMediaSourcePropertyChanged(e);
            }
        }
        
        private void OnMediaSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if ((Chanel)e.NewValue != null)
            {
                //this.State = Meta.Vlc.MediaState.Playing;
                vlcPlayer.LoadMedia(MediaSource.Adress);
                vlcPlayer.Play();
            }

        }



        public int Volume
        {
            get { return (int)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Volume.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(int), typeof(MyVLC), new PropertyMetadata(100,new PropertyChangedCallback(VolumePropertyChangedCallback)));

        private static void VolumePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyVLC originator = d as MyVLC;
            if (originator != null)
            {
                originator.OnVolumePropertyChanged(e);
            }
        }

        private void OnVolumePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            vlcPlayer.Volume = (int)e.NewValue;
        }

        
        /*
        public bool MuteStatus
        {
            get { return (bool)GetValue(MuteProperty); }
            set { SetValue(MuteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MuteProperty =
            DependencyProperty.Register("MuteStatus", typeof(bool), typeof(MyVLC), new PropertyMetadata(false));

        

        /*

        public Meta.Vlc.MediaState State
        {
            get { return (Meta.Vlc.MediaState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(Meta.Vlc.MediaState), typeof(MyVLC), new PropertyMetadata(Meta.Vlc.MediaState.NothingSpecial,StatePropertyCallback));

        private static void StatePropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyVLC originator = d as MyVLC;
            if (originator != null)
            {
                originator.OnStatePropertyChanged(e);
            }
        }

        private void OnStatePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case Meta.Vlc.MediaState.Playing:
                    vlcPlayer.Play();
                    break;
                case Meta.Vlc.MediaState.Paused:
                    vlcPlayer.Pause();
                    break;
                case Meta.Vlc.MediaState.Stopped:
                    vlcPlayer.Stop();
                    break;
                default:

                    break;

            }
        }*/

        public void Play()
        {
            vlcPlayer.Play();
        }
        public void Stop()
        {
            vlcPlayer.Stop();
        }

        public void Mute()
        {
            vlcPlayer.ToggleMute();
        }

        ~MyVLC()
        {
            if (vlcPlayer != null)
            {
                vlcPlayer.Stop();
                vlcPlayer.Dispose();
            }
        }
    }
}

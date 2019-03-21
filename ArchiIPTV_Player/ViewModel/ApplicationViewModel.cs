﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ArchiIPTV_Player.ViewModel
{
    class ApplicationViewModel:DependencyObject
    {
        public ApplicationViewModel()
        {
            ChanelCollection = CollectionViewSource.GetDefaultView(Chanels.GetChanelsFromFile_m3u());
            ChanelCollection.Filter = FilterChanels;
            //SelectedIndex = Properties.Settings.Default.CurrentChanalSet;
        }

        

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(ApplicationViewModel), new PropertyMetadata(Properties.Settings.Default.CurrentChanalSet,new PropertyChangedCallback(SelectedChanelPropertyChangedCallback)));
        
        private static void SelectedChanelPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Properties.Settings.Default.CurrentChanalSet = (int)e.NewValue;
            Properties.Settings.Default.Save();
        }
        
        public Chanel SelectedChanel
        {
            get { return (Chanel)GetValue(SelectedChanelProperty); }
            set { SetValue(SelectedChanelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedChanel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedChanelProperty =
            DependencyProperty.Register("SelectedChanel", typeof(Chanel), typeof(ApplicationViewModel));



        public string FilterChanel
        {
            get { return (string)GetValue(FilterChanelProperty); }
            set { SetValue(FilterChanelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterChanel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterChanelProperty =
            DependencyProperty.Register("FilterChanel", typeof(string), typeof(ApplicationViewModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cur = d as ApplicationViewModel;
            if (cur != null)
            {
                cur.ChanelCollection.Filter = null;
                cur.ChanelCollection.Filter = cur.FilterChanels;
            }
        }

        public ICollectionView ChanelCollection
        {
            get { return (ICollectionView)GetValue(ChanelProperty); }
            set { SetValue(ChanelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChanelProperty =
            DependencyProperty.Register("ChanelCollection", typeof(ICollectionView), typeof(ApplicationViewModel), new PropertyMetadata(null));

        private bool FilterChanels(object obj)
        {
            Chanel cur = obj as Chanel;
            if (cur != null && !(cur.Title.ToLower().Contains(FilterChanel.ToLower())))
                return false;
            return true;
        }




        public Meta.Vlc.MediaState PlayedStatus
        {
            get { return (Meta.Vlc.MediaState)GetValue(PlayedStatusProperty); }
            set { SetValue(PlayedStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayedStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayedStatusProperty =
            DependencyProperty.Register("PlayedStatus", typeof(Meta.Vlc.MediaState), typeof(ApplicationViewModel));




    }
}

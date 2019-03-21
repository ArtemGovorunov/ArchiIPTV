using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArchiIPTV_Player.ViewModel
{
    class PlayerViewModel : DependencyObject
    {
        public PlayerViewModel()
        {
            this.MediaCommand = new PlayerCommands(this);
        }
        public MyVLC Player { set; get; }
        public bool CanCommandExecute { set; get; }
        public ICommand MediaCommand { set; get; }
    }
}

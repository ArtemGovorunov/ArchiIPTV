using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArchiIPTV_Player
{
    class PlayerCommands : ICommand
    {
        private ViewModel.PlayerViewModel vm;
        public PlayerCommands(ViewModel.PlayerViewModel vm)
        {
            this.vm = vm;
        }
         
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string action = (string)parameter;
            switch (action.ToLower())
            {
                case "play":
                    vm.Player.Play();
                    break;
                case "stop":
                    vm.Player.Stop();
                    break;
                case "mute":
                    vm.Player.Mute();
                    break;/*
                case "resume":
                    vm.MediaElement.Play();
                    break;*/
                default:
                    throw new NotSupportedException(String.Format("Unknown media action {0}", action));
            }
        }
    }
}

using SampleApplication.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SampleApplication.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase() 
        {
            CloseAppCommand = new BaseCommand(CloseApp);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CloseAppCommand { get; }

        private void CloseApp(object value)
        {
            Environment.Exit(0);
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IssueTracker.ViewModels
{
    // clasa de baza pentru toate ViewModel-urile
    // orice ViewModel inherits from here ca sa suporte data binding
    public class BindableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
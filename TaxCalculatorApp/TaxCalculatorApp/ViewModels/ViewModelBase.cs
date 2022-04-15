using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxCalculatorApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var evt = PropertyChanged;
            if (evt == null)
            {
                return;
            }

            evt(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

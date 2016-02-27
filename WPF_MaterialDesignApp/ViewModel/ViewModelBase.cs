using System.ComponentModel;

namespace WPF_MaterialDesignApp.ViewModel
{
    /// <summary>
    /// Base class for view models. Implements INotifyPropertyChanged to track changes of the properties.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
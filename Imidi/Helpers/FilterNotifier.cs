using System;
using System.ComponentModel;

namespace Imidi.Helpers
{
    public class FilterNotifier : INotifyPropertyChanged
    {
        #region Singletone
        private static Lazy<FilterNotifier> _instance = new Lazy<FilterNotifier>();
        public static FilterNotifier Instance => _instance.Value;
        #endregion

        private string _currentFilter;

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action FilterChanged;

        public string CurrentFilter
        {
            get => _currentFilter;
            set
            {
                _currentFilter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentFilter)));
                FilterChanged?.Invoke();
            }
        }
    }
}

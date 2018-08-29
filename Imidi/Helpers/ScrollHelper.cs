using System;
using System.Windows.Input;
using WPFControls.ColumnsListBox;

namespace Imidi.Helpers
{
    public class ScrollHelper
    {
        #region Singletone
        private static Lazy<ScrollHelper> _instance = new Lazy<ScrollHelper>(() => new ScrollHelper());
        public static ScrollHelper Instance => _instance.Value;
        protected ScrollHelper()
        {
            InitializeCommands();
        }        
        #endregion

        public ICommand ScrollDown { get; private set; }
        public ICommand ScrollUp { get; private set; }
        public ICommand ScrollHome { get; private set; }
        public ICommand ScrollEnd { get; private set; }
        public ICommand PageDown { get; private set; }
        public ICommand PageUp { get; private set; }

        private void InitializeCommands()
        {
            ScrollDown = new RelayCommand(param => GetColumnsListBox(param).ScrollDown());
            ScrollUp = new RelayCommand(param => GetColumnsListBox(param).ScrollUp());
            ScrollHome = new RelayCommand(param => GetColumnsListBox(param).ScrollHome());
            ScrollEnd = new RelayCommand(param => GetColumnsListBox(param).ScrollEnd());
            PageDown = new RelayCommand(param => GetColumnsListBox(param).PageDown());
            PageUp = new RelayCommand(param => GetColumnsListBox(param).PageUp());
        }

        private ColumnsListBox GetColumnsListBox(object param)
        {
            if (!(param is ColumnsListBox columnsListBox))
                throw new ArgumentException($"Expected parameter type: 'ColumnsListBox'. Given type: '{ param?.GetType() }'.");            
            return columnsListBox;
        }

    }
}

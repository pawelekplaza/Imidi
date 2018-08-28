using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Imidi.Helpers
{
    public class FilesScrollViewerHelper
    {
        #region Singleton
        private static Lazy<FilesScrollViewerHelper> _instance = new Lazy<FilesScrollViewerHelper>(() => new FilesScrollViewerHelper());
        public static FilesScrollViewerHelper Instance => _instance.Value;
        protected FilesScrollViewerHelper()
        {
            InitializeCommands();
        }
        #endregion

        public const double VerticalStep = 14.05;

        public ICommand PageUp { get; private set; }
        public ICommand PageDown { get; private set; }
        public ICommand ScrollHome { get; private set; }
        public ICommand ScrollEnd { get; private set; }

        private void InitializeCommands()
        {
            PageUp = new RelayCommand(param =>
            {
                GetScrollViewer(param).PageUp();
            });
            PageDown = new RelayCommand(param =>
            {
                GetScrollViewer(param).PageDown();
            });
            ScrollHome = new RelayCommand(param =>
            {
                GetScrollViewer(param).ScrollToHome();
            });
            ScrollEnd = new RelayCommand(param =>
            {
                GetScrollViewer(param).ScrollToEnd();
            });
        }

        private void Scroll(object param, double offset)
        {
            var scroll = GetScrollViewer(param);
            scroll.VerticalScroll(offset);
        }

        private ScrollViewer GetScrollViewer(object param)
        {
            if (!(param is ScrollViewer scrollViewer))
                throw new ArgumentException($"Expected type of object: 'ScrollViewer'. Given type: '{ param?.GetType() }'.");
            return scrollViewer;
        }
    }
}

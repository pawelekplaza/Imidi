using Imidi.Helpers;
using System.Windows;
using System.Windows.Input;

namespace Imidi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext.PropertyChanged("LoadTime");
            PreviewMouseLeftButtonDown += OnMainWindowPreviewMouseLeftButtonDown;
            Loaded += OnMainWindowLoaded;
            FilterNotifier.Instance.FilterChanged += () => filesListBox.ScrollHome();
        }

        private void OnMainWindowPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            filterFake.Focus();
            DragMove();            
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {            
            filterFake.Focus();            
        }

        public ICommand GoToUpperPath => pathControl.GoToUpperPath;
    }
}

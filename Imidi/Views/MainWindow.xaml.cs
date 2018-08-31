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
            PreviewTextInput += OnMainWindowTextInput;

            FilterNotifier.Instance.FilterChanged += () => filesListBox.ScrollHome();
        }

        private void OnMainWindowTextInput(object sender, TextCompositionEventArgs e)
        {
            FilterNotifier.Instance.CurrentFilter += e.Text;
        }

        private void OnMainWindowPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CanClearFilter(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = FilterNotifier.Instance.CurrentFilter.Length > 0;
        }

        private void ClearFilter(object sender, ExecutedRoutedEventArgs e)
        {
            FilterNotifier.Instance.ClearFilter();
        }

        private void CanMaximizeOrNormalizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MaximizeOrNormalizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CanCloseWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}

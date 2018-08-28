using Imidi.Commands;
using Imidi.Helpers;
using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Imidi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseLeftButtonDown += OnMainWindowPreviewMouseLeftButtonDown;
            Loaded += OnMainWindowLoaded;
            FilterNotifier.Instance.FilterChanged += () => filesScrollViewer.ScrollToHome();
        }

        private void OnMainWindowPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            filterFake.Focus();
            DragMove();
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            filterFake.Focus();
            DataContext.PropertyChanged("LoadTime");
        }

        public ICommand GoToUpperPath => pathControl.GoToUpperPath;
    }
}

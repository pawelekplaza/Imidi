using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Imidi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindowViewModel.StartTime = DateTime.Now;
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}

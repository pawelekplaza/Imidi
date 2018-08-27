using Imidi.Helpers;
using System;
using System.Windows;

namespace Imidi.Commands
{
    public static class MainWorkflowCommands
    {
        public static RelayCommand MaximizeOrNormalizeWindow => _maximizeOrNormalizeWindow;
        public static RelayCommand CloseWindow => _closeWindow;

        private static RelayCommand _maximizeOrNormalizeWindow = new RelayCommand(param =>
        {
            var window = GetWindow(param);
            window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        });

        private static RelayCommand _closeWindow = new RelayCommand(param =>
        {
            var window = GetWindow(param);
            window.Close();
        });

        private static Window GetWindow(object param)
        {
            if (!(param is Window window))
                throw new ArgumentException($"Expected param type: 'Window'. Given type: { param?.GetType() }.");
            return window;
        }
    }
}

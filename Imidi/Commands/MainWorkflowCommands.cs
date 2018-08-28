using Imidi.Helpers;
using System;
using System.Windows;
using System.Windows.Input;

namespace Imidi.Commands
{
    public static class MainWorkflowCommands
    {
        public static ICommand MaximizeOrNormalizeWindow { get; private set; }
        public static ICommand CloseWindow { get; private set; }

        static MainWorkflowCommands()
        {
            MaximizeOrNormalizeWindow = new RelayCommand(param =>
            {
                var window = GetWindow(param);
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            });
            CloseWindow = new RelayCommand(param =>
            {
                var window = GetWindow(param);
                window.Close();
            });
        }

        private static Window GetWindow(object param)
        {
            if (!(param is Window window))
                throw new ArgumentException($"Expected param type: 'Window'. Given type: { param?.GetType() }.");
            return window;
        }
    }
}

using Imidi.Helpers;
using System;
using System.Windows;
using System.Windows.Input;

namespace Imidi
{
    public static class MainWorkflowCommands
    {
        public static readonly RoutedCommand CloseWindow = new RoutedCommand();
        public static readonly RoutedCommand MaximizeOrNormalizeWindow = new RoutedCommand();
        public static readonly RoutedCommand GoToUpperPath = new RoutedCommand();
    }
}

﻿using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Imidi.Helpers
{
    public class FilesScrollViewerHelper
    {
        #region Singleton
        private static Lazy<FilesScrollViewerHelper> _instance = new Lazy<FilesScrollViewerHelper>();
        public static FilesScrollViewerHelper Instance => _instance.Value;
        #endregion

        public const double VerticalStep = 14.05;

        public ICommand ScrollUp { get; private set; }
        public ICommand ScrollDown { get; private set; }
        public ICommand PageUp { get; private set; }
        public ICommand PageDown { get; private set; }

        public FilesScrollViewerHelper()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ScrollUp = new RelayCommand(param =>
            {
                Scroll(param, -VerticalStep);
            });
            ScrollDown = new RelayCommand(param =>
            {
                Scroll(param, VerticalStep);
            });
            PageUp = new RelayCommand(param =>
            {
                GetScrollViewer(param).PageUp();
            });
            PageDown = new RelayCommand(param =>
            {
                GetScrollViewer(param).PageDown();
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

﻿using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Imidi.Helpers
{
    public class SelectionHelper
    {
        #region Singletone
        private static Lazy<SelectionHelper> _instance = new Lazy<SelectionHelper>(() => new SelectionHelper());
        public static SelectionHelper Instance => _instance.Value;
        protected SelectionHelper()
        {
            InitializeCommands();
        }
        #endregion

        public ICommand MoveRight { get; private set; }
        public ICommand MoveLeft { get; private set; }
        public ICommand MoveUp { get; private set; }
        public ICommand MoveDown { get; private set; }

        private void InitializeCommands()
        {
            MoveRight = new RelayCommand(param =>
            {
                var entries = GetEntries(param);
                var currentIndex = GetIndex(entries);
                if (currentIndex % SettingsHelper.NumberOfColumns == (SettingsHelper.NumberOfColumns - 1) || entries.Count == currentIndex + 1)
                    return;
                SelectionNotifier.Instance.Select(entries[currentIndex + 1]);
            });
            MoveLeft = new RelayCommand(param =>
            {
                var entries = GetEntries(param);
                var currentIndex = GetIndex(entries);
                if (currentIndex % SettingsHelper.NumberOfColumns == 0)
                    return;
                SelectionNotifier.Instance.Select(entries[currentIndex - 1]);
            });
            MoveUp = new RelayCommand(param =>
            {
                var entries = GetEntries(param);
                var currentIndex = GetIndex(entries);
                if (currentIndex - SettingsHelper.NumberOfColumns < 0)
                    return;
                SelectionNotifier.Instance.Select(entries[currentIndex - SettingsHelper.NumberOfColumns]);
            });
            MoveDown = new RelayCommand(param =>
            {
                var entries = GetEntries(param);
                var currentIndex = GetIndex(entries);
                if (currentIndex + SettingsHelper.NumberOfColumns >= entries.Count)
                    return;
                SelectionNotifier.Instance.Select(entries[currentIndex + SettingsHelper.NumberOfColumns]);
            });
        }

        private IList<FileEntry> GetEntries(object param)
        {
            if (!(param is IList<FileEntry> entries))
                throw new ArgumentException($"Expected type of param: 'IEnumerable<FileEntry>'. Given type: '{ param?.GetType() }'.");
            return entries;
        }

        private int GetIndex(IList<FileEntry> entries) =>
            entries.IndexOf(SelectionNotifier.Instance.CurrentSelection);
    }
}

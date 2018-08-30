using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WPFControls.ColumnsListBox.Helpers;

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

        private void InitializeCommands()
        {
            MoveRight = new RelayCommand(param =>
            {
                var entries = GetEntries(param);
                var currentIndex = GetIndex(entries);
                var destinedIndex = currentIndex + (int)Math.Ceiling((double)entries.Count / SettingsHelper.NumberOfColumns);
                if (destinedIndex >= entries.Count)
                    return;
                SelectionNotifier.Instance.Select(entries[destinedIndex]);
            });
            MoveLeft = new RelayCommand(param =>
            {
                var entries = GetEntries(param);
                var currentIndex = GetIndex(entries);
                var destinedIndex = currentIndex - (int)Math.Ceiling((double)entries.Count / SettingsHelper.NumberOfColumns);
                if (destinedIndex < 0)
                    return;
                SelectionNotifier.Instance.Select(entries[destinedIndex]);
            });
        }

        private IList<FileEntry> GetEntries(object param)
        {
            if (!(param is IList<FileEntry> entries))
                throw new ArgumentException($"Expected type of param: 'IEnumerable<FileEntry>'. Given type: '{ param?.GetType() }'.");
            return entries;
        }

        private int GetIndex(IList<FileEntry> entries) =>
            entries.IndexOf(SelectionNotifier.Instance.CurrentSelection as FileEntry);
    }
}

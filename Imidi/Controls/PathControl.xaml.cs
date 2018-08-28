using Imidi.Helpers;
using Imidi.Models;
using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Imidi.Controls
{
    public partial class PathControl : UserControl, INotifyPropertyChanged
    {
        private PathModel _model;
        private List<FileEntry> _entries = new List<FileEntry>();

        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentPath
        {
            get => _model.CurrentPath;
            set
            {
                _model.CurrentPath = value;
                RaisePropertyChanged(nameof(CurrentPath));
                UpdateFileEntries();
            }
        }

        public ObservableCollection<FileEntry> FileEntries
        {
            get => _model.FileEntries;
            set
            {
                _model.FileEntries = value;
                RaisePropertyChanged(nameof(FileEntries));
                RefreshVisibleEntries();
            }
        }

        public IList<FileEntry> VisibleEntries
        {
            get => _model.VisibleEntries;
            private set { _model.VisibleEntries = value; RaisePropertyChanged(nameof(VisibleEntries)); }
        }

        public ICommand GoToUpperPath { get; private set; }

        public PathControl()
        {
            _model = new PathModel();
            InitializeComponent();
            InitializeCommands();
            HookEvents();
            UpdateFileEntries();
        }

        private void InitializeCommands()
        {
            GoToUpperPath = new RelayCommand(param =>
            {
                var directoryInfo = new DirectoryInfo(CurrentPath);
                CurrentPath = directoryInfo?.Parent?.FullName ?? CurrentPath;
            });
        }

        private void FilterFileEntries(string filter)
        {
            foreach (var entry in FileEntries)
                entry.IsVisible = entry.Name.ToLower().Contains(filter.ToLower());
            RefreshVisibleEntries();
        }

        private void RefreshVisibleEntries()
        {
            VisibleEntries = FileEntries.Where(v => v.IsVisible).ToList();
            ResetSelectionIfNeeded();
        }

        private void ResetSelectionIfNeeded()
        {
            if (!VisibleEntries.Any(v => v == SelectionNotifier.Instance.CurrentSelection))
                SelectionNotifier.Instance.Select(VisibleEntries.FirstOrDefault());
        }

        private void HookEvents()
        {
            FilterNotifier.Instance.FilterChanged += () => FilterFileEntries(FilterNotifier.Instance.CurrentFilter);
        }

        private void UpdateFileEntries()
        {
            var entries = GetEntries();
            FileEntries = new ObservableCollection<FileEntry>(entries.Take(120));

            if (entries.Count > 120)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(20);
                    FileEntries = new ObservableCollection<FileEntry>(entries);
                });
            }
        }

        private List<FileEntry> GetEntries() =>
            Directory.EnumerateFileSystemEntries(CurrentPath).Select(v => new FileInfo(v).Name).Select(v => new FileEntry(v)).ToList();

        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

using Imidi.Helpers;
using Imidi.Models;
using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace Imidi.Controls
{
    public partial class PathControl : UserControl, INotifyPropertyChanged
    {
        private PathModel _model;

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
                RaisePropertyChanged(nameof(VisibleEntries));
            }
        }

        public IEnumerable<FileEntry> VisibleEntries => FileEntries.Where(v => v.IsVisible);

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
            RaisePropertyChanged(nameof(VisibleEntries));
        }

        private void HookEvents()
        {
            FilterNotifier.Instance.FilterChanged += () => FilterFileEntries(FilterNotifier.Instance.CurrentFilter);
        }

        private void UpdateFileEntries()
        {
            FileEntries = new ObservableCollection<FileEntry>(Directory.EnumerateFileSystemEntries(CurrentPath).Select(v => new FileInfo(v).Name).Select(v => new FileEntry(v)));
        }

        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

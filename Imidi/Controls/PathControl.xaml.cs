using Imidi.Helpers;
using Imidi.Models;
using Imidi.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WPFControls.ColumnsListBox.Helpers;

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

        public string ParentPath => new DirectoryInfo(CurrentPath)?.Parent?.FullName;

        public IList<FileEntry> FileEntries
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
            private set
            {
                _model.VisibleEntries = value;
                RaisePropertyChanged(nameof(VisibleEntries));
            }
        }

        public PathControl()
        {
            _model = new PathModel();
            InitializeComponent();
            HookEvents();
            UpdateFileEntries();
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
            FileEntries = GetEntries();
        }

        private IList<FileEntry> GetEntries() =>
            Directory.EnumerateFileSystemEntries(CurrentPath).Select(v => new FileInfo(v).Name).Select(v => new FileEntry(v)).ToList();

        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void CanExecuteGoToUpperPath(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ParentPath != null;
        }

        private void GoToUpperPath(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentPath = ParentPath;
        }
    }
}

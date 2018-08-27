using Imidi.Helpers;
using Imidi.Models;
using System;
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

        public PathControl()
        {
            _model = new PathModel();
            InitializeComponent();
            InitializeCommands();
        }

        public string CurrentPath
        {
            get { return _model.CurrentPath; }
            set
            {
                _model.CurrentPath = value;
                RaisePropertyChanged(nameof(CurrentPath));
                RaisePropertyChanged(nameof(FileEntries));
            }
        }

        public ObservableCollection<string> FileEntries =>
            new ObservableCollection<string>(Directory.EnumerateFileSystemEntries(CurrentPath).Select(v => new FileInfo(v).Name));

        public ICommand GoToUpperPath { get; private set; }

        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void InitializeCommands()
        {
            GoToUpperPath = new RelayCommand(param =>
            {
                var directoryInfo = new DirectoryInfo(CurrentPath);
                CurrentPath = directoryInfo?.Parent?.FullName ?? CurrentPath;
            });
        }
    }
}

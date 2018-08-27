using Imidi.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Imidi.Controls
{
    public partial class PathControl : UserControl, INotifyPropertyChanged
    {
        private PathControlModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public PathControl()
        {
            _model = new PathControlModel();
            InitializeComponent();            
        }

        public string CurrentPath
        {
            get { return _model.CurrentPath; }
            set { _model.CurrentPath = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPath))); }
        }

        public ObservableCollection<string> FileEntries =>
            new ObservableCollection<string>(Directory.EnumerateFileSystemEntries(CurrentPath).Select(v => new FileInfo(v).Name));
    }
}

using System.Windows.Media;
using WPFControls.ColumnsListBox.Helpers;
using WPFControls.ColumnsListBox.Helpers.Interfaces;

namespace Imidi.ViewModels
{
    public class FileEntry : ViewModelBase, ISelectable
    {
        private static readonly SolidColorBrush SelectedBackground = new SolidColorBrush(Color.FromRgb(0x30, 0x30, 0x30));

        private string _name;
        private bool _isVisible = true;
        private bool _isSelected;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(nameof(Name)); }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; RaisePropertyChanged(nameof(IsVisible)); }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
                RaisePropertyChanged(nameof(Background));
                if (value)
                    SelectionNotifier.Instance.Select(this);
            }
        }

        public SolidColorBrush Background => IsSelected ? SelectedBackground : null;

        public FileEntry() : this("") { }

        public FileEntry(string name)
        {
            Name = name;
        }
    }
}

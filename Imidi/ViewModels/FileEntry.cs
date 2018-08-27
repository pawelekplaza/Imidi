namespace Imidi.ViewModels
{
    public class FileEntry : ViewModelBase
    {
        private string _name;
        private bool _isVisible = true;

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

        public FileEntry() { }

        public FileEntry(string name)
        {
            Name = name;
        }
    }
}

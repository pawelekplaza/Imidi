using Imidi.Models;

namespace Imidi.ViewModels
{
    public class PathControlViewModel : ViewModelBase
    {
        private PathControlModel _model;

        public string CurrentPath
        {
            get => _model.CurrentPath;
            set { _model.CurrentPath = value; RaisePropertyChanged(nameof(CurrentPath)); }
        }

        public PathControlViewModel()
        {
            _model = new PathControlModel();
        }

        public PathControlViewModel(PathControlModel model)
        {
            _model = model;
        }
    }
}

using Imidi.ViewModels;
using System;

namespace Imidi.Helpers
{
    public class SelectionNotifier
    {
        #region Singletone
        private static Lazy<SelectionNotifier> _instance = new Lazy<SelectionNotifier>(() => new SelectionNotifier());
        public static SelectionNotifier Instance => _instance.Value;
        protected SelectionNotifier() { }
        #endregion

        public FileEntry CurrentSelection { get; private set; }

        public void Select(FileEntry file)
        {
            if (CurrentSelection != null)
                CurrentSelection.IsSelected = false;

            if (file != null)
                file.IsSelected = true;

            CurrentSelection = file;
        }
    }
}

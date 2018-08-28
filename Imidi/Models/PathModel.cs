using Imidi.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Imidi.Models
{
    public class PathModel
    {
        public string CurrentPath { get; set; }
        public ObservableCollection<FileEntry> FileEntries { get; set; }
        public IList<FileEntry> VisibleEntries { get; set; }

        public PathModel() : this(AppDomain.CurrentDomain.BaseDirectory) { }

        public PathModel(string path)
        {
            CurrentPath = path;
            FileEntries = new ObservableCollection<FileEntry>();
        }
    }
}

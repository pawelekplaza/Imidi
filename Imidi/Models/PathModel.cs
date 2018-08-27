using System;

namespace Imidi.Models
{
    public class PathModel
    {
        public string CurrentPath { get; set; }

        public PathModel() : this(AppDomain.CurrentDomain.BaseDirectory) { }

        public PathModel(string path)
        {
            CurrentPath = path;
        }
    }
}

using System;

namespace Imidi.Models
{
    public class PathControlModel
    {
        public string CurrentPath { get; set; }

        public PathControlModel()
        {
            CurrentPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public PathControlModel(string path)
        {

        }
    }
}

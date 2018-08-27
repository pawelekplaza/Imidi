using System;

namespace Imidi.EventArguments
{
    public class FilterChangedArgs : EventArgs
    {
        public string Filter { get; set; }

        public FilterChangedArgs() { }

        public FilterChangedArgs(string filter)
        {
            Filter = filter;
        }
    }
}

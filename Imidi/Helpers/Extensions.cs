using Imidi.ViewModels;
using System;
using System.Windows.Controls;

namespace Imidi
{
    public static class Extensions
    {
        public static void PropertyChanged(this object @this, string propertyName)
        {
            if (!(@this is ViewModelBase viewModelBase))
                throw new ArgumentException($"Expected object type: { typeof(ViewModelBase) }.");
            viewModelBase.RaisePropertyChanged(propertyName);
        }

        public static void VerticalScroll(this ScrollViewer scroll, double offset) =>
            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + offset);
    }
}

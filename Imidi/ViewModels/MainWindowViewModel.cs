using System.Windows;

namespace Imidi.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const double DefaultMainPadding = 6;

        public Thickness MainPadding
        {
            get
            {
                switch (Taskbar.Position)
                {                    
                    case TaskbarPosition.Left:
                        return new Thickness(Taskbar.CurrentBounds.Width + DefaultMainPadding, DefaultMainPadding, DefaultMainPadding, DefaultMainPadding);
                    case TaskbarPosition.Top:
                        return new Thickness(DefaultMainPadding, Taskbar.CurrentBounds.Height + DefaultMainPadding, DefaultMainPadding, DefaultMainPadding);
                    case TaskbarPosition.Right:
                        return new Thickness(DefaultMainPadding, DefaultMainPadding, Taskbar.CurrentBounds.Width - Taskbar.CurrentBounds.Left + DefaultMainPadding, DefaultMainPadding);
                    default:
                        return new Thickness(DefaultMainPadding, DefaultMainPadding, DefaultMainPadding, Taskbar.CurrentBounds.Height - Taskbar.CurrentBounds.Top + DefaultMainPadding);
                }
            }
        }
    }
}

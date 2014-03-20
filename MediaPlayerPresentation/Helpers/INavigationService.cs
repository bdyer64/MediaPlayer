using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerPresentation.Helpers
{
    public class NavigateEventArgs : EventArgs
    {
        public string view;
        public object parameter;
        public NavigateEventArgs(string view, object param)
        {
            this.view = view;
            this.parameter = param;
        }
    }

    public interface INavigationService
    {
        event EventHandler NavigateTo;
        void Navigate(string sourcePageType);
        void Navigate(string sourcePageType, object parameter);
        void GoBack();
    }
}
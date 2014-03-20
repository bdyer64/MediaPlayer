using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerPresentation.Helpers
{
    public class MVCNavigationService : INavigationService
    {
        public event EventHandler NavigateTo;

        public void Navigate(string sourcePageType)
        {
            NavigateTo(this, new NavigateEventArgs(sourcePageType,null));
        }
        
        public void Navigate(string sourcePageType, object parameter)
        {
            NavigateTo(this, new NavigateEventArgs(sourcePageType, parameter));
        }

        public void GoBack()
        {
            NavigateTo(this, new NavigateEventArgs("Back", null));
        }
    }
}

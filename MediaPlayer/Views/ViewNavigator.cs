using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerPresentation.Helpers;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace MediaPlayer.Views
{
    class ViewNavigator
    {
        public ViewNavigator(INavigationService navigationService)
        {
            navigationService.NavigateTo += new EventHandler(OnNavigate);
        }

        void OnNavigate(object sender, EventArgs e)
        {
            var navArgs = e as NavigateEventArgs;
           
            var uri = new Uri("/Views/" + navArgs.view +".xaml",UriKind.Relative);

            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);
        }
    }
}

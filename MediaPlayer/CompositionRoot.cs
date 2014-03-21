using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using MediaPlayerPresentation.ViewModel;
using MediaPlayer.Views;
using System.Collections.ObjectModel;

namespace MediaPlayer
{
    public class CompositionRoot
    {
        // Wire up the settings pivot view
        static IEnumerable<PPContentViewModel> GetSettingsPivots()
        {
            var settingsPivots = new List<PPContentViewModel>();

            settingsPivots.Add(new PPContentViewModel("services", typeof(ServicesSettingsView)));
            settingsPivots.Add(new PPContentViewModel("general", typeof(GeneralSettingsView)));

            return settingsPivots;
        }

        // Wire up the settings pivot view
        static IEnumerable<PPContentViewModel> GetMainPanoramas()
        {
            var settingsPans = new List<PPContentViewModel>();

            settingsPans.Add(new PPContentViewModel("home", typeof(HomeMainView)));
            settingsPans.Add(new PPContentViewModel("other page", typeof(HomeMainView)));

            return settingsPans;
        }
        public CompositionRoot()
        {
            ServiceLocator.Current.GetInstance<Views.ViewNavigator>();
            var main = ServiceLocator.Current.GetInstance<MainViewModel>();
            main.Items = new ObservableCollection<PPContentViewModel>(GetMainPanoramas());
            var settings = ServiceLocator.Current.GetInstance<SettingsViewModel>();
            settings.Items = new ObservableCollection<PPContentViewModel>(GetSettingsPivots());
        }
    }
}

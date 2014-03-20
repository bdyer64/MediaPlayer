/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MediaPlayer.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MediaPlayerModel;
using MediaPlayerPresentation.ViewModel;
using MediaPlayerPresentation.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Linq;
using SubsonicMediaProvider;

namespace MediaPlayer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static List<IMediaProvider> GetMediaProviders()
        {
            var mediaProviders = new List<IMediaProvider>();

            mediaProviders.Add(new SubsonicMediaProvider.SubsonicMediaProvider());

            return mediaProviders;
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IMediaPlayerService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IMediaPlayerService, MediaPlayerService>();
                                                        
            }
    
            SimpleIoc.Default.Register<INavigationService, MVCNavigationService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EditServiceViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<Views.ViewNavigator>();
            SimpleIoc.Default.Register<List<IMediaProvider>>(() => GetMediaProviders());
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public EditServiceViewModel EditService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditServiceViewModel>();
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
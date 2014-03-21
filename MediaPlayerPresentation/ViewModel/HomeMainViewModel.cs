using GalaSoft.MvvmLight;
using MediaPlayerModel;
using GalaSoft.MvvmLight.Command;
using MediaPlayerPresentation.Helpers;
using System;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class HomeMainViewModel : ViewModelBase
    {
        private readonly IMediaPlayerService _dataService;
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the HomeMainViewModel class.
        /// </summary>
        public HomeMainViewModel(IMediaPlayerService dataService,INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
        }

        private RelayCommand _navigateToSettingsCommand;

        public RelayCommand NavigateToSettingsCommand
        {
            get
            {
                return _navigateToSettingsCommand
                  ?? (_navigateToSettingsCommand = new RelayCommand(
                    () => _navigationService.Navigate("SettingsPage")));
            }
        }

        private RelayCommand _navigateToMusicCommand;

        public RelayCommand NavigateToMusicCommand
        {
            get
            {
                return _navigateToMusicCommand
                  ?? (_navigateToMusicCommand = new RelayCommand(
                    () => _navigationService.Navigate("MusicPage")));
            }
        }
    }
}
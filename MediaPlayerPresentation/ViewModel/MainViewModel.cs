using GalaSoft.MvvmLight;
using MediaPlayerModel;
using GalaSoft.MvvmLight.Command;
using MediaPlayerPresentation.Helpers;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IMediaPlayerService _dataService;
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IMediaPlayerService dataService,INavigationService navigationService)
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

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
using GalaSoft.MvvmLight;
using MediaPlayerModel;
using GalaSoft.MvvmLight.Command;
using MediaPlayerPresentation.Helpers;
using System;
using System.Collections.Generic;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : PPViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        /// <summary>
        /// The <see cref="AppName" /> property's name.
        /// </summary>
        public const string AppNamePropertyName = "AppName";

        private string _appName = "media player";

        /// <summary>
        /// Sets and gets the AppName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string AppName
        {
            get
            {
                return _appName;
            }
            set
            {
                Set(AppNamePropertyName, ref _appName, value);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}
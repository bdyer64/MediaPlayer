using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SettingsViewModel class.
        /// </summary>
        public SettingsViewModel(IEnumerable<PivotEntryViewModel> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            Items = new ObservableCollection<PivotEntryViewModel>(items);

            if (Items.Count == 0)
            {
                throw new ArgumentException("items count cannot be zero");
            }
            

        }

        public ObservableCollection<PivotEntryViewModel> Items {get;private set;}

        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title = "settings";

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Set(TitlePropertyName, ref _title, value);
            }
        }

        /// <summary>
        /// The <see cref="SelectedPivotItem" /> property's name.
        /// </summary>
        public const string SelectedPivotItemPropertyName = "SelectedPivotItem";

        private PivotEntryViewModel _selectedPivotItem;

        /// <summary>
        /// Sets and gets the SelectedPivotItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PivotEntryViewModel SelectedPivotItem
        {
            get
            {
                return _selectedPivotItem;
            }
            set
            {
                Set(SelectedPivotItemPropertyName, ref _selectedPivotItem, value);
            }
        }
    }
}
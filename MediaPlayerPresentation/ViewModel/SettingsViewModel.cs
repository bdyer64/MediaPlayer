using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

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
        public SettingsViewModel()
        {
            Items = new ObservableCollection<PivotEntryViewModel>();
            PivotEntryViewModel pevm = new PivotEntryViewModel("Services", "Testing1");
            Items.Add(pevm);
            SelectedPivotItem = pevm;
            pevm = new PivotEntryViewModel("Other Stuff", "Testing2");
            Items.Add(pevm);
        }

        public ObservableCollection<PivotEntryViewModel> Items {get;private set;}

        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title = "Settings";

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
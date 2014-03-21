using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PPViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the PPViewModelBase class.
        /// </summary>
        public PPViewModelBase(IEnumerable<PPContentViewModel> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            Items = new ObservableCollection<PPContentViewModel>(items);

            if (Items.Count == 0)
            {
                throw new ArgumentException("items count cannot be zero");
            }
        }

        public ObservableCollection<PPContentViewModel> Items { get; private set; }

        /// <summary>
        /// The <see cref="SelectedPivotItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        private PPContentViewModel _selectedItem;

        /// <summary>
        /// Sets and gets the SelectedPivotItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PPContentViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                Set(SelectedItemPropertyName, ref _selectedItem, value);
            }
        }
    }
}
using GalaSoft.MvvmLight;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PivotEntryViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the PivotEntryViewModel class.
        /// </summary>
        public PivotEntryViewModel(string header,string content)
        {
            Header = header;
            Content = content;
        }

        /// <summary>
        /// The <see cref="Header" /> property's name.
        /// </summary>
        public const string HeaderPropertyName = "Header";

        private string _header = "";

        /// <summary>
        /// Sets and gets the Header property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                Set(HeaderPropertyName, ref _header, value);
            }
        }

        /// <summary>
        /// The <see cref="Content" /> property's name.
        /// </summary>
        public const string ContentPropertyName = "Content";

        private string _content = "";

        /// <summary>
        /// Sets and gets the Content property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                Set(ContentPropertyName, ref _content, value);
            }
        }
    }
}
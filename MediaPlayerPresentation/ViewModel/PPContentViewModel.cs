using GalaSoft.MvvmLight;
using System.Windows.Controls;
using System;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PPContentViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the PivotEntryViewModel class.
        /// </summary>
        public PPContentViewModel(string header, Type contentType)
        {
            Header = header;
            ContentType = contentType;
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

        private object _content;

        /// <summary>
        /// Sets and gets the Content property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object Content
        {
            get
            {
                return Activator.CreateInstance(ContentType);
            }
            set
            {
                Set(ContentPropertyName, ref _content, value);
            }
        }

        /// <summary>
        /// The <see cref="ContentType" /> property's name.
        /// </summary>
        public const string ContentTypePropertyName = "ContentType";

        private Type _contentType;

        /// <summary>
        /// Sets and gets the ContentType property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Type ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                RaisePropertyChanged(() => Content);
                Set(ContentTypePropertyName, ref _contentType, value);
            }
        }
    }
}
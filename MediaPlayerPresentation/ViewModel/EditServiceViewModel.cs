using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediaPlayerPresentation.Helpers;
using MediaPlayerModel;
using System.Threading.Tasks;

namespace MediaPlayerPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EditServiceViewModel : ViewModelBase, INavigable
    {
        private readonly Service service;
        /// <summary>
        /// Initializes a new instance of the SettingsViewModel class.
        /// </summary>
        public EditServiceViewModel(Service service)
        {
            this.service = service;
        }

        #region INavigable interface method
        public void Activate(object parameter)
        {

        }

        public void Deactivate(object parameter)
        {
            service.ServiceName = this.ServerName;
            service.ServerURL = this.ServerAddress;
            service.Password = this.Password;
            service.UserName = this.UserName;
            service.Save();
        }
        #endregion

        #region TestConnectionCommand
        private RelayCommand _testConnection;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand TestConnection
        {
            get
            {
                return _testConnection
                    ?? (_testConnection = new RelayCommand(
                                          async () =>
                                          {
                                              await TestServerConnection();
                                          }));
            }
        }

        private async Task TestServerConnection()
        {
            ButtonText = "Cancel Test";
            ShowStatus = true;
            await service.TestConnection();
            ButtonText = "Test Connection";
            ShowStatus = false;
        }
        #endregion
        #region ServerName Property
        /// <summary>
        /// The <see cref="ServerName" /> property's name.
        /// </summary>
        public const string ServerNamePropertyName = "ServerName";

        private string _serverName = "bob";

        /// <summary>
        /// Sets and gets the ServerName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                Set(() => ServerName, ref _serverName, value);
            }
        }
        #endregion
        #region ServerAddress Property
        /// <summary>
        /// The <see cref="ServerAddress" /> property's name.
        /// </summary>
        public const string ServerAddressPropertyName = "ServerAddress";

        private string _serverAddress = "www.chezdyer.net";

        /// <summary>
        /// Sets and gets the ServerAddress property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ServerAddress
        {
            get
            {
                return _serverAddress;
            }
            set
            {
                Set(ServerAddressPropertyName, ref _serverAddress, value);
            }
        }
        #endregion
        #region UserName Property
        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = "admin";

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                Set(UserNamePropertyName, ref _userName, value);
            }
        }
        
        #endregion
        #region Password Property
        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password = "beagle";

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(PasswordPropertyName, ref _password, value);
            }
        } 
        #endregion
        #region ButtonText Property
        /// <summary>
        /// The <see cref="ButtonText" /> property's name.
        /// </summary>
        public const string ButtonTextPropertyName = "ButtonText";

        private string _buttonText = "Test Connection";

        /// <summary>
        /// Sets and gets the ButtonText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                Set(ButtonTextPropertyName, ref _buttonText, value);
            }
        } 
        #endregion
        #region ShowStatus Property
        /// <summary>
        /// The <see cref="ShowStatus" /> property's name.
        /// </summary>
        public const string ShowStatusPropertyName = "ShowStatus";

        private bool _showstatus = false;

        /// <summary>
        /// Sets and gets the ShowStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowStatus
        {
            get
            {
                return _showstatus;
            }

            set
            {
                if (_showstatus == value)
                {
                    return;
                }

                RaisePropertyChanging(() => ShowStatus);
                _showstatus = value;
                RaisePropertyChanged(() => ShowStatus);
            }
        }
        #endregion
    }
}
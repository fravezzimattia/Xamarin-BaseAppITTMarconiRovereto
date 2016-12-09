using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using NewsApp.Interfaces;
using NewsApp.Model;
using NewsApp.Services;
using NewsApp.View.Layouts;
using NewsApp.View.Pages;
using Xamarin.Forms;

namespace NewsApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    /// NewsApp.ViewModel.LayoutsViewModel
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _commandToAbsolute;
        private RelayCommand _commandToRelative;
        private RelayCommand _commandToContent;
        private RelayCommand _commandToGrid;
        private RelayCommand _commandToFrame;
        private RelayCommand _commandToScroll;
        private string _userName;
        private string _password;
        private RelayCommand _loginCommand;
        private ISQLite _sqlLite;
        private RelayCommand _registerCommand;

        public LoginViewModel(INavigationService navigationService, ISQLite sqlLite)
        {
            _navigationService = navigationService;
            _sqlLite = sqlLite;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                Set(ref _userName, value.Trim());
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                Set(ref _password, value.Trim());
            }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(() =>
                    {
                        if (!CheckUtente())
                        {

                            return;
                        }

                        var sql = SimpleIoc.Default.GetInstance<ISQLite>();
                        var sqLite = new SqLiteService(sql);
                        var isLogged = sqLite.Login(UserName, Password);
                        if (isLogged)
                        {
                            ViewModelLocator.CurrentPage.DisplayAlert("CONNESSIONE","complimenti ti sei loggato correttamente", "ok");
                        }
                        else
                        {
                            ViewModelLocator.CurrentPage.DisplayAlert("CONNESSIONE", "User o Psw NON sono corretti", "ok");
                        }
                    }, () => true);
                }
                return _loginCommand;
            }
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                if (_registerCommand == null)
                {
                    _registerCommand = new RelayCommand(() =>
                    {
                        if (!CheckUtente()) return;


                        var user = new User
                        {
                            Name = UserName,
                            Password = Password
                        };

                        var sql = SimpleIoc.Default.GetInstance<ISQLite>();
                        var sqLite = new SqLiteService(sql);
                       var isRegistered =  sqLite.SaveUser(user);
                        if (isRegistered)
                        {
                            ViewModelLocator.CurrentPage.DisplayAlert("REGISTAZIONE", "complimenti ti sei registrato correttamente", "ok");
                        }
                        else
                        {
                            ViewModelLocator.CurrentPage.DisplayAlert("REGISTAZIONE", "Errore nel completamento della registrazione", "ok");
                        }

                    }, () => true);
                }
                return _registerCommand;
            }
        }

        private bool CheckUtente()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }
    }
}
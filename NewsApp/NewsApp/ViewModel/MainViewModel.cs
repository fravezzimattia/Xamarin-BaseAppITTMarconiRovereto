using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewsApp.Interfaces;
using NewsApp.View.Displaying;
using NewsApp.View.Inputs;
using NewsApp.View.Layouts;
using NewsApp.View.Login;
using NewsApp.View.Map;
using NewsApp.View.Pages;

namespace NewsApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _commandToPages;
        private RelayCommand _commandToLayouts;
        private RelayCommand _commandToInput;
        private RelayCommand _commandToMap;
        private RelayCommand _commandToDisplaying;
        private RelayCommand _commandToDisplaying2;
        private RelayCommand _commandToDatabases;
        private string _internetCheck;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string InternetCheck
        {
            get { return _internetCheck; }
            set
            {
                Set(ref _internetCheck, value.Trim());
            }
        }

        public RelayCommand CommandToLayouts
        {
            get
            {
                if (_commandToLayouts == null)
                {

                    _commandToLayouts = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new LayoutsPage());
                    }, () => true);
                }
                return _commandToLayouts;
            }
        }

        public RelayCommand CommandToPages
        {
            get
            {
                if (_commandToPages == null)
                {

                    _commandToPages = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new PagesPage());
                    }, () => true);
                }
                return _commandToPages;
            }
        }


        public RelayCommand CommandToInput
        {
            get
            {
                if (_commandToInput == null)
                {

                    _commandToInput = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new InputsPage());
                    }, () => true);
                }
                return _commandToInput;
            }
        }

       public RelayCommand CommandToDatabases
        {
            get
            {
                if (_commandToDatabases == null)
                {

                    _commandToDatabases = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new LoginPage());
                    }, () => true);
                }
                return _commandToDatabases;
            }
        }



        public RelayCommand CommandToDisplaying
        {
            get
            {
                if (_commandToDisplaying == null)
                {

                    _commandToDisplaying = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new DisplayingPage());
                    }, () => true);
                }
                return _commandToDisplaying;
            }
        }


        public RelayCommand CommandToDisplaying2
        {
            get
            {
                if (_commandToDisplaying2 == null)
                {

                    _commandToDisplaying2 = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new DisplayingPage2());
                    }, () => true);
                }
                return _commandToDisplaying2;
            }
        }

        public RelayCommand CommandToMap
        {
            get
            {
                if (_commandToMap == null)
                {

                    _commandToMap = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new MapPage());
                    }, () => true);
                }
                return _commandToMap;
            }
        }
    }
}
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewsApp.Interfaces;
using NewsApp.View.Layouts;
using NewsApp.View.Pages;
using Xamarin.Forms;

namespace NewsApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    /// NewsApp.ViewModel.LayoutsViewModel
    public class LayoutsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _commandToAbsolute;
        private RelayCommand _commandToRelative;
        private RelayCommand _commandToContent;
        private RelayCommand _commandToGrid;
        private RelayCommand _commandToFrame;
        private RelayCommand _commandToScroll;

        public LayoutsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public RelayCommand CommandToScroll
        {
            get
            {
                if (_commandToScroll == null)
                {

                    _commandToScroll = new RelayCommand(() =>
                    {
                        _navigationService.PushAsync(new ScrollViewPage());
                    }, () => true);
                }
                return _commandToScroll;
            }
        }
        public RelayCommand CommandToFrame
        {
            get
            {
                if (_commandToFrame == null)
                {

                    _commandToFrame = new RelayCommand(() =>
                    {
                        _navigationService.PushAsync(new FramePage());
                    }, () => true);
                }
                return _commandToFrame;
            }
        }

        public RelayCommand CommandToAbsolute
        {
            get
            {
                if (_commandToAbsolute == null)
                {

                    _commandToAbsolute = new RelayCommand(() =>
                    {
                        _navigationService.PushAsync(new AbsoluteLayoutPage());
                    }, () => true);
                }
                return _commandToAbsolute;
            }
        }
        public RelayCommand CommandToRelative
        {
            get
            {
                if (_commandToRelative == null)
                {

                    _commandToRelative = new RelayCommand(() =>
                    {
                        _navigationService.PushAsync(new RelativeLayoutPage());
                    }, () => true);
                }
                return _commandToRelative;
            }
        }

        public RelayCommand CommandToGrid
        {
            get
            {
                if (_commandToGrid == null)
                {

                    _commandToGrid = new RelayCommand(() =>
                    {
                        _navigationService.PushAsync(new GridLayoutPage());
                    }, () => true);
                }
                return _commandToGrid;
            }
        }
        public RelayCommand CommandToContent
        {
            get
            {
                if (_commandToContent == null)
                {

                    _commandToContent = new RelayCommand(() =>
                    {
                        _navigationService.PushAsync(new ContentViewPage());
                    }, () => true);
                }
                return _commandToContent;
            }
        }
    }
}
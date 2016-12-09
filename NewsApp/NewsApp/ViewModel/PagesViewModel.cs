using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewsApp.Interfaces;
using NewsApp.View.Pages;

namespace NewsApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class PagesViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _commandToCarousel;
        private RelayCommand _commandToMasterDetail;
        private RelayCommand _commandToTabbed;

        public PagesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public RelayCommand CommandToCarousel
        {
            get
            {
                if (_commandToCarousel == null)
                {
                    _commandToCarousel = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new MyCarouselPage());
                    }, () => true);
                }
                return _commandToCarousel;
            }
        }

        public RelayCommand CommandToMasterDetail
        {
            get
            {
                if (_commandToMasterDetail == null)
                {
                    _commandToMasterDetail = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new MyMasterDetailPage());
                    }, () => true);
                }
                return _commandToMasterDetail;
            }
        }
        
        public RelayCommand CommandToTabbed
        {
            get
            {
                if (_commandToTabbed == null)
                {
                    _commandToTabbed = new RelayCommand(async () =>
                    {
                        await _navigationService.PushAsync(new MyTabbedPage());
                    }, () => true);
                }
                return _commandToTabbed;
            }
        }
    }
}
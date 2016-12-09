using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewsApp.Data.Repositories;
using NewsApp.Interfaces;
using NewsApp.Model;
using NewsApp.View.Layouts;
using NewsApp.View.Pages;

namespace NewsApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class DisplayingViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly INewsRepository _newsRepository;
        private ObservableCollection<News> _listNews;

        public DisplayingViewModel(INavigationService navigationService, INewsRepository newsRepository)
        {
            _navigationService = navigationService;
            _newsRepository = newsRepository;
        }

        public async void Init()
        {
            ListNews = new ObservableCollection<News>(await _newsRepository.Get());
        }

        public ObservableCollection<News> ListNews
        {
            get { return _listNews; }
            set
            {
                Set(ref _listNews, value);
            }
        }
    }
}
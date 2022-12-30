using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LastFmWpfMVVMApp.Models;
using LastFmWpfMVVMApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LastFmWpfMVVMApp.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly IArtistSearchApiClient searchApiClient;
        private string _name;
        public string Name { get => _name; set => Set(ref _name, value); }

        private ObservableCollection<Artist> _artists;
        public ObservableCollection<Artist> Artists { get => _artists; set => Set(ref _artists, value); }
        public HomeViewModel(IArtistSearchApiClient artistSearchApiClient)
        {
            searchApiClient = artistSearchApiClient;

          
            Artists = new ObservableCollection<Artist>();
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand => _searchCommand ??= new RelayCommand(
            () =>
            {
                foreach (var item in searchApiClient.GetArtistList(Name))
                {
                    Artists.Add(item);
                }
               
            }
        );
    }
}

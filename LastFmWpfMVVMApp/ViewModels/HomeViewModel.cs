using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LastFmWpfMVVMApp.Messages;
using LastFmWpfMVVMApp.Models;
using LastFmWpfMVVMApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace LastFmWpfMVVMApp.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly IArtistSearchApiClient searchApiClient;
        private readonly IMessenger _messenger;

        private string _name;
        public string Name { get => _name; set => Set(ref _name, value); }
        private Artist _selectedArtist;
        public Artist SelectedArtist { get => _selectedArtist; set => Set(ref _selectedArtist, value); }

        private ObservableCollection<Artist> _artists;
        public ObservableCollection<Artist> Artists { get => _artists; set => Set(ref _artists, value); }
        public HomeViewModel(IArtistSearchApiClient artistSearchApiClient, IMessenger messenger)
        {
            searchApiClient = artistSearchApiClient;
            _messenger = messenger;
          
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
        private RelayCommand<Artist> _detailsCommand;
        public RelayCommand<Artist> DetailsCommand => _detailsCommand ??= new RelayCommand<Artist>(
            param =>
            {
                //MessageBox.Show(param.name);
                _messenger.Send(new NavigationMessage { ViewModelType = typeof(DetailsViewModel) });
                 _messenger.Send(new ArtistDetailsMessage { Artist = param });
            }
        );
    }
}

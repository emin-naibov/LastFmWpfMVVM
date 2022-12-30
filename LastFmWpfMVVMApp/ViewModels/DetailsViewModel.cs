using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LastFmWpfMVVMApp.Messages;
using LastFmWpfMVVMApp.Models;
using LastFmWpfMVVMApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LastFmWpfMVVMApp.ViewModels
{
    class DetailsViewModel : ViewModelBase
    {

        private readonly IMessenger _messenger;
        private readonly IArtistSearchApiClient _searchApiClient;

        private string _artistName;
        public string ArtistName { get => _artistName; set => Set(ref _artistName, value); }
        private string _image;
        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }
        private string _playcount;
        public string Playcount { get => _playcount; set => Set(ref _playcount, value); }
        private string _listeners;
        public string Listeners { get => _listeners; set => Set(ref _listeners, value); }
        private string _bio;
        public string Bio { get => _bio; set => Set(ref _bio, value); }
        private Artist_with_Info _simArtist;
        public Artist_with_Info SimArtists { get => _simArtist; set => Set(ref _simArtist, value); }

        public DetailsViewModel(IMessenger messenger, IArtistSearchApiClient artistSearchApiClient)
        {
            _searchApiClient = artistSearchApiClient;
            _messenger = messenger;
            //MessageBox.Show("Errorr");
            _messenger?.Register<ArtistDetailsMessage>(this, message =>
            {
                ArtistName = message.Artist.name;
                SimArtists = new Artist_with_Info();
                SimArtists = _searchApiClient.GetSimilarArtists(ArtistName);
                if (SimArtists == null)
                {
                    MessageBox.Show("Errorr!!");
                }
                //SimArtists.image.ToString();
                //foreach (var item in SimArtists.image)
                //{
                //    MessageBox.Show(item.text);
                //}
                MessageBox.Show(SimArtists.image[0].text);
                Image = SimArtists.image[0].text;
                Listeners = SimArtists.stats.listeners;
                Playcount = SimArtists.stats.playcount;
                Bio = SimArtists.bio.content;
            });
        }

    }
}

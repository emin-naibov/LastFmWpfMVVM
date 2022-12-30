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
        private string _simArtist_image;
        public string SimArtist_image { get => _simArtist_image; set => Set(ref _simArtist_image, value); }
        private string _simArtist1_image;
        public string SimArtist1_image { get => _simArtist1_image; set => Set(ref _simArtist1_image, value); }
        private string _simArtist2_image;
        public string SimArtist2_image { get => _simArtist2_image; set => Set(ref _simArtist2_image, value); }
        private string _simArtist3_image;
        public string SimArtist3_image { get => _simArtist3_image; set => Set(ref _simArtist3_image, value); }

        private string _simArtist1;
        public string SimArtist1 { get => _simArtist1; set => Set(ref _simArtist1, value); }
        private string _simArtist2;
        public string SimArtist2 { get => _simArtist2; set => Set(ref _simArtist2, value); }
        private string _simArtist3;
        public string SimArtist3 { get => _simArtist3; set => Set(ref _simArtist3, value); }
        private string _simArtist4;
        public string SimArtist4 { get => _simArtist4; set => Set(ref _simArtist4, value); }


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
                Image = SimArtists.image[0].text;
                Listeners = SimArtists.stats.listeners;
                Playcount = SimArtists.stats.playcount;
                Bio = SimArtists.bio.content;

                Similar_Artists_Init(SimArtists);
                //SimArtist1 = SimArtists.similar.artist[0].Sim_Name;
                //SimArtist2 = SimArtists.similar.artist[1].Sim_Name;
                //SimArtist3 = SimArtists.similar.artist[2].Sim_Name;
                //SimArtist4 = SimArtists.similar.artist[3].Sim_Name;

                //SimArtist_image = SimArtists.similar.artist[0].image[0].text;
                //SimArtist1_image = SimArtists.similar.artist[1].image[0].text;
                //SimArtist2_image = SimArtists.similar.artist[2].image[0].text;
                //SimArtist3_image = SimArtists.similar.artist[3].image[0].text;
            });
        }
        public void Similar_Artists_Init(Artist_with_Info artist)
        {
            SimArtist1 = artist.similar.artist[0].Sim_Name;
            SimArtist2 = artist.similar.artist[1].Sim_Name;
            SimArtist3 = artist.similar.artist[2].Sim_Name;
            SimArtist4 = artist.similar.artist[3].Sim_Name;

            SimArtist_image = artist.similar.artist[0].image[0].text;
            SimArtist1_image = artist.similar.artist[1].image[0].text;
            SimArtist2_image = artist.similar.artist[2].image[0].text;
            SimArtist3_image = artist.similar.artist[3].image[0].text;
        }

    }
}

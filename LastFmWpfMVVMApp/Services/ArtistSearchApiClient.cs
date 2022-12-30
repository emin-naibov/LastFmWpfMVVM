using LastFmWpfMVVMApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace LastFmWpfMVVMApp.Services
{
    class ArtistSearchApiClient : IArtistSearchApiClient
    {
        private readonly WebClient _webClient;

        private readonly string _appKey = "53eb528c18d752a1e86824b8386425d6";
        private readonly string _apiUrl = "https://ws.audioscrobbler.com/2.0/?";

        public ArtistSearchApiClient()
        {
            _webClient = new WebClient();
        }
        public IEnumerable<Artist> GetArtistList(string search_artist)
        {
            try
            {
                MessageBox.Show(search_artist);
                var json = _webClient.DownloadString($"{_apiUrl}method=artist.search&artist={search_artist}&api_key={_appKey}&format=json");
                var HomeViewArtists = JsonSerializer.Deserialize<Artists>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return HomeViewArtists.results.artistmatches.artist;
            }
            catch (Exception ex)
            {
                //_logger.LogError("ERROR!!!", ex);
                //throw;
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        
    }
}

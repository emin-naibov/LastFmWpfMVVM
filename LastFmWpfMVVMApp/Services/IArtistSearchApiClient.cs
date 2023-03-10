using LastFmWpfMVVMApp.Models;
using System.Collections.Generic;

namespace LastFmWpfMVVMApp.Services
{
    interface IArtistSearchApiClient
    {
        IEnumerable<Artist> GetArtistList(string search_artist);
        Artist_with_Info GetSimilarArtists(string search_artist);
    }
}
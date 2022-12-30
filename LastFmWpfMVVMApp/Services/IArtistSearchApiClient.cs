using LastFmWpfMVVMApp.Models;
using System.Collections.Generic;

namespace LastFmWpfMVVMApp.Services
{
    interface IArtistSearchApiClient
    {
        IEnumerable<Artist> GetArtistList(string search_artist);
    }
}
using GrooveandNeedle.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrooveandNeedle.ViewModels
{
    public class AlbumsViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Album> Albums { get; set; }

        public AlbumsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Albums = new ObservableCollection<Album>();
        }

        public async Task LoadAlbumsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/api/albums");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var albums = JsonSerializer.Deserialize<List<Album>>(content);
                Albums.Clear();
                foreach (var album in albums)
                {
                    Albums.Add(album);
                }
            }
        }

        public async Task AddAlbumAsync(Album album)
        {
            var albumJson = JsonSerializer.Serialize(album);
            var content = new StringContent(albumJson, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("http://localhost:5000/api/albums", content);
        }
    }
}

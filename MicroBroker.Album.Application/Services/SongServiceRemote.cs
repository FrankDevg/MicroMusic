using MicroBroker.Album.Application.Interfaces;
using MicroBroker.Album.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroBroker.Album.Application.Services
{
    public class SongServiceRemote : ISongServiceRemote
    {
        private readonly IHttpClientFactory httpClient;

        public SongServiceRemote(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<(bool resultado, List<SongRemote> songs, string ErrorMessage)> GetSongs(List<int> idSongList)
        {
            var client = httpClient.CreateClient("Song");
            //Prepara http content
            var jsonList = JsonSerializer.Serialize(idSongList);
            var stringContent = new StringContent(jsonList, Encoding.UTF8, "application/json");
            var response = client.PostAsync($"api/Song/readSongs", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                };
                var resultado = JsonSerializer.Deserialize<List<SongRemote>>(contenido, options);
                return (true, resultado, null);

            }
            return (false, null, "ERROR");
        }
    }
}

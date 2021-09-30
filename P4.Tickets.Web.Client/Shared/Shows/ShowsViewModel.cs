using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using P4.Tickets.WebApi.Contract;

namespace P4.Tickets.Web.Client.Shared.Shows
{
    public class ShowsViewModel
    {
        private readonly HttpClient _httpClient;

        public ShowsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ShowSummaryModel[] Shows { get; set; } = Array.Empty<ShowSummaryModel>();
        public bool IsLoading { get; set; }
        public bool HasLoaded { get; set; }

        public async Task LoadShowsAsync()
        {
            if (HasLoaded)
            {
                return;
            }
            IsLoading = true;
            await Task.Delay(1000);
            Shows = await _httpClient.GetFromJsonAsync<ShowSummaryModel[]>("shows");

            IsLoading = false;
            HasLoaded = true;
        }
    }
}
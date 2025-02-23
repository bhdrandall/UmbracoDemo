using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UmbracoDemo.Models;
using UmbracoDemo.Services.Interfaces;

namespace UmbracoDemo.Services
{
	public class SpaceflightApiService : ISpaceflightApiService
	{
		private readonly HttpClient _httpClient;

		public SpaceflightApiService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<SpaceflightApiResponse> GetAll()
		{
			// Define the API endpoint
			var url = "https://api.spaceflightnewsapi.net/v4/articles/";

			// Make the GET request and deserialize the response into ApiResponse
			var response = await _httpClient.GetFromJsonAsync<SpaceflightApiResponse>(url);
			return response;
		}
	}
}
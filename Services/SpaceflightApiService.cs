using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using UmbracoDemo.Models;
using UmbracoDemo.Services.Interfaces;

namespace UmbracoDemo.Services
{
	public class SpaceflightApiService : ISpaceflightApiService
	{
		private readonly HttpClient _httpClient;
		private readonly IAppPolicyCache _runtimeCache;

		public SpaceflightApiService(HttpClient httpClient, AppCaches appCaches)
		{
			_httpClient = httpClient;
			_runtimeCache = appCaches.RuntimeCache;
		}

		public async Task<SpaceflightApiResponse> GetAll()
		{
			// Define the API endpoint
			var url = "https://api.spaceflightnewsapi.net/v4/articles/";

			return await _runtimeCache.GetCacheItem("SpaceflightArticles", async () =>
			{
				return await _httpClient.GetFromJsonAsync<SpaceflightApiResponse>(url);
			}, timeout: TimeSpan.FromMinutes(1));

		}
	}
}
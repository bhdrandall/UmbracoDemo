using Umbraco.Cms.Core.Cache;
using UmbracoDemo.Models;
using UmbracoDemo.Services.Interfaces;

namespace UmbracoDemo.Services
{
	public class SpaceflightApiService : ISpaceflightApiService
	{
		private readonly HttpClient _httpClient;
		private readonly IAppPolicyCache _runtimeCache;
		private readonly ILogger _logger;

		public SpaceflightApiService(HttpClient httpClient, AppCaches appCaches, ILogger<SpaceflightApiService> logger)
		{
			_httpClient = httpClient;
			_runtimeCache = appCaches.RuntimeCache;
			_logger = logger;
		}

		public async Task<SpaceflightApiResponse> GetAll()
		{
			// Define the API endpoint
			var url = "https://api.spaceflightnewsapi.net/v4/articles/";

			if (_runtimeCache == null)
			{
				throw new InvalidOperationException("RuntimeCache is not initialized.");
			}

            if (_httpClient == null)
            {
                // Handle the null case, e.g., throw an exception or return a default response
                throw new InvalidOperationException("HttpClient is not initialized.");
            }

            return await _runtimeCache.GetCacheItem("SpaceflightArticles", async () =>
			{
				try
				{
					var response = await _httpClient.GetFromJsonAsync<SpaceflightApiResponse>(url);
					return response ?? throw new InvalidOperationException("Failed to retrieve data from the Spaceflight API.");
				}
				catch (Exception ex)
				{
					_logger.LogError("Failed to retrieve data from the Spaceflight API.", ex);
					return new SpaceflightApiResponse();
                }
			}, timeout: TimeSpan.FromMinutes(5));
		}
	}
}
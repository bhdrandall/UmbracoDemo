using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Examine;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoDemo.ViewModels;

namespace UmbracoDemo.Controllers
{
	public class SearchController : RenderController
	{
		private readonly IExamineManager _examineManager;
		private readonly IVariationContextAccessor _variationContextAccessor;
		private readonly ServiceContext _serviceContext;
		private readonly ILogger _logger;

		public SearchController(ILogger<SearchController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IExamineManager examineManager, IVariationContextAccessor variationContextAccessor, ServiceContext context)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_examineManager = examineManager;
			_variationContextAccessor = variationContextAccessor;
			_serviceContext = context;
			_logger = logger;
		}

		public override IActionResult Index()
		{
			var searchQuery = HttpContext.Request.Query["query"].ToString();
			var searchResults = Enumerable.Empty<ISearchResult>();

			if (!string.IsNullOrWhiteSpace(searchQuery))
			{
				if (_examineManager.TryGetIndex("ExternalIndex", out var index))
				{
					var searcher = index.Searcher;

					var query = searcher.CreateQuery("content")
						.Field("nodeName", searchQuery.Fuzzy(0.5f))
						.Or()
						.Field("content", searchQuery.Fuzzy(0.5f))
						.Not()
						.Field("includeInSearch", "0");
					searchResults = query.Execute();
				} else
				{
					_logger.LogError("Could not get ExternalIndex");
				}
			}

			var searchViewModel = new SearchViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor))
			{
				SearchQuery = searchQuery,
				SearchResults = searchResults.Select(result => new SiteSearchResult
				{
					Url = UmbracoContext.Content.GetById(int.Parse(result.Id)).Url(),
					Title = result.Values["nodeName"]
				})
			};

			return CurrentTemplate(searchViewModel);
		}
	}
}
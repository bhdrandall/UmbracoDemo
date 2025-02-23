using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoDemo.ViewModels
{
	public class SearchViewModel : Search
	{
		public SearchViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
		{
		}

		public string? SearchQuery { get; set; }
		public IEnumerable<SiteSearchResult> SearchResults { get; set; }
	}

	public class SiteSearchResult
	{
		public string Url { get; set; }
		public string Title { get; set; }
	}
}

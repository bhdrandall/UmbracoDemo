using Examine;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoDemo.Models;

namespace UmbracoDemo.ViewModels
{
	public class SearchViewModel : Search
	{
		public SearchViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
		{
		}

		public string? SearchQuery { get; set; }
		public IEnumerable<ISearchResult> SearchResults { get; set; }
	}
}

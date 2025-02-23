using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoDemo.Models;

namespace UmbracoDemo.ViewModels
{
	public class HomeViewModel : Home
	{
		public HomeViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
		{
		}

		public SpaceflightApiResponse SpaceflightApiResponse { get; set; }
	}
}

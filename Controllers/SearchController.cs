using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoDemo.Controllers
{
	public class SearchController : RenderController
	{
		public SearchController(ILogger<SearchController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
		{
		}

		public override IActionResult Index()
		{

			return CurrentTemplate(CurrentPage);
		}
	}
}
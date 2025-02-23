using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Drawing.Text;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoDemo.Services;
using UmbracoDemo.Services.Interfaces;

namespace UmbracoDemo.Controllers
{
	public class HomeController : RenderController
	{
		private readonly ISpaceflightApiService spaceflightApiService;

		public HomeController(ILogger<HomeController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, ISpaceflightApiService spaceflightApiService)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			this.spaceflightApiService = spaceflightApiService;
		}

		[NonAction]
		public sealed override IActionResult Index() => throw new NotImplementedException();

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var response = await spaceflightApiService.GetAll();

			return CurrentTemplate(CurrentPage);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoDemo.Services.Interfaces;
using UmbracoDemo.ViewModels;

namespace UmbracoDemo.Controllers
{
	public class HomeController : RenderController
	{
		private readonly ISpaceflightApiService spaceflightApiService;
		private readonly IVariationContextAccessor _variationContextAccessor;
		private readonly ServiceContext _serviceContext;

		public HomeController(ILogger<HomeController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor,
			ISpaceflightApiService spaceflightApiService, IVariationContextAccessor variationContextAccessor, ServiceContext context)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			this.spaceflightApiService = spaceflightApiService;
			_variationContextAccessor = variationContextAccessor;
			_serviceContext = context;
		}

		[NonAction]
		public sealed override IActionResult Index() => throw new NotImplementedException();

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var response = await spaceflightApiService.GetAll();

			var homeViewModel = new HomeViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor))
			{
				SpaceflightApiResponse = response
			};

			return CurrentTemplate(homeViewModel);
		}
	}
}

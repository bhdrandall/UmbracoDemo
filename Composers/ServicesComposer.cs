using Umbraco.Cms.Core.Composing;
using UmbracoDemo.Services;
using UmbracoDemo.Services.Interfaces;

namespace UmbracoDemo.Composers
{
	public class ServicesComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.Services.AddScoped<ISpaceflightApiService, SpaceflightApiService>();
		}
	}
}
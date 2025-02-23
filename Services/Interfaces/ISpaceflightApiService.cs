using UmbracoDemo.Models;

namespace UmbracoDemo.Services.Interfaces
{
	public interface ISpaceflightApiService
	{
		Task<SpaceflightApiResponse> GetAll();
	}
}

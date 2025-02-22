using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Strings;

namespace UmbracoDemo.ViewModels
{
    public class BannerViewModel
    {
        public string BannerTitle { get; set; }
        public IHtmlEncodedString BannerDescription { get; set; }
        public MediaWithCrops BannerImage { get; set; }
    }
} 
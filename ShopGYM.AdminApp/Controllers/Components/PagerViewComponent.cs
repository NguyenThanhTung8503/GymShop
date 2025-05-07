using Microsoft.AspNetCore.Mvc;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            
            return Task.FromResult<IViewComponentResult>(View("Default", result));
        }
    }
}

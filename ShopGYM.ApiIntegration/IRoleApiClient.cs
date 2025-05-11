using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Role;

namespace ShopGYM.ApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVM>>> GetAll();
    }
}

using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Role;

namespace ShopGYM.AdminApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVM>>> GetAll();
    }
}

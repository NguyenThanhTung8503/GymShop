using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVM>> GetUsersPagings(GetUserPagingRequest request);
    }
}

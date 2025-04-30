using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}

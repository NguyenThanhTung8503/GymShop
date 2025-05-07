
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<PagedResult<UserVM>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<UserVM>> GetById(Guid Id);
        Task<ApiResult<bool>> Delete(Guid Id);
        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequets request);

    }
}

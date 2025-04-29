using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ten nguoi dung khong duoc bo trong");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mat khau khong duoc bo trong")
                .MinimumLength(6).WithMessage("Mat khau phai co it nhat 6 ki tu");
        }
    }
}

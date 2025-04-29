using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ho khong duoc bo trong")
                .MaximumLength(200).WithMessage("Ho khong duoc qua 200 ki tu");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Ten khong duoc bo trong")
                .MaximumLength(200).WithMessage("Ten khong duoc qua 200 ki tu");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Ban qua gia");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email khong duoc bo trong")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email phai dung mau");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("So dien thoai khong duoc bo trong");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ten nguoi dung khong duoc bo trong");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Mat khau khong duoc bo trong")
                .MinimumLength(6).WithMessage("Mat khau phai co it nhat 6 ki tu");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Xác nhận mật khẩu không khớp");
                }
            });

        }
    }
}

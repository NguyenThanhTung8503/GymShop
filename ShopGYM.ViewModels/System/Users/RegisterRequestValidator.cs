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
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Họ không được bỏ trống")
                .MaximumLength(200).WithMessage("Họ không được quá 200 kí tự");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Tên không được bỏ trống")
                .MaximumLength(200).WithMessage("Tên không được quá 200 kí tự");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Bạn quá già");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được bỏ trống")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email phải đúng mẫu");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Số điện thoại không được bỏ trống")
                .MaximumLength(11).WithMessage("Số điện thoại không được quá 11 số"); ;

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tên người dùng không được bỏ trống");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu  không được bỏ trống")
                .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 kí tự");

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

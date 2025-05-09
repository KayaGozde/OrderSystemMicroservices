using AuthService.RequestModels;
using FluentValidation;

namespace AuthService.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı zorunludur");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre zorunludur");
        }
    }
}
using Domain;
using FluentValidation;

namespace Application.Calisans
{
    public class CalisanDtoValidator : AbstractValidator<CalisanDto>
    {
        public CalisanDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Adi).NotEmpty();
            RuleFor(x => x.TcNo).NotEmpty();
            RuleFor(x => x.SSkNo).NotEmpty();  
        }
    }
}
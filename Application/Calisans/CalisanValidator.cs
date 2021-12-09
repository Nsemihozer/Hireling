using Domain;
using FluentValidation;

namespace Application.Calisans
{
    public class CalisanValidator : AbstractValidator<Calisanlar>
    {
        public CalisanValidator()
        {
            RuleFor(x => x.KullaniciAdi).NotEmpty();
            RuleFor(x => x.Sifre).NotEmpty();
            RuleFor(x => x.Adi).NotEmpty();
            RuleFor(x => x.TcNo).NotEmpty();


        }
    }
}
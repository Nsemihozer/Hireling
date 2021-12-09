using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public Calisanlar Calisan { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Calisan).SetValidator(new CalisanValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<int>>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Calisanlar.Add(request.Calisan);
                var result=await context.SaveChangesAsync()>0;
                if (!result)
                {
                    return Result<int>.Failure("Çalışan Yaratılamadı");
                }
                return Result<int>.Success(request.Calisan.CalisanID);
            }
        }
    }
}
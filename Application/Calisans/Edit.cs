using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
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

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this.mapper = mapper;
                this.context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var calisan = await context.Calisanlar.FindAsync(request.Calisan.CalisanID);
                 if (calisan==null)
                {
                    return null;
                }
                mapper.Map(request.Calisan, calisan);
                var result=await context.SaveChangesAsync()>0;
                if (!result)
                {
                    return Result<Unit>.Failure("Çalışan Güncellenemedi");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
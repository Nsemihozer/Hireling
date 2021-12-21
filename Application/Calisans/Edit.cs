using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CalisanDto Calisan { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Calisan).SetValidator(new CalisanDtoValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
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
                var calisan = await context.Calisanlar.FindAsync(request.Calisan.Id);
                if (calisan == null)
                {
                    return null;
                }
                calisan = mapper.Map<CalisanDto,Calisanlar>(request.Calisan,calisan);
                var result = await context.SaveChangesAsync() == 0;
                if (!result)
                {
                    return Result<Unit>.Failure("Çalışan Güncellenemedi");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
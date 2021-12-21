using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Calisans
{
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public CalisanDto Calisan { get; set; }
            public string password { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Calisan).SetValidator(new CalisanDtoValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<int>>
        {
            private readonly DataContext context;
            private readonly UserManager<Calisanlar> userManager;
            private readonly IMapper mapper;
            public Handler(DataContext context, UserManager<Calisanlar> userManager, IMapper mapper)
            {
                this.mapper = mapper;
                this.context = context;
                this.userManager = userManager;
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                //context.Calisanlar.Add(request.Calisan);
                var calisan = this.mapper.Map<Calisanlar>(request);
                var result = await userManager.CreateAsync(calisan, request.password);
                if (!result.Succeeded)
                {
                    return Result<int>.Failure("Çalışan Yaratılamadı");
                }

                return Result<int>.Success(request.Calisan.Id);
            }
        }
    }
}
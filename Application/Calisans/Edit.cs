using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Calisanlar Calisan { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this.mapper = mapper;
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var calisan = await context.Calisanlar.FindAsync(request.Calisan.CalisanID);
                mapper.Map(request.Calisan, calisan);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
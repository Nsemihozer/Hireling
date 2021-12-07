using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Unvans
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Unvanlar Unvan { get; set; }
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
                var unvan = await context.Unvanlar.FindAsync(request.Unvan.UnvanID);
                mapper.Map(request.Unvan, unvan);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
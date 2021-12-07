using Domain;
using MediatR;
using Persistence;

namespace Application.Unvans
{
    public class Delete
    {
          public class Command : IRequest
        {
            public int UnvanID { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var unvan = await context.Unvanlar.FindAsync(request.UnvanID);
                context.Remove(unvan);
                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
using Domain;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Delete
    {
          public class Command : IRequest
        {
            public int CalisanID { get; set; }
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
                var calisan = await context.Calisanlar.FindAsync(request.CalisanID);
                context.Remove(calisan);
                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
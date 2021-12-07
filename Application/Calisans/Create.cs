using Domain;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Create
    {
        public class Command : IRequest<int>
        {
            public Calisanlar Calisan { get; set; }
        }

        public class Handler : IRequestHandler<Command,int>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
               context.Calisanlar.Add(request.Calisan);
               await context.SaveChangesAsync();
               return request.Calisan.CalisanID;
            }
        }
    }
}
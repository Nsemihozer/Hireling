using Domain;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Details
    {
        public class Query : IRequest<Calisanlar> {
            public int CalisanID {get;set;}
         }

        public class Handler : IRequestHandler<Query, Calisanlar>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Calisanlar> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Calisanlar.FindAsync(request.CalisanID);
            }
        }
    }
}
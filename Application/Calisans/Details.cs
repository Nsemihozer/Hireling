using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Details
    {
        public class Query : IRequest<Result<Calisanlar>> {
            public int CalisanID {get;set;}
         }

        public class Handler : IRequestHandler<Query, Result<Calisanlar>>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<Calisanlar>> Handle(Query request, CancellationToken cancellationToken)
            {
                var calisan= await context.Calisanlar.FindAsync(request.CalisanID);

                return Result<Calisanlar>.Success(calisan);
            }
        }
    }
}
using Domain;
using MediatR;
using Persistence;

namespace Application.Unvans
{
    public class Details
    {
        public class Query : IRequest<Unvanlar> {
            public int UnvanID {get;set;}
         }

        public class Handler : IRequestHandler<Query, Unvanlar>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unvanlar> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Unvanlar.FindAsync(request.UnvanID);
            }
        }
    }
}
using Domain;
using MediatR;
using Persistence;

namespace Application.Unvans
{
    public class Create
    {
        public class Command : IRequest<int>
        {
            public Unvanlar Unvan { get; set; }
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
               context.Unvanlar.Add(request.Unvan);
               await context.SaveChangesAsync();
               return request.Unvan.UnvanID;
            }
        }
    }
}
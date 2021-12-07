using MediatR;
using Domain;
using System.Collections.Generic;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Unvans
{
    public class List
    {
        public class Query : IRequest<List<Unvanlar>> { }

        public class Handler : IRequestHandler<Query, List<Unvanlar>>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<Unvanlar>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Unvanlar.ToListAsync();
            }
        }
    }
}
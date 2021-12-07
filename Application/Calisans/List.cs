using MediatR;
using Domain;
using System.Collections.Generic;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Calisans
{
    public class List
    {
        public class Query : IRequest<List<Calisanlar>> { }

        public class Handler : IRequestHandler<Query, List<Calisanlar>>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<Calisanlar>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Calisanlar.ToListAsync();
            }
        }
    }
}
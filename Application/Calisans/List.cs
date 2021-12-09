using MediatR;
using Domain;
using System.Collections.Generic;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Core;

namespace Application.Calisans
{
    public class List
    {
        public class Query : IRequest<Result<List<Calisanlar>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Calisanlar>>>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<List<Calisanlar>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result= await context.Calisanlar.ToListAsync(cancellationToken);

                 return Result<List<Calisanlar>>.Success(result);
            }
        }
    }
}
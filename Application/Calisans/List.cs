using MediatR;
using Domain;
using System.Collections.Generic;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Application.Calisans
{
    public class List
    {
        public class Query : IRequest<Result<List<CalisanDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<CalisanDto>>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this.mapper = mapper;
                this.context = context;
            }

            public async Task<Result<List<CalisanDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var result = await context.Calisanlar
                .ProjectTo<CalisanDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                
                 return Result<List<CalisanDto>>.Success(result);
            }
        }
    }
}
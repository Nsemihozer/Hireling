using MediatR;
using Domain;
using System.Collections.Generic;
using Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Core;
using AutoMapper.QueryableExtensions;

namespace Application.Unvans
{
    public class List
    {
        public class Query : IRequest<Result<List<UnvanDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<UnvanDto>>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                this.mapper = mapper;
                this.context = context;
            }

            public async Task<Result<List<UnvanDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await context.Unvanlar
                .ProjectTo<UnvanDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                return Result<List<UnvanDto>>.Success(result);
            }
        }
    }
}
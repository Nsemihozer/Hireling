using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Calisans
{
    public class Details
    {
        public class Query : IRequest<Result<CalisanDto>> {
            public int CalisanID {get;set;}
         }

        public class Handler : IRequestHandler<Query, Result<CalisanDto>>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;
            public Handler(DataContext context,IMapper mapper)
            {
                this.mapper = mapper;
                this.context = context;
            }

            public async Task<Result<CalisanDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var calisan= await context.Calisanlar
                .ProjectTo<CalisanDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c=> c.Id == request.CalisanID);

                return Result<CalisanDto>.Success(calisan);
            }
        }
    }
}
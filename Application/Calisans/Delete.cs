using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Calisans
{
    public class Delete
    {
          public class Command : IRequest<Result<Unit>>
        {
            public int CalisanID { get; set; }
        }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var calisan = await context.Calisanlar.FindAsync(request.CalisanID);
                if (calisan==null)
                {
                    return null;
                }
                context.Remove(calisan);
                var result=await context.SaveChangesAsync()>0;
                if (!result)
                {
                    return Result<Unit>.Failure("Çalışan Silinemedi");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
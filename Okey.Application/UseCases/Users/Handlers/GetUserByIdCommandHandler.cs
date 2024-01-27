using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Users.Queries;
using Okey.Domain.Entities.Users;

namespace Okey.Application.UseCases.Users.Handlers
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IOkeyDbContext _context;

        public GetUserByIdCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var ambulanceInfo = await _context.user.FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken);

            if (ambulanceInfo is null)
                return default(User);

            return ambulanceInfo;
        }
    }
}

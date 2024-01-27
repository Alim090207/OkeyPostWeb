using MediatR;
using Microsoft.EntityFrameworkCore;
using Okey.Application.Absreactions;
using Okey.Application.UseCases.Users.Commands;
using Okey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IOkeyDbContext _context;
        public DeleteUserCommandHandler(IOkeyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User @class = await _context.user.FirstOrDefaultAsync(x => x.UserId == request.Id, cancellationToken);

            if (@class == null)
                throw new Exception();

            _context.user.Remove(@class);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}

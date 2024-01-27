using MediatR;
using Okey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Application.UseCases.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}

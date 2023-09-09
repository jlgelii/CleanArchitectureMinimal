using CleanArchitecture.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.DeleteUserAccount
{
    public record DeleteUserAccountCommand(int Id) : IRequest<ResponseApi<DeleteUserAccountCommandResponse>>;
}

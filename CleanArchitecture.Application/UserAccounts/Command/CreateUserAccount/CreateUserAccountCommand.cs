using CleanArchitecture.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.CreateUserAccount
{
    public record CreateUserAccountCommand(string Username, string Password) : IRequest<ResponseApi<CreateUserAccountCommandResponse>>;
}

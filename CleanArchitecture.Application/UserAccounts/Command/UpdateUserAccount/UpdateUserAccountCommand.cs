using CleanArchitecture.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.UpdateUserAccount
{
    public record UpdateUserAccountCommand(string Username, string Password) : IRequest<ResponseApi<UpdateUserAccountCommandResponse>>
    {
        public int Id { get; set; }
    }
}

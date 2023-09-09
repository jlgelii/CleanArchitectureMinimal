using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountByCredential
{
    public record GetUserAccountByCredentialQuery(string Username, string Password) : IRequest<GetUserAccountByCredentialQueryResponse>;
}

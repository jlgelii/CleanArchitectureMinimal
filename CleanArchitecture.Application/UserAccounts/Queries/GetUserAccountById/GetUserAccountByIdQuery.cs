using CleanArchitecture.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountById
{
    public record GetUserAccountByIdQuery(int Id) : IRequest<ResponseApi<GetUserAccountByIdQueryResponse>>;
}

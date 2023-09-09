using CleanArchitecture.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountQuery : IRequest<ResponseApi<List<GetUserAccountQueryResponse>>>
    {
    }
}

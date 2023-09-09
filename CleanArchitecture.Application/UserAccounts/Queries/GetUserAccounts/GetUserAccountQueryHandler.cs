using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountQueryHandler : IRequestHandler<GetUserAccountQuery, List<GetUserAccountQueryResponse>>
    {
        private List<GetUserAccountQueryResponse> users = new List<GetUserAccountQueryResponse>()
        {
            new GetUserAccountQueryResponse() { Id = 1, Username = "Admin", Password = "Admin", Token = "" }
        };

        public Task<List<GetUserAccountQueryResponse>> Handle(GetUserAccountQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(users);
        }
    }
}

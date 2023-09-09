using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountQueryHandler : IRequestHandler<GetUserAccountQuery, ResponseApi<List<GetUserAccountQueryResponse>>>
    {
        private readonly IApplicationDatabaseContext _context;

        public GetUserAccountQueryHandler(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ResponseApi<List<GetUserAccountQueryResponse>>> Handle(GetUserAccountQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.UserAccount
                                    .Select(u => new GetUserAccountQueryResponse
                                    {
                                        Id = u.Id,
                                        Username = u.Username,
                                        Password = u.Password,
                                    })
                                    .ToListAsync();

            return ResponseApi.Success(users);
        }
    }
}

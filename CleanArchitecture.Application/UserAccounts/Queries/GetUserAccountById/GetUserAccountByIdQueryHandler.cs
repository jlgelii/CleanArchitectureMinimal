using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountById
{
    public class GetUserAccountByIdQueryHandler : IRequestHandler<GetUserAccountByIdQuery, ResponseApi<GetUserAccountByIdQueryResponse>>
    {
        private readonly IApplicationDatabaseContext _context;

        public GetUserAccountByIdQueryHandler(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ResponseApi<GetUserAccountByIdQueryResponse>> Handle(GetUserAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.UserAccount
                               .Where(u => u.Id == request.Id)
                               .Select(u => new GetUserAccountByIdQueryResponse
                               {
                                   Id = request.Id,
                                   Username = u.Username,
                                   Password = u.Password,
                               })
                               .FirstOrDefaultAsync();

            return ResponseApi.Success(user);
        }
    }
}

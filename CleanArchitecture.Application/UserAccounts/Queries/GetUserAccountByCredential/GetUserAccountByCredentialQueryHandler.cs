using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Services;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountByCredential
{
    public class GetUserAccountByCredentialQueryHandler : IRequestHandler<GetUserAccountByCredentialQuery, GetUserAccountByCredentialQueryResponse>
    {
        private readonly IJwtServices _jwt;
        private readonly IApplicationDatabase _context;

        public GetUserAccountByCredentialQueryHandler(IJwtServices jwt, IApplicationDatabase context)
        {
            this._jwt = jwt;
            this._context = context;
        }

        public async Task<GetUserAccountByCredentialQueryResponse> Handle(GetUserAccountByCredentialQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.UserAccount.ToListAsync();

            return new GetUserAccountByCredentialQueryResponse()
            {
                Id = 1,
                Username = request.Username,
                Token = _jwt.CreateToken(new TokenData
                {
                    UserId = 1
                }),
            };
        }
    }
}

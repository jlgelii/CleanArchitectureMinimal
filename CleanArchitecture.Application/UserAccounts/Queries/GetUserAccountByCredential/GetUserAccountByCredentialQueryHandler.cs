using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Services;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountByCredential
{
    public class GetUserAccountByCredentialQueryHandler : IRequestHandler<GetUserAccountByCredentialQuery, ResponseApi<GetUserAccountByCredentialQueryResponse>>
    {
        private readonly IJwtServices _jwt;
        private readonly IApplicationDatabaseContext _context;

        public GetUserAccountByCredentialQueryHandler(IJwtServices jwt, 
            IApplicationDatabaseContext context)
        {
            this._jwt = jwt;
            this._context = context;
        }

        public async Task<ResponseApi<GetUserAccountByCredentialQueryResponse>> Handle(GetUserAccountByCredentialQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.UserAccount
                                      .FirstOrDefaultAsync(u => u.Username == request.Username
                                                             && u.Password == request.Password);

            return await Task.FromResult(ResponseApi.Success(new GetUserAccountByCredentialQueryResponse()
            {
                Id = 1,
                Username = request.Username,
                Token = _jwt.CreateToken(new TokenData
                {
                    UserId = 1
                }),
            }));
        }
    }
}

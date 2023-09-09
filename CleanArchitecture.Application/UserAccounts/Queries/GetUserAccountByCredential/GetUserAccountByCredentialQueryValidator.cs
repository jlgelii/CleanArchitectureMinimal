using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Middleware;
using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountByCredential
{
    public class GetUserAccountByCredentialQueryValidator : IValidationHandler<GetUserAccountByCredentialQuery>
    {
        private readonly IApplicationDatabaseContext _context;

        public GetUserAccountByCredentialQueryValidator(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ValidationResults> Validate(GetUserAccountByCredentialQuery request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return await Task.FromResult(ValidationResults.Fail("Input all the required fields."));

            if (_context.UserAccount.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password) is null)
                return await Task.FromResult(ValidationResults.Fail("User does not exist."));

            return ValidationResults.Success;
        }
    }
}

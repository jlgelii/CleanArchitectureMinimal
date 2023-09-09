using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Middleware;
using CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountByCredential;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountById
{
    public class GetUserAccountByIdQueryValidator : IValidationHandler<GetUserAccountByIdQuery>
    {
        private readonly IApplicationDatabaseContext _context;

        public GetUserAccountByIdQueryValidator(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ValidationResults> Validate(GetUserAccountByIdQuery request)
        {
            if (_context.UserAccount.FirstOrDefault(u => u.Id == request.Id) is null)
                return await Task.FromResult(ValidationResults.Fail("User does not exist."));

            return await Task.FromResult(ValidationResults.Success);
        }
    }
}

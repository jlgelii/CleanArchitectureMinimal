using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Middleware;
using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.CreateUserAccount
{
    public class CreateUserAccountCommandValidator : IValidationHandler<CreateUserAccountCommand>
    {
        private readonly IApplicationDatabaseContext _context;

        public CreateUserAccountCommandValidator(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public Task<ValidationResults> Validate(CreateUserAccountCommand request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return Task.FromResult(ValidationResults.Fail("Please input all the required fields."));

            if (_context.UserAccount.FirstOrDefault(u => u.Username == request.Username) is not null)
                return Task.FromResult(ValidationResults.Fail("Username already exist"));

            return Task.FromResult(ValidationResults.Success);
        }
    }
}

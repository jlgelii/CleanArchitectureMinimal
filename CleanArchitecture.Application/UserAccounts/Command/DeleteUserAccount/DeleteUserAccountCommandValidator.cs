﻿using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Middleware;
using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.DeleteUserAccount
{
    public class DeleteUserAccountCommandValidator : IValidationHandler<DeleteUserAccountCommand>
    {
        private readonly IApplicationDatabaseContext _context;

        public DeleteUserAccountCommandValidator(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ValidationResults> Validate(DeleteUserAccountCommand request)
        {
            if (_context.UserAccount.FirstOrDefault(u => u.Id == request.Id) is null)
                return await Task.FromResult(ValidationResults.Fail("User does not found."));

            return await Task.FromResult(ValidationResults.Success);
        }
    }
}

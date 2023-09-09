using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.DeleteUserAccount
{
    public class DeleteUserAccountCommandHandler : IRequestHandler<DeleteUserAccountCommand, ResponseApi<DeleteUserAccountCommandResponse>>
    {
        private readonly IApplicationDatabaseContext _context;

        public DeleteUserAccountCommandHandler(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ResponseApi<DeleteUserAccountCommandResponse>> Handle(DeleteUserAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.UserAccount
                                     .FirstOrDefaultAsync(u => u.Id == request.Id);

            user.IsDeleted = true;
            _context.SaveChanges();

            return await Task.FromResult(ResponseApi.Success(new DeleteUserAccountCommandResponse
            {
                Id = user.Id,
            }));
        }
    }
}

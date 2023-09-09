using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UserAccounts.Command.UpdateUserAccount
{
    public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, ResponseApi<UpdateUserAccountCommandResponse>>
    {
        private readonly IApplicationDatabaseContext _context;

        public UpdateUserAccountCommandHandler(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ResponseApi<UpdateUserAccountCommandResponse>> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.UserAccount
                                     .FirstOrDefaultAsync(u => u.Id == request.Id);

            user.Password = request.Password;
            _context.SaveChanges();

            return await Task.FromResult(ResponseApi.Success(new UpdateUserAccountCommandResponse
            {
                Id = user.Id,
                Username = request.Username,
                Password = request.Password,
            }));
        }
    }
}

using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UserAccounts.Command.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, ResponseApi<CreateUserAccountCommandResponse>>
    {
        private readonly IApplicationDatabaseContext _context;

        public CreateUserAccountCommandHandler(IApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<ResponseApi<CreateUserAccountCommandResponse>> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var useraccount = new UserAccount
            {
                Username = request.Username,
                Password = request.Password,
            };

            _context.UserAccount.Add(useraccount);
            _context.SaveChanges();

            return await Task.FromResult(ResponseApi.Success(new CreateUserAccountCommandResponse
            {
                Id = useraccount.Id,
                Username = useraccount.Username,
                Password = useraccount.Password,
            }));
        }
    }
}

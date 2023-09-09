using CleanArchitecture.Application.UserAccounts.Queries.GetUserAccounts;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.API.Endpoints
{
    public static class UserAccountEndpoint 
    {
        public static WebApplication MapUserAccountEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/useraccount")
                .WithTags("UserAccount")
                .WithOpenApi()
                .RequireAuthorization();


            root.MapGet("/", async (ISender sender) =>
            {
                var response = await sender.Send(new GetUserAccountQuery());
                return response;
            });


            return app;
        }
    }
}

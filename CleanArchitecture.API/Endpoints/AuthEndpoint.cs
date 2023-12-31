﻿using CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountByCredential;
using MediatR;

namespace CleanArchitecture.API.Endpoints
{
    public static class AuthEndpoint
    {
        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/auth")
               .WithTags("Auth")
               .WithOpenApi()
               .RequireAuthorization();


            root.MapPost("/", async (ISender sender, GetUserAccountByCredentialQuery query) =>
            {
                var response = await sender.Send(query);

                if (response.Error)
                    return Results.BadRequest(response.ModelStateError);

                return Results.Ok(response.Data);
            })
            .AllowAnonymous();


            return app;
        }
    }
}

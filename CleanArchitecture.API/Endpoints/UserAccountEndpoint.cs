using Azure.Core;
using CleanArchitecture.Application.UserAccounts.Command.CreateUserAccount;
using CleanArchitecture.Application.UserAccounts.Command.DeleteUserAccount;
using CleanArchitecture.Application.UserAccounts.Command.UpdateUserAccount;
using CleanArchitecture.Application.UserAccounts.Queries.GetUserAccountById;
using CleanArchitecture.Application.UserAccounts.Queries.GetUserAccounts;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

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

            root.MapGet("", GetAllUsers).WithDescription("Get all users");
            root.MapPost("", CreateUserAccount).WithDescription("Create user.");
            root.MapGet("/{id}", GetUserById).WithDescription("Find user by id");
            root.MapPut("/{id}", UpdateUserAccount).WithDescription("Find user by id");
            root.MapDelete("/{id}", DeleteUserAccount).WithDescription("Find user by id");

            return app;
        }


        private async static Task<IResult> GetAllUsers(ISender sender)
        {
            var response = await sender.Send(new GetUserAccountQuery());
            if (response.Error)
                return Results.BadRequest(response.ModelStateError);

            return Results.Ok(response.Data);
        }

        private async static Task<IResult> GetUserById(ISender sender, int id)
        {
            var response = await sender.Send(new GetUserAccountByIdQuery(id));
            if (response.Error)
                return Results.BadRequest(response.ModelStateError);

            return Results.Ok(response.Data);
        }

        private async static Task<IResult> CreateUserAccount(ISender sender, CreateUserAccountCommand command)
        {
            var response = await sender.Send(command);
            if (response.Error)
                return Results.BadRequest(response.ModelStateError);

            return Results.Ok(response.Data);
        }

        private async static Task<IResult> UpdateUserAccount(ISender sender, int id, UpdateUserAccountCommand command)
        {
            command.Id = id;
            var response = await sender.Send(command);
            if (response.Error)
                return Results.BadRequest(response.ModelStateError);

            return Results.Ok(response.Data);
        }

        private async static Task<IResult> DeleteUserAccount(ISender sender, int id)
        {
            var response = await sender.Send(new DeleteUserAccountCommand(id));
            if (response.Error)
                return Results.BadRequest(response.ModelStateError);

            return Results.Ok(response.Data);
        }
    }
}

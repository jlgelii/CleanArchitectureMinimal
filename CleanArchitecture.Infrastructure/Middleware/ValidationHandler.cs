using CleanArchitecture.Application.Configurations.Middleware;
using CleanArchitecture.Domain.Common;
using MediatR;
using System.Net;

namespace CleanArchitecture.Infrastructure.Middleware
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : CQRSResponse, new()
    {
        private readonly IValidationHandler<TRequest> validationHandler;

        public ValidationBehaviour()
        {

        }

        public ValidationBehaviour(IValidationHandler<TRequest> validationHandler)
        {
            this.validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validationHandler == null)
            {
                return await next();
            }

            var result = await validationHandler.Validate(request);
            if (!result.IsSuccessful)
            {
                return new TResponse { Message = result.Error, StatusCode = HttpStatusCode.BadRequest, Error = true };
            }

            return await next();
        }
    }
}

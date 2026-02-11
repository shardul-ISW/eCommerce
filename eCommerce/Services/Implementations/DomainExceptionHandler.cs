using ECommerce.Models.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Implementations
{
    public sealed class DomainExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not DomainException domainException)
                return false;

            httpContext.Response.StatusCode = domainException.StatusCode;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = domainException.StatusCode,
                Title = exception.GetType().Name,
                Detail = domainException.Message
            }, cancellationToken);

            return true;
        }
    }
}
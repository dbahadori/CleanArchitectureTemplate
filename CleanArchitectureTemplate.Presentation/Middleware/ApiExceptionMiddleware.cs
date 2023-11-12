using CleanArchitectureReferenceTemplate.Presentation.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;
using System;
using Microsoft.AspNetCore.Http;
using CleanArchitectureReferenceTemplate.Presentation.Common.Exceptions;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions;

namespace CleanArchitectureReferenceTemplate.Presentation.Middleware
{
    public class ApiExceptionMiddleware
    {
        private readonly IDictionary<Type, Func<HttpContext, Exception, string, Task>> _exceptionHandlers;
        private readonly RequestDelegate _next;
        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _exceptionHandlers = new Dictionary<Type, Func<HttpContext, Exception, string, Task>>();

            AddExceptionHandler<CustomValidationException>(HandleValidationException);
            AddExceptionHandler<NotFoundException>(HandleNotFoundException);
            AddExceptionHandler<ExistEmailException>(HandleExistEmailException);
            AddExceptionHandler<PasswordPatternException>(HandlePasswordPatternException);
            AddExceptionHandler<ForbiddenException>(HandleForbiddenException);

            _next = next;

        }

        private void AddExceptionHandler<TException>(Func<HttpContext, Exception, string, Task> handler) where TException : Exception
        {
            _exceptionHandlers.Add(typeof(TException), handler);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {

            Type type = exception.GetType();
            var title = "";

            if (_exceptionHandlers.ContainsKey(type))
            {

                if (exception.Data.Contains("Title") && exception.Data["Title"] != null)
                {
                    title = (string)exception.Data["Title"]!;
                }

                await _exceptionHandlers[type].Invoke(httpContext, exception, title);
                return;
            }

            if (!httpContext.Response.HasStarted)
            {
                var details = new ProblemDetails()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Title = "An unexpected error occurred.",
                    Detail = exception.Message,

                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(details));
            }
        }

        private async Task HandleValidationException(HttpContext context, Exception ex, string title)
        {
            var validationException = (CustomValidationException)ex;

            var details = new ValidationProblemDetails(validationException.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));
        }

        private async Task HandleExistEmailException(HttpContext context, Exception ex, string title)
        {
            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = Resources.ErrorMessages.EmailUsedBefore,
                Detail = ex.Message,
                Extensions =
                    {
                        { "message", ex.Data["LocalizedMessage"] }
                    }
            };
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }
        private async Task HandleNotFoundException(HttpContext context, Exception ex, string title)
        {

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = !string.IsNullOrWhiteSpace(title) ? title : "The specified resource was not found.",
                Detail = ex.Message,
                Extensions =
                    {
                        { "userError", ex.Data["LocalizedMessage"] }
                    }

            };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }

        private async Task HandlePasswordPatternException(HttpContext context, Exception ex, string title)
        {

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = Resources.ErrorMessages.PasswordError,
                Detail = ex.Message,
                Extensions =
                    {
                        { "message", ex.Data["LocalizedMessage"] }
                    }
            };
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }

        private async Task HandleForbiddenException(HttpContext context, Exception ex, string title)
        {

            var details = new ProblemDetails()
            {
                Type = "",
                Title = !string.IsNullOrWhiteSpace(title) ? title : "Forbidden",
                Detail = ex.Message,
                Extensions =
                    {
                        { "userError", ex.Data["LocalizedMessage"] }
                    }

            };
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CleanArchitectureTemplate.Presentation.Common.Exceptions;
using CleanArchitectureTemplate.Application.Common.Implementation.Exceptions;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using FluentValidation;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanArchitectureTemplate.Presentation.Middleware
{
    public class ApiExceptionMiddleware
    {
        private readonly IDictionary<Type, Func<HttpContext, CustomException, Task>> _exceptionHandlers;
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _exceptionHandlers = new Dictionary<Type, Func<HttpContext, CustomException, Task>>();

            AddExceptionHandler<CustomValidationException>(HandleCustomValidationException);
            AddExceptionHandler<NotFoundException>(HandleNotFoundException);
            AddExceptionHandler<ExistEmailException>(HandleExistEmailException);
            AddExceptionHandler<PasswordPatternException>(HandlePatternException);
            AddExceptionHandler<ForbiddenException>(HandleForbiddenException);

            // Configure default settings for JsonConvert
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            _next = next;

        }

        private void AddExceptionHandler<TException>(Func<HttpContext, CustomException, Task> handler) where TException : Exception
        {
            _exceptionHandlers.Add(typeof(TException), handler);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ex)
            {
                // Handle FluentValidation.ValidationException separately
                await HandleValidationException(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {

            Type type = exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {

                await _exceptionHandlers[type].Invoke(httpContext, (CustomException)exception);
                return;
            }

            if (!httpContext.Response.HasStarted)
            {   // log the exception
                var details = new ProblemDetails()
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An unexpected error occurred.",
                    Detail = null,
                    Instance = httpContext.Request.Path,
                    Extensions = null
                  

                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(details));
            }
        }

        private async Task HandleValidationException(HttpContext context, ValidationException ex)
        {

            var validationException = new CustomValidationException()
                .WithParam(ex.Errors);
            

            var details = new ValidationProblemDetails()
            
            {
                Type = validationException.Type ?? "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Title = validationException.UserFriendlyMessage, // User-friendly title
                Detail = validationException.DeveloperDetail, // Developer detail
                Instance = context.Request.Path
            };

            // Extract additional information from the exception

            if (!string.IsNullOrEmpty(validationException.ErrorCode))
            {
                details.Extensions["error_code"] = validationException.ErrorCode;
            }

            if (validationException.Param != null && validationException.Param.Count > 0)
            {
                details.Extensions["param"] = validationException.Param;
            }
            details.Errors = null;
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));
        }
        private async Task HandleCustomValidationException(HttpContext context, CustomException ex)
        {
            var details = new ValidationProblemDetails()

            {
                Type = ex.Type ?? "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Title = ex.UserFriendlyMessage, // User-friendly title
                Detail = ex.DeveloperDetail, // Developer detail
                Instance = context.Request.Path
            };

            // Extract additional information from the exception

            if (!string.IsNullOrEmpty(ex.ErrorCode))
            {
                details.Extensions["error_code"] = ex.ErrorCode;
            }

            if (ex.Param != null && ex.Param.Count > 0)
            {
                details.Extensions["param"] = ex.Param;
            }
            details.Errors = null;
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));
        }

        private async Task HandleExistEmailException(HttpContext context, CustomException ex)
        {
            var details = new ProblemDetails
            {
                Type = ex.Type ?? "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                Status = StatusCodes.Status409Conflict,
                Title = ex.Message, // User-friendly title
                Detail = ex.DeveloperDetail, // Developer detail
                Instance = context.Request.Path
            };

            // Extract additional information from the exception
            if (!string.IsNullOrEmpty(ex.ErrorCode))
            {
                details.Extensions["error_code"] = ex.ErrorCode;
            }

            if (ex.Param != null && ex.Param.Count > 0)
            {
                details.Extensions["param"] = ex.Param;
            }
            
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }
        private async Task HandleNotFoundException(HttpContext context, CustomException ex)
        {
            var details = new ProblemDetails
            {
                Type = ex.Type ?? "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Status = StatusCodes.Status404NotFound,
                Title = ex.Message, // User-friendly title
                Detail = ex.DeveloperDetail, // Developer detail
                Instance = context.Request.Path
            };

            // Extract additional information from the exception
            if (!string.IsNullOrEmpty(ex.ErrorCode))
            {
                details.Extensions["error_code"] = ex.ErrorCode;
            }

            if (ex.Param != null && ex.Param.Count > 0)
            {
                details.Extensions["param"] = ex.Param;
            }
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }

        private async Task HandlePatternException(HttpContext context, CustomException ex)
        {

            var details = new ProblemDetails
            {
                Type = ex.Type ?? "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Title = ex.Message, // User-friendly title
                Detail = ex.DeveloperDetail, // Developer detail
                Instance = context.Request.Path
            };

            // Extract additional information from the exception
            if (!string.IsNullOrEmpty(ex.ErrorCode))
            {
                details.Extensions["error_code"] = ex.ErrorCode;
            }

            if (ex.Param != null && ex.Param.Count > 0)
            {
                details.Extensions["param"] = ex.Param;
            }
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }

        private async Task HandleForbiddenException(HttpContext context, CustomException ex)
        {
            var details = new ProblemDetails
            {
                Type = ex.Type ?? "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3",
                Status = StatusCodes.Status403Forbidden,
                Title = ex.Message, // User-friendly title
                Detail = ex.DeveloperDetail, // Developer detail
                Instance = context.Request.Path
            };

            // Extract additional information from the exception
            if (!string.IsNullOrEmpty(ex.ErrorCode))
            {
                details.Extensions["error_code"] = ex.ErrorCode;
            }

            if (ex.Param != null && ex.Param.Count > 0)
            {
                details.Extensions["param"] = ex.Param;
            }
            context.Response.StatusCode = details.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(details));

        }

    }
}

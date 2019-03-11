using System.Net;
using HostOcean.Application.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HostOcean.Api.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public MvcExceptionFilter(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (context.Exception is ValidationException validationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    validationException.Failures);

                return;
            }

            if (context.Exception is AuthorizationException authorizationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new JsonResult(
                    authorizationException.Message);

                return;
            }

            if (context.Exception is NotFoundException notFoundException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(
                    notFoundException.Message);

                return;
            }
            
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = _hostingEnvironment.IsDevelopment() ?
                new JsonResult(new
                {
                    error = new[] { context.Exception.Message },
                    stackTrace = context.Exception.StackTrace
                }) 
                : new JsonResult(new { Error = "An unexpected internal server error has occurred."});

            context.Result = result;
        }
    }
}
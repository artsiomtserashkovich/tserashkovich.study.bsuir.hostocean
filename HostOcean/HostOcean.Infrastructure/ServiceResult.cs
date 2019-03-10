using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HostOcean.Infrastructure
{
    public class ServiceResult
    {
        public bool IsSucceeded { get; set; }
        public string Error { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResult()
        {
            IsSucceeded = true;
        }

        public ServiceResult(Exception exception)
        {
            Error = exception.Message;
            IsSucceeded = false;
        }

        public ServiceResult(List<string> errors)
        {
            Errors = errors;
            IsSucceeded = false;
        }

        public ServiceResult(string error)
        {
            Error = error;
            IsSucceeded = false;
        }

        public ServiceResult(IdentityResult result)
        {
            Errors = result.Errors.Select(e => e.Description).ToList();
            IsSucceeded = result.Succeeded;
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Result { get; set; }

        public ServiceResult(T result)
        {
            Result = result;
            IsSucceeded = true;
        }

        public ServiceResult() : base()
        {
        }

        public ServiceResult(Exception exception) :base(exception)
        {
        }

        public ServiceResult(List<string> errors) : base(errors)
        {
        }

        public ServiceResult(string error) : base(error)
        {
        }

        public ServiceResult(IdentityResult result) : base(result)
        {
        }
    }
}
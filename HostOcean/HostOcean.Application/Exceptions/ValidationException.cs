using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace HostOcean.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(IList<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public ValidationException(string property, string[] failures)
        {
            if(!string.IsNullOrEmpty(property) && failures!= null && failures.Length != 0 && !string.IsNullOrEmpty(failures[0]))
                Failures.Add(property,failures);
        }

        public ValidationException(IDictionary<string, string[]> failures)
            :this()
        {
            if (failures == null) return;

            foreach (var fail in failures)
                Failures.Add(fail);
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}

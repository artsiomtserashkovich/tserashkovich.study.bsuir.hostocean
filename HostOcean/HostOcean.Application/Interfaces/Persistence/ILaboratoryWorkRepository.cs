using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Interfaces.Persistence
{
    public interface ILaboratoryWorkRepository : IRepository<LaboratoryWork>
    {
        IEnumerable<TResult> GetPredicatedAsync<TResult>(
            Expression<Func<LaboratoryWork, bool>> predicate,
            Expression<Func<LaboratoryWork, TResult>> selector);
    }
}

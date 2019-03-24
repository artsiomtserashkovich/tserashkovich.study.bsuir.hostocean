using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;

namespace HostOcean.Persistence.Repositories
{
    public class LaboratoryWorkRepository: Repository<LaboratoryWork>, ILaboratoryWorkRepository
    {
        public LaboratoryWorkRepository(HostOceanDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<TResult> GetPredicatedAsync<TResult>(
            Expression<Func<LaboratoryWork, bool>> predicate,
            Expression<Func<LaboratoryWork, TResult>> selector) =>
                DbSet.Where(predicate).Select(selector);
    }
}

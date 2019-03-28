using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Interfaces.Infrastructure
{
    public interface IGroupSheduleService
    {
        Task<IEnumerable<LaboratoryWorkEvent>> GetEventsForPeriod(string calendarId, DateTime startDateTime, DateTime endDateTime);
    }
}
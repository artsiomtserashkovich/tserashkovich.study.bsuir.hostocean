using System;
using System.Linq.Expressions;
using MediatR;

namespace HostOcean.Application.Interfaces.Infrastructure
{
    public interface ICommandsSheduler
    {
        string ExecuteExpressionWithDelay(Expression<Action> expression, TimeSpan delay);
        string ExecuteNow(IRequest request, string description = null);
        string ExecuteAfterSuccessParentCommand(IRequest request, string parentCommandId, string description = null);
        string ExecuteAtDateTime(IRequest request, DateTime scheduleAt, string description = null);
        string ExecuteWithDelay(IRequest request, TimeSpan delay, string description = null);
        string ExecutesByCronExpression(IRequest request, string jobId, string cronExpression,
            string description = null);
    }
}
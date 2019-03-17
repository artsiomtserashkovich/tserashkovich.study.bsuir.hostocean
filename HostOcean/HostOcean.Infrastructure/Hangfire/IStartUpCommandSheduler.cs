using System;
using System.Linq.Expressions;
using HostOcean.Application.Interfaces.Infrastructure;

namespace HostOcean.Infrastructure.Hangfire
{
    public interface IStartupCommandSheduler : ICommandsSheduler
    {
        string ExecuteExpressionWithDelay(Expression<Action> expression, TimeSpan delay);
        string ExecuteExpression(Expression<Action> expression);
        string ExecuteExpressionAfterSuccessPrevious(Expression<Action> expression, string previousId);
    }
}

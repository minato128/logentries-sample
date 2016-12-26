using System.Diagnostics;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace WebApplication1
{
    public class TestExceptionLogger : ExceptionLogger
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Error(context.Exception);
        }
    }
}
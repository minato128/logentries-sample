using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin;
using NLog;
using Owin;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public partial class Startup
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Configuration(IAppBuilder app)
        {
            _logger.Debug("Configuration Start");

            ConfigureAuth(app);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IExceptionLogger), new TestExceptionLogger());

            LogEventInfo theEvent = new LogEventInfo(LogLevel.Debug, _logger.Name, "Configuration End");
            theEvent.Properties["jsontest"] = Json.Encode(new {test111 = 12344});
            _logger.Log(theEvent);
        }
    }
}

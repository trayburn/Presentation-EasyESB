using System;
using System.Linq;
using System.Collections.Generic;
using Castle.Core.Logging;
using System.Data.Entity;
using MvcApplication1.Models;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MvcApplication1.App_Start.LogAnnouncements), "PostStartup")]
[assembly: WebActivator.ApplicationShutdownMethod(typeof(MvcApplication1.App_Start.LogAnnouncements), "Shutdown")]
namespace MvcApplication1.App_Start
{
    public static class LogAnnouncements
    {
        private static ILogger logger = NullLogger.Instance;
        public static void PostStartup()
        {
#pragma warning disable 618
            logger = IoC.Container.Resolve<ILogger>();
#pragma warning restore 618

            logger.Info("Application Startup Completed");
        }

        public static void Shutdown()
        {
            logger.Info("Application Shutdown");
        }
    }
}

using System.Reflection;
using System.Xml;

namespace SmallProject.Log4Net
{
    public static class Log4NetConfiguration
    {
        public static void ConfigureLog4Net(XmlDocument log4netConfig)
        {
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                                                           typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}

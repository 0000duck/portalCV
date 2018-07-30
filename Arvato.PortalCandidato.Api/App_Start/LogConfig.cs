namespace Arvato.PortalCandidato.Api.App_Start
{
    using Serilog;
    using System.Configuration;

    /// <summary>
    /// Configuración de logging con SeriLog. Ver documentación en https://serilog.net/
    /// </summary>
    public class LogConfig
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                //.Enrich.WithProperty("Application", ConfigurationManager.AppSettings["Application"])
                .WriteTo.RollingFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "logs", "service-{Date}.log"))
                .CreateLogger();
        }
    }
}
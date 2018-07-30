namespace Arvato.PortalCandidato.Api.App_Start
{
    using Arvato.OWIN.Middleware.Logging;
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;

    /// <summary>
    /// Represents configuration for <see cref="IExceptionHandler"/> and <see cref="IExceptionLogger"/>.
    /// </summary>
    public class ServiceConfig
    {
        /// <summary>
        /// Configures custom implementations for: <see cref="IExceptionHandler"/> and <see cref="IExceptionLogger"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.Services.Add(typeof(IExceptionLogger), new ApiExceptionLogger());
        }
    }
}
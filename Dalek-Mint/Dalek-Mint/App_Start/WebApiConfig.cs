namespace Dalek_Mint.App_Start
{
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="WebApiConfig" />
    /// </summary>
    internal class WebApiConfig
    {
        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="configuration">The configuration<see cref="HttpConfiguration"/></param>
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}

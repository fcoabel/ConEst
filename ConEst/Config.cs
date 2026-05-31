using Microsoft.Extensions.Configuration;

namespace ConEst
{
    /// <summary>
    /// Proporciona acceso centralizado a la configuración de la aplicación,
    /// cargada desde el archivo <c>appsettings.json</c>.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Objeto que contiene toda la configuración cargada desde
        /// <c>appsettings.json</c> y otras fuentes definidas.
        /// </summary>
        public static IConfigurationRoot Settings { get; private set; }

        /// <summary>
        /// Inicializa la configuración de la aplicación estableciendo la ruta base
        /// y cargando el archivo <c>appsettings.json</c>.
        /// </summary>
        static Config()
        {
            Settings = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}

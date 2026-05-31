using ConEst.UI;
using Newtonsoft.Json.Linq;
namespace ConEst
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            var _ = Config.Settings; // Carga la configuración al inicio de la aplicación

            ApplicationConfiguration.Initialize();

            using (var dialogoSesion = new SesionUI()) {
                if (dialogoSesion.ShowDialog() == DialogResult.OK)
                {

                    Application.Run(new EstacionesUI());

                }
                else {
                    Application.Exit();
                }
            }

        }
    }

    /// <summary>
    /// Proporciona métodos para modificar valores dentro del archivo
    /// de configuración <c>appsettings.json</c> de la aplicación.
    /// </summary>
    public static class AppSettingsEditor
    {
        /// <summary>
        /// Ruta completa al archivo <c>appsettings.json</c> ubicado
        /// en el directorio base de la aplicación.
        /// </summary>
        private static readonly string filePath =
            Path.Combine(AppContext.BaseDirectory, "appsettings.json");

        /// <summary>
        /// Actualiza un valor dentro de una sección específica del archivo
        /// <c>appsettings.json</c>.
        /// </summary>
        /// <param name="section">Nombre de la sección donde se encuentra la clave.</param>
        /// <param name="key">Clave del valor a modificar.</param>
        /// <param name="newValue">Nuevo valor que se asignará a la clave.</param>
        public static void UpdateSetting(string section, string key, string newValue)
        {
            var json = JObject.Parse(File.ReadAllText(filePath));

            json[section][key] = newValue;

            File.WriteAllText(filePath, json.ToString());
        }
    }
}
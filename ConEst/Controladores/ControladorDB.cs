using ConEst.Modelos;
using MySqlConnector;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ConEst.Controladores
{
    /// <summary>
    /// Proporciona métodos para interactuar con la base de datos MySQL,
    /// incluyendo la obtención de datos y la validación de la conexión.
    /// </summary>
    public class ControladorDB
    {

        /// <summary>
        /// Dirección del servidor de base de datos configurado por defecto.
        /// </summary>
        private static string Server => Config.Settings["DatabaseDefault:Server"];

        /// <summary>
        /// Nombre de la base de datos configurada por defecto.
        /// </summary>
        private static string DbName => Config.Settings["DatabaseDefault:Name"];

        /// <summary>
        /// Usuario configurado por defecto para la conexión a la base de datos.
        /// </summary>
        private static string User => Config.Settings["DatabaseDefault:User"];

        /// <summary>
        /// Contraseña configurada por defecto para la conexión a la base de datos.
        /// </summary>
        private static string password => Config.Settings["DatabaseDefault:Password"];

        /// <summary>
        /// Cadena de conexión generada automáticamente a partir de los valores por defecto.
        /// </summary>
        private static string cadenaConexionPorDefecto => $"Server={Server};Database={DbName};Uid={User};Pwd={password};";

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControladorDB"/>.
        /// </summary>
        public ControladorDB()
        {
        }

        /// <summary>
        /// Verifica si es posible establecer una conexión con la base de datos
        /// utilizando los parámetros proporcionados.
        /// </summary>
        /// <param name="server">Dirección del servidor MySQL.</param>
        /// <param name="dbName">Nombre de la base de datos.</param>
        /// <param name="user">Usuario de acceso.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>
        /// <c>true</c> si la conexión se establece correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool ProbarConexion(string server = "", string dbName = "", string user = "", string password = "")
        {
            string parametrosConexion = string.IsNullOrEmpty(server) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password)
                ? cadenaConexionPorDefecto
                : $"Server={server};Database={dbName};Uid={user};Pwd={password};";

            try
            {
                using var conn = new MySqlConnection(parametrosConexion);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida las credenciales de un usuario y devuelve su información
        /// si el inicio de sesión es correcto.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="contraseña">Contraseña del usuario.</param>
        /// <returns>
        /// Un objeto <see cref="Usuario"/> si las credenciales son válidas;
        /// de lo contrario, <c>null</c>.
        /// </returns>
        public static Usuario? Login(string nombre, string contraseña)
        {
            string query = "SELECT * FROM Usuarios WHERE Nombre = @nombre And Contraseña = @contraseña";

            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null; // Usuario no existe
                return new Usuario
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Rol = reader.GetInt32("Rol_id")
                };
            }
            catch 
            {
                return null;

            }

        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto que contiene los datos del usuario a registrar.</param>
        /// <returns>
        /// <c>"OK"</c> si la operación fue exitosa; de lo contrario, el mensaje de error.
        /// </returns>
        public static string InsertarUsuario(Usuario usuario)
        {

            string query = "INSERT INTO Usuarios (Nombre, Contraseña, Rol_id) VALUES (@nombre, @contraseña, @rol)";
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        /// <summary>
        /// Obtiene la lista completa de acciones registradas en la base de datos.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="Accion"/>.
        /// </returns>
        public static List<Accion> ObtenerAcciones()
        {
            string query = "SELECT * FROM Acciones";
            var acciones = new List<Accion>();
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    acciones.Add(new Accion
                    {
                        Id = reader.GetInt32("Id"),
                        Tipo = reader.GetString("Tipo")
                    });
                }
                return acciones;

            }
            catch (Exception)
            {

                return acciones;
            }
        }

        /// <summary>
        /// Obtiene la lista de estaciones registradas en la base de datos.
        /// </summary>
        /// <returns>
        /// Una colección <see cref="BindingList{Estacion}"/> con todas las estaciones.
        /// </returns>
        public static BindingList<Estacion> ObtenerEstaciones()
        {
            string query = "SELECT * FROM Estacion";

            try
            {
                var estaciones = new BindingList<Estacion>();
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    estaciones.Add(new Estacion
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Descripcion = reader.GetString("Descripcion"),
                        Latitud = reader.GetDouble("Latitud"),
                        Longitud = reader.GetDouble("Longitud")
                    });
                }
                return estaciones;

            }
            catch (Exception)
            {
                return new BindingList<Estacion>();

            }

        }

        /// <summary>
        /// Obtiene la lista de usuarios registrados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una colección <see cref="BindingList{Usuario}"/> con los usuarios existentes.
        /// </returns>
        public static BindingList<Usuario> ObtenerUsuarios()
        {
            string query = "SELECT Id, Nombre, Rol_id FROM Usuarios";
            var usuarios = new BindingList<Usuario>();
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Rol = reader.GetInt32("Rol_id")
                    });
                }
                return usuarios;

            }
            catch (Exception)
            {
                return usuarios;
            }
        }

        /// <summary>
        /// Obtiene la lista de roles registrados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una colección <see cref="BindingList{Rol}"/> con todos los roles disponibles.
        /// </returns>
        public static BindingList<Rol> ObtenerRoles()
        {
            string query = "SELECT * FROM Roles";
            var roles = new BindingList<Rol>();
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Rol
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Rol")
                    });
                }
                return roles;

            }
            catch (Exception)
            {

                return roles;
            }
        }

        /// <summary>
        /// Obtiene la lista de registros de actividad almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una colección <see cref="BindingList{Registro}"/> con los registros encontrados.
        /// </returns>
        public static BindingList<Registro> ObtenerRegistros()
        {

            string query = "SELECT * FROM Registros";
            var registros = new BindingList<Registro>();
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    registros.Add(new Registro
                    {
                        Id = reader.GetInt32("Id"),
                        Descripcion = reader.GetString("Descripcion"),
                        Accion = reader.GetInt32("Accion_id"),
                        Fecha = reader.GetDateTime("Fecha"),
                        UsuarioId = reader.GetInt32("Usuario_id")
                    });
                }
                return registros;

            }
            catch (Exception)
            {

                return registros;
            }
        }

        /// <summary>
        /// Obtiene la lista de tipos de elementos registrados en la base de datos.
        /// </summary>
        /// <returns>
        /// Una colección <see cref="BindingList{TiposElementos}"/> con los tipos disponibles.
        /// </returns>
        public static BindingList<TiposElementos> ObtenerTiposElementos()
        {
            string query = "SELECT * FROM TiposElementos";
            var tipos = new BindingList<TiposElementos>();
            try
            {

                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tipos.Add(new TiposElementos
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("Nombre")
                    });
                }
                return tipos;

            }
            catch (Exception)
            {

                return tipos;
            }
        }

        /// <summary>
        /// Elimina una estación de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador de la estación a eliminar.</param>
        /// <returns>
        /// <c>true</c> si la estación fue eliminada correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool EliminarEstacion(int id)
        {
            try
            {
                string query = "DELETE FROM Estacion WHERE Id = @id";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Verifica si existe un usuario con el nombre especificado.
        /// </summary>
        /// <param name="nombre">Nombre del usuario a buscar.</param>
        /// <returns>
        /// <c>true</c> si el usuario existe; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool UsuarioExiste(string nombre)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @nombre";
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;

            }
            catch (Exception)
            {
                return false;

            }
        }

        /// <summary>
        /// Inserta un nuevo registro de actividad en la base de datos.
        /// </summary>
        /// <param name="registro">Objeto que contiene la información del registro a insertar.</param>
        public static void InsertarRegistro(Registro registro)
        {
            string query = "INSERT INTO Registros (Accion_id, Descripcion, Usuario_id) VALUES (@accion, @descripcion, @usuarioId)";

            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@accion", registro.Accion);
                cmd.Parameters.AddWithValue("@descripcion", registro.Descripcion);
                cmd.Parameters.AddWithValue("@usuarioId", registro.UsuarioId);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch 
            {

            }

        }

        /// <summary>
        /// Obtiene todos los elementos asociados a una estación específica.
        /// </summary>
        /// <param name="id">Identificador de la estación.</param>
        /// <returns>
        /// Una colección <see cref="BindingList{Elemento}"/> con los elementos encontrados.
        /// Si ocurre un error, se devuelve una lista vacía.
        /// </returns>
        public static BindingList<Elemento> ObtenerElementosPorEstacion(int id)
        {
            string query = "SELECT * FROM Elementos WHERE Estacion_id = @id";
            var elementos = new BindingList<Elemento>();
            try
            {
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    elementos.Add(new Elemento
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Descripcion = reader.GetString("Descripcion"),
                        IdEstacion = reader.GetInt32("Estacion_id"),
                        tipoElemento = reader.GetInt32("TipoElemento_id")
                    });
                }
                return elementos;

            }
            catch
            {
                return elementos;
            }
        }

        /// <summary>
        /// Inserta una nueva estación en la base de datos y devuelve su identificador generado.
        /// </summary>
        /// <param name="estacion">Objeto que contiene los datos de la estación a insertar.</param>
        /// <returns>El identificador generado para la estación.</returns>
        public static int ObtenerId(Estacion estacion)
        {
            string query = "INSERT INTO Estacion (Nombre, Descripcion, Latitud, Longitud) VALUES (@nombre, @descripcion, @latitud, @longitud)";
            using var conn = new MySqlConnection(cadenaConexionPorDefecto);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", estacion.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", estacion.Descripcion);
            cmd.Parameters.AddWithValue("@latitud", estacion.Latitud);
            cmd.Parameters.AddWithValue("@longitud", estacion.Longitud);
            conn.Open();
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.LastInsertedId);
        }

        /// <summary>
        /// Verifica si existe una estación con el nombre especificado.
        /// </summary>
        /// <param name="nombre">Nombre de la estación a comprobar.</param>
        /// <returns>
        /// <c>true</c> si la estación existe; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool ComprobarEstacion(String nombre)
        {
            string query = "SELECT COUNT(*) FROM Estacion WHERE Nombre = @nombre";
            using var conn = new MySqlConnection(cadenaConexionPorDefecto);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        /// <summary>
        /// Inserta un nuevo elemento en la base de datos.
        /// </summary>
        /// <param name="elemento">Objeto que contiene los datos del elemento a insertar.</param>
        /// <returns>
        /// Una cadena vacía si la operación fue exitosa; de lo contrario, el mensaje de error.
        /// </returns>
        public static string InsertarElemento(Elemento elemento)
        {
            try
            {
                string query = "INSERT INTO Elementos (Nombre, Descripcion, Estacion_id, TipoElemento_id) VALUES (@nombre, @descripcion, @estacionId, @tipo)";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", elemento.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", elemento.Descripcion);
                cmd.Parameters.AddWithValue("@estacionId", elemento.IdEstacion);
                cmd.Parameters.AddWithValue("@tipo", elemento.tipoElemento);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        /// <summary>
        /// Actualiza los datos de una estación existente.
        /// </summary>
        /// <param name="estacion">Objeto que contiene los datos actualizados de la estación.</param>
        /// <returns>
        /// <c>true</c> si la actualización fue exitosa; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool ActualizarEstacion(Estacion estacion)
        {
            try
            {
                string query = "UPDATE Estacion SET nombre = @nombre, descripcion = @descripcion, latitud = @latitud, longitud = @longitud WHERE id = @id";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", estacion.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", estacion.Descripcion);
                cmd.Parameters.AddWithValue("@latitud", estacion.Latitud);
                cmd.Parameters.AddWithValue("@longitud", estacion.Longitud);
                cmd.Parameters.AddWithValue("@id", estacion.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza los datos de un elemento existente.
        /// </summary>
        /// <param name="elemento">Objeto que contiene los datos actualizados del elemento.</param>
        /// <returns>
        /// Una cadena vacía si la operación fue exitosa; de lo contrario, el mensaje de error.
        /// </returns>
        public static string ActualizarElemento(Elemento elemento)
        {
            try
            {
                string query = "UPDATE ELEMENTOS SET nombre = @nombre, descripcion = @descripcion, TipoElemento_id = @tipo WHERE id = @id";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", elemento.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", elemento.Descripcion);
                cmd.Parameters.AddWithValue("@tipo", elemento.tipoElemento);
                cmd.Parameters.AddWithValue("@id", elemento.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Elimina un elemento de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador del elemento a eliminar.</param>
        /// <returns>
        /// Una cadena vacía si la operación fue exitosa; de lo contrario, el mensaje de error.
        /// </returns>
        public static string EliminarElemento(int id)
        {
            try
            {
                string query = "DELETE FROM Elementos WHERE Id = @id";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }

        }

        /// <summary>
        /// Elimina todos los elementos asociados a una estación específica.
        /// </summary>
        /// <param name="id">Identificador de la estación.</param>
        /// <returns>
        /// <c>true</c> si la operación fue exitosa; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool EliminarElementoIdEstacion(int id)
        {
            try
            {
                string query = "DELETE FROM Elementos WHERE Estacion_id = @id";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un usuario de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar.</param>
        /// <returns>
        /// <c>true</c> si la operación fue exitosa; de lo contrario, <c>false</c>.
        /// </returns>
        public static bool EliminarUsuario(int id)
        {
            try
            {
                string query = "DELETE FROM Usuarios WHERE Id = @id";
                using var conn = new MySqlConnection(cadenaConexionPorDefecto);
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}

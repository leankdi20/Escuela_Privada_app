using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Base2.models
{
    public class UserRepository
    {
        private SQLiteConnection con;
        private static UserRepository instancia;
        public static UserRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new UserRepository(filename);
        }
        private UserRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Usuario>();
            con.CreateTable<Rol>();
            con.CreateTable<LogIn>();
            con.CreateTable<Avisos>();
            con.CreateTable<Estudiante>();
            con.CreateTable<Asistencia>();
            InicializarRoles();
        }

        public string EstadoMensaje;
        private void InicializarRoles()
        {
            var rolPadre = con.Table<Rol>().FirstOrDefault(r => r.Name == "Padre");
            if (rolPadre == null)
            {
                con.Insert(new Rol { IdRol = 1, Name = "Padre" });
            }

            var rolDocente = con.Table<Rol>().FirstOrDefault(r => r.Name == "Docente");
            if (rolDocente == null)
            {
                con.Insert(new Rol { IdRol = 2, Name = "Docente" });
            }
        }
        public int AddNewUser(string firstname, string lastname, string email, string password, string phone, string address, string city)
        {
            int result = 0;
            try
            {
                // Obtener el rol de "Padre" de la base de datos
                var rolPadre = con.Table<Rol>().FirstOrDefault(r => r.Name == "Padre");
                if (rolPadre == null)
                {
                    throw new Exception("El rol de Padre no existe.");
                }

                // Insertar el nuevo usuario con el rol de "Padre"
                var nuevoUsuario = new Usuario
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Password = password,
                    Phone = phone,
                    Address = address,
                    City = city,
                    IdRol = rolPadre.IdRol,
                    Rol = rolPadre
                };

                result = con.Insert(nuevoUsuario);
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            try
            {
                return con.Table<Usuario>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }

        public Usuario GetUserByEmailAndPassword(string email, string password)
        {
            try
            {
                return con.Table<Usuario>().FirstOrDefault(u => u.Email == email && u.Password == password);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
                return null;
            }
        }


        public int DeleteUser(int id)
        {
            int result = 0;
            try
            {
                con.Delete<Usuario>(id);
                EstadoMensaje = string.Format("Se borra el registro {0}", id);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }


        public int UpdateUser(int id, string password)
        {
            int result = 0;
            try
            {
                result = con.Execute("UPDATE user SET Password = ? Where Id = ? ", password, id);
                EstadoMensaje = string.Format("Actualizado!");
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }


        public Usuario SearchUser(int id)
        {
            Usuario user = null;
            try
            {
                user = con.Find<Usuario>(id);
                if (user != null)
                {
                    EstadoMensaje = string.Format("Registro localizado {0}", id);
                }
                else
                {
                    EstadoMensaje = string.Format("Registro no encontrado {0}", id);
                }
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return user;
        }
    }
}

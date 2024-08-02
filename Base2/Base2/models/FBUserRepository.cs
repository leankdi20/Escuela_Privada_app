using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Firebase.Database.Query;
using SQLite;
//using Firebase.Auth;


namespace Base2.models
{
    public class FBUserRepository
    {
    
        FirebaseClient firebaseClient = new FirebaseClient("https://escuelaprivada-856f0-default-rtdb.firebaseio.com/");



        //buscar usuario para login en la bd Firebase
        public async Task<Usuario> AuthenticateUser(string email, string password)
        {
            try
            {
                var users = await GetAll();
                Console.WriteLine("Usuarios obtenidos:");
                foreach (var u in users)
                {
                    Console.WriteLine($"Email: {u.Email}, Password: {u.Password}, FotoPerfil: {u.FotoPerfil}");
                }

                var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
                else
                {
                    Console.WriteLine($"Usuario encontrado: {user.Email}");
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error authenticating user: {ex.Message}");
                return null;
            }
        }



        public async Task InitializeRoles()
        {
            var roles = new[]
            {
                new { IdRol = 1, NombreRol = "Administrador" },
                new { IdRol = 2, NombreRol = "Padre" },
                new { IdRol = 3, NombreRol = "Docente" }
            };

            foreach (var role in roles)
            {
                try
                {
                    var roleExists = await firebaseClient
                        .Child("Roles")
                        .Child(role.IdRol.ToString())
                        .OnceSingleAsync<dynamic>();

                    if (roleExists == null)
                    {
                        await firebaseClient
                            .Child("Roles")
                            .Child(role.IdRol.ToString())
                            .PutAsync(role);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine($"Error creating role {role.NombreRol}: {ex.Message}");
                }
            }
        }

        public async Task<bool> Save(Usuario user)
        {
            try
            {
                // Inicializar FotoPerfil como cadena vacía si no está inicializado
                if (string.IsNullOrEmpty(user.FotoPerfil))
                {
                    user.FotoPerfil = string.Empty;
                }

                var data = await firebaseClient.Child(nameof(Usuario)).PostAsync(JsonConvert.SerializeObject(user));
                if (!string.IsNullOrEmpty(data.Key))
                {
                    user.IdUser = data.Key;  // Asignar la clave generada al usuario
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
                return false;
            }
        }



        public async Task<List<Usuario>> GetAll()
        {
            try
            {
                var usuarios = (await firebaseClient.Child(nameof(Usuario)).OnceAsync<Usuario>()).Select(item => new Usuario
                {
                    Email = item.Object.Email,
                    FirstName = item.Object.FirstName,
                    FotoPerfil = item.Object.FotoPerfil,
                    IdUser = item.Key,
                    Password = item.Object.Password,
                    LastName = item.Object.LastName,
                    Phone = item.Object.Phone,
                    Address = item.Object.Address,
                    City = item.Object.City,
                    FechaNacimiento = item.Object.FechaNacimiento,
                    Edad = item.Object.Edad,
                    Genero = item.Object.Genero,
                    IdRol = item.Object.IdRol

                }).ToList();

                Console.WriteLine("Cantidad de usuarios obtenidos: " + usuarios.Count);
                return usuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
                return new List<Usuario>();
            }
        }


        public async Task<Usuario> GetUserById(string id)
        {
            try
            {
                var user = await firebaseClient
                    .Child(nameof(Usuario))
                    .Child(id)
                    .OnceSingleAsync<Usuario>();

                if (user != null)
                {
                    user.IdUser = id;  // Asigna el ID manualmente al objeto Usuario
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user by ID: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> UpdateUser(Usuario user)
        {
            try
            {
                // Verificar que el ID del usuario no es nulo o vacío
                if (string.IsNullOrEmpty(user.IdUser))
                {
                    Console.WriteLine("Error: El ID de usuario está vacío.");
                    return false;
                }

                // Depuración: Mostrar información sobre el usuario antes de actualizar
                Console.WriteLine($"Actualizando usuario con ID: {user.IdUser}");
                Console.WriteLine($"Nuevos datos: Address={user.Address}, Phone={user.Phone}");

                // Intentar actualizar en Firebase
                await firebaseClient
                    .Child(nameof(Usuario))
                    .Child(user.IdUser)
                    .PutAsync(JsonConvert.SerializeObject(user));

                Console.WriteLine("Actualización exitosa.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                return false;
            }
        }



        public async Task<List<Usuario>> GetAllByName(string name)
        {
            return (await firebaseClient.Child(nameof(Usuario)).OnceAsync<Usuario>()).Select(item => new Usuario
            {
                Email = item.Object.Email,
                FirstName = item.Object.FirstName,
                FotoPerfil = item.Object.FotoPerfil,
                IdUser = item.Key,
                Password = item.Object.Password
            }).Where(c => c.FirstName.ToLower().Contains(name.ToLower())).ToList();
        }


        public async Task<bool> Update(Usuario student)
        {
            await
            firebaseClient.Child(nameof(Usuario) + "/" + student.IdUser).PutAsync(JsonConvert.SerializeObject(student));
            return true;
        }


        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Usuario) + "/" + id).DeleteAsync();
            return true;
        }
        public async Task<Usuario> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(Usuario) + "/" + id).OnceSingleAsync<Usuario>());
        }

    }
}

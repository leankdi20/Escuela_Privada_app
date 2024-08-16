﻿using System;
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



        public async Task<Usuario> AuthenticateUser(string email, string password)
        {
            try
            {
                var users = await GetAll();
                Console.WriteLine("Usuarios obtenidos:");

                foreach (var u in users)
                {
                    Console.WriteLine($"Email: {u.Email}, Password: {u.Password}, IdRol: {u.IdRol}");
                }

                var user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);

                if (user == null)
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
                else
                {
                    Console.WriteLine($"Usuario encontrado: {user.Email}, Rol: {user.IdRol}");
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
                // Asignar imagen de perfil basada en alguna lógica (por ejemplo, género o rol)
                if (string.IsNullOrEmpty(user.FotoPerfil))
                {
                    user.FotoPerfil = GetDefaultProfilePicture(user);
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

        // Método auxiliar para obtener la imagen de perfil predeterminada
        private string GetDefaultProfilePicture(Usuario user)
        {
            if (user.Genero == "Femenino")
            {
                return "ImgPerfilNina.jpg";
            }
            else if (user.Genero == "Masculino")
            {
                return "ImgPerfilNino.jpg";
            }
            else
            {
                return "defaultProfilePicture.jpg"; // Imagen predeterminada si no hay género especificado
            }
        }



        public async Task<List<Usuario>> GetAll()
        {
            try
            {
                // Obtener el snapshot de los usuarios desde Firebase
                var usuariosSnapshot = await firebaseClient.Child(nameof(Usuario)).OnceAsync<Usuario>();

                // Verificar cuántos elementos se han obtenido en el snapshot
                Console.WriteLine($"Cantidad de elementos obtenidos del snapshot: {usuariosSnapshot.Count}");

                // Crear una lista para almacenar los usuarios procesados
                var usuarios = new List<Usuario>();

                // Procesar cada elemento del snapshot
                foreach (var item in usuariosSnapshot)
                {
                    try
                    {
                        // Intentar mapear el elemento a un objeto Usuario
                        var usuario = new Usuario
                        {
                            Email = item.Object.Email ?? "Sin email",
                            FirstName = item.Object.FirstName ?? "Sin nombre",
                            FotoPerfil = item.Object.FotoPerfil ?? string.Empty,
                            IdUser = item.Key,
                            Password = item.Object.Password ?? string.Empty,
                            LastName = item.Object.LastName ?? "Sin apellido",
                            Phone = item.Object.Phone ?? "Sin teléfono",
                            Address = item.Object.Address ?? "Sin dirección",
                            City = item.Object.City ?? "Sin ciudad",
                            FechaNacimiento = item.Object.FechaNacimiento ?? DateTime.MinValue,
                            Edad = item.Object.Edad ,
                            Genero = item.Object.Genero ?? "Sin género",
                            IdRol = item.Object.IdRol
                        };

                        Console.WriteLine($"Procesando usuario: {item.Key} - {usuario.Email}");

                        // Agregar el usuario a la lista
                        usuarios.Add(usuario);
                    }
                    catch (Exception ex)
                    {
                        // Capturar y mostrar cualquier error al procesar un usuario específico
                        Console.WriteLine($"Error al procesar usuario con ID {item.Key}: {ex.Message}");
                    }
                }

                Console.WriteLine("Cantidad de usuarios convertidos: " + usuarios.Count);
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





        // Método para guardar un Estudiante
        public async Task<bool> SaveEstudiante(Estudiante estudiante)
        {
            try
            {
                // Inicializar FotoPerfil como cadena vacía si no está inicializado
                if (string.IsNullOrEmpty(estudiante.FotoPerfil))
                {
                    estudiante.FotoPerfil = string.Empty;
                }

                var data = await firebaseClient.Child(nameof(Estudiante)).PostAsync(JsonConvert.SerializeObject(estudiante));
                if (!string.IsNullOrEmpty(data.Key))
                {
                    estudiante.IdEstudiante = data.Key;  // Asignar la clave generada al estudiante
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving student: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> SaveAviso(Aviso aviso)
        {
            try
            {
               

                var data = await firebaseClient.Child(nameof(Aviso)).PostAsync(JsonConvert.SerializeObject(aviso));
                if (!string.IsNullOrEmpty(data.Key))
                {
                    aviso.IdAviso = data.Key;  // Asignar la clave generada al estudiante
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving aviso: {ex.Message}");
                return false;
            }
        }


        // Método para obtener todos los estudiantes asociados a un usuario
        public async Task<List<Estudiante>> GetEstudiantesByUserId(string userId)
        {
            try
            {
                var estudiantes = (await firebaseClient.Child(nameof(Estudiante)).OnceAsync<Estudiante>())
                    .Select(item => new Estudiante
                    {
                        IdEstudiante = item.Key, // IdEstudiante es string
                        FirstName = item.Object.FirstName,
                        LastName = item.Object.LastName,
                        FechaNacimiento = item.Object.FechaNacimiento,
                        Cedula = item.Object.Cedula,
                        Address = item.Object.Address,
                        City = item.Object.City,
                        Genero = item.Object.Genero,
                        FotoPerfil = item.Object.FotoPerfil,
                        Enfermedad = item.Object.Enfermedad,
                        NombreMedicina = item.Object.NombreMedicina,
                        Descripcion = item.Object.Descripcion,
                        Alergia = item.Object.Alergia,
                        IdUser = item.Object.IdUser
                    })
                    .Where(e => e.IdUser.ToString() == userId) // Asegúrate que la comparación es adecuada
                    .ToList();

                return estudiantes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener estudiantes: {ex.Message}");
                return new List<Estudiante>();
            }
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            try
            {
                var userQuery = (await firebaseClient
                    .Child(nameof(Usuario))
                    .OnceAsync<Usuario>())
                    .Where(item => item.Object.Email.ToLower() == email.ToLower())
                    .Select(item => new Usuario
                    {
                        IdUser = item.Key, 
                        FirstName = item.Object.FirstName,
                        LastName = item.Object.LastName,
                        Email = item.Object.Email,
                        Password = item.Object.Password,
                        Phone = item.Object.Phone,
                        Address = item.Object.Address,
                        City = item.Object.City,
                        FotoPerfil = item.Object.FotoPerfil,
                        FechaNacimiento = item.Object.FechaNacimiento,
                        Edad = item.Object.Edad,
                        Genero = item.Object.Genero,
                        IdRol = item.Object.IdRol
                    })
                    .FirstOrDefault();

                // If no user was found, return null and log a message
                if (userQuery == null)
                {
                    Console.WriteLine("Usuario no encontrado con el correo proporcionado.");
                    return null;
                }

                // Log the retrieved user's email and return the user object
                Console.WriteLine($"Usuario encontrado: {userQuery.Email}");
                return userQuery;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user by email: {ex.Message}");
                return null;
            }



        }


        public async Task<List<Aviso>> GetAvisosByUserId(string userId)
        {
            try
            {
                var allAvisos = (await firebaseClient.Child(nameof(Aviso)).OnceAsync<Aviso>())
                    .Select(item => new Aviso
                    {
                        IdAviso = item.Key, 
                        TipoAviso = item.Object.TipoAviso,
                        FechaEnvio = item.Object.FechaEnvio,
                        Mensaje = item.Object.Mensaje,
                        IdUser = item.Object.IdUser,
                        IdEstudiante = item.Object.IdEstudiante
                    })
                    .ToList();

                var filteredAvisos = allAvisos.Where(a =>
                    a.IdUser == userId ||
                    a.IdAviso == "O4ONnbj2lDpVb8njkYr"

                ).ToList();

                if (!filteredAvisos.Any())
                {
                    Console.WriteLine("No avisos encontrados");
                }

                return filteredAvisos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error consiguiendo avisos: {ex.Message}");
                return new List<Aviso>();
            }
        }


    }


}

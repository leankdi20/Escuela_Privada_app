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
                var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
                return user;
            }
            catch (Exception ex)
            {
                // Loggear o manejar la excepción según sea necesario
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

        public async Task<bool> Save(Usuario student)
        {
            var data = await firebaseClient.Child(nameof(Usuario)).PostAsync(JsonConvert.SerializeObject(student));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
        public async Task<List<Usuario>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Usuario)).OnceAsync<Usuario>()).Select(item => new Usuario
            {
                Email = item.Object.Email,
                FirstName = item.Object.FirstName,
                FotoPerfil = item.Object.FotoPerfil,
                IdUser = item.Key,
                Password = item.Object.Password
            }).ToList();
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

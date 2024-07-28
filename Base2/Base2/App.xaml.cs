using Base2.models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Base2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Inicializar roles al inicio de la aplicación
            //var userRepository = new FBUserRepository();
            //userRepository.InitializeRoles().Wait();
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Login());

            // Inicializar roles en segundo plano
            InitializeRolesAsync();
        }

        private async void InitializeRolesAsync()
        {
            try
            {
                var userRepository = new FBUserRepository();
                await userRepository.InitializeRoles();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error initializing roles: {ex.Message}");
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

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
            // Obtener la ruta de la base de datos
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "miBaseDeDatos.db3");

            // Inicializar el repositorio de usuarios
            UserRepository.Inicializador(databasePath);
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Login());
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

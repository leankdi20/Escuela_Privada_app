using Base2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipalDocente : ContentPage
    {
        private string filePath;
        private FBUserRepository userRepo;
        private bool isDataLoaded = false;
        public MenuPrincipalDocente()
        {
            InitializeComponent();
            
            //Inicializar userRepo aquí
            userRepo = new FBUserRepository();


            btnAvisos.Clicked += BtnAvisos_Clicked;

            btnPerfil.Clicked += BtnPerfil_Clicked;

            btnAlumnos.Clicked += BtnAlumnos_Clicked;

         
        }

        private async void BtnAlumnos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlumnosPage());
        }

        private async void BtnPerfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilDocente());
        }

        private async void BtnAvisos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AvisosPage());
        }

      

    }

}
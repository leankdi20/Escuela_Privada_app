using Base2.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Firebase.Storage;



namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionPersonal : ContentPage
    {

        private FBUserRepository userRepo;
        private string filePath;
        public InformacionPersonal()
        {
            InitializeComponent();
            userRepo = new FBUserRepository();
            btnEditarDatos.Clicked += BtnEditarDatos_Clicked;
            

            btnAgregarEstudiante.Clicked += BtnAgregarEstudiante_Clicked;
            btnListado.Clicked += BtnListado_Clicked;

            CargarDatosUsuario();
            

            if (SessionData.UserName != null)
                txtNombre.Text = SessionData.UserName;

            if (SessionData.Email != null)
                txtEmail.Text = SessionData.Email;

            if (SessionData.Edad > 0)
                txtEdad.Text = SessionData.Edad.ToString();

            if (SessionData.Genero != null)
                txtGenero.Text = SessionData.Genero;

            if (SessionData.FechaNacimiento != null)
                txtFechaNacimiento.Text = SessionData.FechaNacimiento.Value.ToString("dd/MM/yyyy");

            // ProfileImage.Source = ImageSource.FromFile(SessionData.FotoPerfil);
            if (!string.IsNullOrEmpty(SessionData.FotoPerfil))
            {
                ProfileImage.Source = ImageSource.FromFile(SessionData.FotoPerfil);
            }

        }

        private async void BtnListado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarEstudiantePage());
        }

        private async void BtnAgregarEstudiante_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarEstudiante());
        }





        private async void CargarDatosUsuario()
        {
            var user = await userRepo.GetUserById(SessionData.IdUser);

            if (user != null)
            {
                // Asignar los datos del usuario a los campos de la interfaz

                if (!string.IsNullOrEmpty(user.FotoPerfil))
                {
                    // Aquí asumes que FotoPerfil contiene una ruta de archivo local o una imagen de recurso
                    ProfileImage.Source = ImageSource.FromFile(user.FotoPerfil);
                }
                else
                {
                    // Si no hay foto de perfil, asigna la imagen predeterminada basada en el género del usuario
                    ProfileImage.Source = user.Genero == "Masculino" ? "ImgPerfilHombre.jpg" : "ImgPerfilMujer.png";
                }
            }
            else
            {
                await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
                // En caso de que no se pueda cargar el usuario, también puedes asignar una imagen predeterminada
                ProfileImage.Source = "defaultProfilePicture.jpg"; // Recurso de imagen predeterminada
            }
        }




        private async void BtnEditarDatos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarDatos());
        }

        



        private async void OnProfileSettingsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Profile Settings", "Navigate to profile settings", "OK");
        }

        private async void OnPrivacyClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Privacy", "Navigate to privacy settings", "OK");
        }

        private async void OnNotificationsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Notifications", "Navigate to notification settings", "OK");
        }
    

    }
}
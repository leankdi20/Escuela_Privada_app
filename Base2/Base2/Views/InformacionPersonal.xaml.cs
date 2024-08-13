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
            CargarDatosUsuario();
            
            btnEditarDatos.Clicked += BtnEditarDatos_Clicked;
            

            btnAgregarEstudiante.Clicked += BtnAgregarEstudiante_Clicked;
            btnListado.Clicked += BtnListado_Clicked;

            
            

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
            try
            {
                var user = await userRepo.GetUserById(SessionData.IdUser);

                if (user != null)
                {
                    // Asignar los datos del usuario a las etiquetas
                    txtNombre.Text = user.FirstName ?? string.Empty;
                    txtEmail.Text = user.Email ?? string.Empty;
                    txtFechaNacimiento.Text = user.FechaNacimiento?.ToString("dd/MM/yyyy") ?? "Fecha no disponible";
                    txtEdad.Text = user.Edad > 0 ? user.Edad.ToString() : "Edad no disponible";
                    txtGenero.Text = user.Genero ?? "Género no disponible";

                    if (!string.IsNullOrEmpty(user.FotoPerfil))
                    {
                        ProfileImage.Source = ImageSource.FromFile(user.FotoPerfil);
                    }
                    else
                    {
                        ProfileImage.Source = user.Genero == "Masculino" ? "ImgPerfilHombre.jpg" : "ImgPerfilMujer.png";
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al cargar los datos: {ex.Message}\nDetalles: {ex.StackTrace}", "OK");
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
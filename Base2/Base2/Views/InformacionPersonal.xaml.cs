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
            btnEditarFoto.Clicked += BtnEditarFoto_Clicked;
            btnGuardarFoto.Clicked += BtnGuardarFoto_Clicked;

            userRepo = new FBUserRepository();

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

        private async void BtnEditarFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    filePath = Path.Combine(FileSystem.CacheDirectory, result.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    // Actualizar la imagen en la UI
                    ProfileImage.Source = ImageSource.FromFile(filePath);
                    SessionData.FotoPerfil = filePath;  // Actualizar la sesión con la nueva ruta de la foto
                    Console.WriteLine($"Foto seleccionada: {filePath}");  // Mensaje de depuración
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error", "This device does not support photo picking.", "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Error", "Permission to access photos was denied.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async void BtnGuardarFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine($"Intentando guardar foto: {filePath}");  // Mensaje de depuración
                if (!string.IsNullOrEmpty(filePath))
                {
                    // Obtener el usuario actual de la base de datos
                    var user = await userRepo.GetUserById(SessionData.IdUser);
                    if (user != null)
                    {
                        // Mantener el IdUser y actualizar solo la foto de perfil
                        user.FotoPerfil = filePath;

                        // Actualizar el usuario en la base de datos
                        bool isUpdated = await userRepo.UpdateUser(user);
                        if (isUpdated)
                        {
                            await DisplayAlert("Success", "Foto de perfil actualizada exitosamente", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo actualizar la foto de perfil", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Usuario no encontrado", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se ha seleccionado ninguna foto", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
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
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
            userRepo = new FBUserRepository();
            btnEditarDatos.Clicked += BtnEditarDatos_Clicked;
          
            btnEditarFoto.Clicked += BtnEditarFoto_Clicked;
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

        //private async void BtnEditarFoto_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        //        {
        //            Title = "Seleccione una foto"
        //        });

        //        if (result != null)
        //        {
        //            // Guarda la ruta de la imagen seleccionada en una variable de sesión
        //            filePath = result.FullPath;

        //            // Mostrar la foto en la vista actual
        //            ProfileImage.Source = ImageSource.FromFile(result.FullPath);

        //            // Obtener el usuario actual de la base de datos
        //            var user = await userRepo.GetUserById(SessionData.IdUser);

        //            if (user != null)
        //            {
        //                // Actualizar solo la foto de perfil
        //                user.FotoPerfil = filePath;

        //                // Actualizar el usuario en la base de datos
        //                bool isUpdated = await userRepo.UpdateUser(user);
        //                if (isUpdated)
        //                {
        //                    await DisplayAlert("Success", "Foto de perfil actualizada exitosamente", "OK");
        //                }
        //                else
        //                {
        //                    await DisplayAlert("Error", "No se pudo actualizar la foto de perfil", "OK");
        //                }
        //            }
        //            else
        //            {
        //                await DisplayAlert("Error", "Usuario no encontrado", "OK");
        //            }
        //        }
        //        else
        //        {
        //            await DisplayAlert("Error", "No se ha seleccionado ninguna foto", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Ocurrió un error al seleccionar la foto: {ex.Message}", "OK");
        //    }
        //}

        private async void CargarDatosUsuario()
        {

            var user = await userRepo.GetUserById(SessionData.IdUser);

            if (user != null)
            {
                // Asignar los datos del usuario a los campos de la interfaz

                if (!string.IsNullOrEmpty(user.FotoPerfil))
                {
                    ProfileImage.Source = ImageSource.FromFile(user.FotoPerfil);
                }


            }
            else
            {
                await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
            }
        }


        private async void BtnEditarDatos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarDatos());
        }

        private async void BtnEditarFoto_Clicked(object sender, EventArgs e)
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
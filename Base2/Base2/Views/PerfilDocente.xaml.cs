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
	public partial class PerfilDocente : ContentPage
	{
		public PerfilDocente ()
		{
			InitializeComponent ();
            CargarDatosDocente();
        }

        private async void CargarDatosDocente()
        {
            try
            {
                // Obtén el userId desde la clase SessionData
                var userId = SessionData.IdUser; // Ajusta esto según cómo guardas el ID de usuario

                // Crear una instancia del repositorio de Firebase
                var fbRepository = new FBUserRepository();

                // Obtener los datos del usuario desde Firebase
                var usuario = await fbRepository.GetUserById(userId);

                if (usuario != null)
                {
                    // Asignar los valores a los controles de la interfaz de usuario
                    txtNombre.Text = $"{usuario.FirstName} {usuario.LastName}";
                    txtEmail.Text = usuario.Email;
                    txtFechaNacimiento.Text = usuario.FechaNacimiento.HasValue ? usuario.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "N/A";
                    txtEdad.Text = usuario.Edad.ToString();
                    txtGenero.Text = usuario.Genero;

                    // Si tienes una URL de imagen de perfil en Firebase, puedes cargarla así
                    ProfileImage.Source = usuario.FotoPerfil;
                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al cargar los datos del usuario: {ex.Message}", "OK");
            }
        }
    }
}
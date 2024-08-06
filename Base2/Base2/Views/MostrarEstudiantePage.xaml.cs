using Base2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MostrarEstudiantePage : ContentPage
	{

        private FBUserRepository _userRepo;
        public ICommand PerfilEstudianteCommand { get; }
        public MostrarEstudiantePage()
		{
			InitializeComponent ();
            _userRepo = new FBUserRepository();
            PerfilEstudianteCommand = new Command<Estudiante>(OnPerfilEstudianteClicked);
            BindingContext = this;
            CargarEstudiantes();
            
        }



        private async void OnPerfilEstudianteClicked(Estudiante estudiante)
        {
            if (estudiante != null)
            {
                // Navegar a otra vista o realizar alguna acción con el estudiante seleccionado
                await DisplayAlert("Perfil del Estudiante", $"Estudiante seleccionado: {estudiante.FirstName} {estudiante.LastName}", "Aceptar");
                // Aquí puedes navegar a otra página, por ejemplo:
                await Navigation.PushAsync(new DetalleEstudiantePage(estudiante));
            }
        }

        private async void CargarEstudiantes()
        {
            try
            {
                // Obtener el ID del usuario actual (padre)
                string userId = SessionData.IdUser;

                if (string.IsNullOrEmpty(userId))
                {
                    await DisplayAlert("Error", "No se pudo obtener el ID del usuario.", "Aceptar");
                    return;
                }

                // Obtener la lista de estudiantes asociados a este usuario
                List<Estudiante> estudiantes = await _userRepo.GetEstudiantesByUserId(userId);

                // Asignar una imagen predeterminada si FotoPerfil está vacío o nulo
                foreach (var estudiante in estudiantes)
                {
                    if (string.IsNullOrEmpty(estudiante.FotoPerfil))
                    {
                        estudiante.FotoPerfil = estudiante.Genero == "Masculino"
                                                ? "ImgPerfilNino.jpg"
                                                : "ImgPerfilNina.jpg";
                    }
                }

                // Asignar la lista de estudiantes al CarouselView
                EstudiantesCarousel.ItemsSource = estudiantes;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ingresando a la lista de estudiantes: {ex.Message}", "Aceptar");
            }
        }



        private void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            try
            {
                if (EstudiantesCarousel.ItemsSource is IList<Estudiante> items)
                {
                    foreach (var item in items)
                    {
                        var container = EstudiantesCarousel.FindByName<CarouselView>("EstudiantesCarousel");

                        // Encuentra el Frame correspondiente al ítem actual
                        var frame = (Frame)container?.FindByName("EstudianteFrame");

                        if (frame == null)
                        {
                            Console.WriteLine("Frame no encontrado.");
                            continue;
                        }

                        // Si el item es el central
                        if (item == e.CurrentItem)
                        {
                            // Aumenta la escala del ítem central y lo hace más opaco
                            frame.ScaleTo(1.0, 250, Easing.CubicInOut);
                            frame.Opacity = 1.0; // Totalmente opaco
                        }
                        else
                        {
                            // Disminuye la escala de los ítems laterales y los hace más transparentes
                            frame.ScaleTo(0.8, 250, Easing.CubicInOut);
                            frame.Opacity = 0.5; // Más transparente
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en OnCurrentItemChanged: {ex.Message}");
            }
        }




    }
}
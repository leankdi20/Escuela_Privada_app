using Base2.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlumnosPage : ContentPage
    {
       
        public ObservableCollection<Estudiante> Estudiantes { get; set; }

        public AlumnosPage()
        {
            InitializeComponent();
            Estudiantes = new ObservableCollection<Estudiante>();
            CargarEstudiantes();
            BindingContext = this;
            
        }



        private async void CargarEstudiantes()
        {
            var fbRepository = new FBUserRepository();
            var estudiantes = await fbRepository.GetAllEstudiantes();

            if (estudiantes != null && estudiantes.Any())
            {
                foreach (var estudiante in estudiantes)
                {
                    Estudiantes.Add(estudiante);
                }
            }
            else
            {
                await DisplayAlert("Aviso", "No se encontraron estudiantes.", "OK");
            }
        }


        // Método para obtener un estudiante por su Id
        private async Task<Estudiante> ObtenerEstudiantePorId(string idEstudiante)
        {
            var fbRepository = new FBUserRepository(); // Instancia del repositorio de Firebase
            var estudiante = await fbRepository.GetEstudianteById(idEstudiante); // Obtiene el estudiante por Id
            return estudiante;
        }

        // Evento al hacer clic en el botón "Ver Detalles"
        private async void VerDetalles_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Estudiante estudiante)
            {
                // Navega a la página de detalles, pasando el objeto estudiante seleccionado
                await Navigation.PushAsync(new DetalleEstudiantePage(estudiante));
            }
        }

    }
}
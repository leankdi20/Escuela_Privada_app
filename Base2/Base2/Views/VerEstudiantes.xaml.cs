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
    public partial class VerEstudiantes : ContentPage
    {
        public VerEstudiantes()
        {

            InitializeComponent();
            userRepo = new FBUserRepository();
            LoadEstudiantesAsync();
        }

        private FBUserRepository userRepo;
        private async void LoadEstudiantesAsync()
        {
            try
            {
                var estudiantes = await userRepo.GetAllEstudiantes();
                EstudiantesStackLayout.Children.Clear();

                if (estudiantes != null && estudiantes.Count > 0)
                {
                    foreach (var estudiante in estudiantes)
                    {
                        // Fetch the father's details using the IdUser from the Estudiante record
                        var padre = await userRepo.GetUserById(estudiante.IdUser);

                        var padreName = padre != null ? $"{padre.FirstName} {padre.LastName}" : "Padre desconocido";

                        EstudiantesStackLayout.Children.Add(new Label
                        {
                            Text = $"Estudiante: {estudiante.FirstName} {estudiante.LastName}\n" +
                                   $"Fecha de Nacimiento: {estudiante.FechaNacimiento.ToShortDateString()}\n" +
                                   $"Cédula: {estudiante.Cedula}\n" +
                                   $"Ciudad: {estudiante.City}\n" +
                                   $"Género: {estudiante.Genero}\n" +
                                   $"Padre: {padreName}\n" +
                                   "-----------------------------------------------",
                            TextColor = Color.White,
                            FontSize = 20,
                            Margin = new Thickness(0, 5, 0, 5)
                        });
                    }
                }
                else
                {
                    EstudiantesStackLayout.Children.Add(new Label
                    {
                        Text = "No hay estudiantes disponibles.",
                        TextColor = Color.White,
                        FontSize = 16,
                        Margin = new Thickness(0, 5, 0, 5)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading estudiantes: {ex.Message}");
                await DisplayAlert("Error", "Ocurrió un error al cargar los estudiantes.", "Aceptar");
            }
        }
    }
}

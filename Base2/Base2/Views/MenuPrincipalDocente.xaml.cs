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
            BtnEnviar.Clicked += BtnEnviar_Clicked;



            EntryCorreoTutor.Unfocused += EntryCorreoTutor_Unfocused;

            EnviarATodos.CheckedChanged += EnviarATodos_CheckedChanged;


            // Inicializar userRepo aquí
            userRepo = new FBUserRepository();
        }

        bool isChecked = false;

        private void EnviarATodos_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
         

          

            isChecked = e.Value;
            EntryCorreoTutor.Text = "general@gmail.com";
            PickerEstudiante.SelectedItem = "general";




            EntryCorreoTutor.IsEnabled = !isChecked;
            PickerEstudiante.IsEnabled = !isChecked;

            if (isChecked)
            {
                PickerEstudiante.TextColor = Color.Gray;
                EntryCorreoTutor.TextColor = Color.Gray;
                labelPickerEstudiante.TextColor = Color.Gray;
                LabelCorreoTutor.TextColor = Color.Gray;


            }
            else
            {

               
                    PickerEstudiante.TextColor = Color.White;
                    EntryCorreoTutor.TextColor = Color.White;
                    labelPickerEstudiante.TextColor = Color.White;
                    LabelCorreoTutor.TextColor = Color.White;
                
            }

            


        }

        private async void EntryCorreoTutor_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (!isDataLoaded)
                {
                    string email = EntryCorreoTutor.Text;

                    if (string.IsNullOrEmpty(email))
                    {
                        await DisplayAlert("Error", "El campo de correo electrónico es obligatorio", "Aceptar");
                        EntryCorreoTutor.Focus();
                        return;
                    }

                    var user = await userRepo.GetUserByEmail(email);

                    if (user == null)
                    {
                        await DisplayAlert("Error", "Usuario no encontrado con el correo proporcionado.", "Aceptar");
                        EntryCorreoTutor.Focus();
                        return;
                    }

                    string userId = user.IdUser;
                    await LoadEstudiantesAsync(userId);
                    isDataLoaded = true; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar estudiantes: {ex.Message}");
                await DisplayAlert("Error", $"Ocurrió un error al cargar los estudiantes: {ex.Message}", "OK");
            }
        }


        private async Task LoadEstudiantesAsync(string userId)
        {
            if (!isChecked) { 
            try
            {
                var estudiantes = await userRepo.GetEstudiantesByUserId(userId);

                PickerEstudiante.ItemsSource = null;

                if (estudiantes != null && estudiantes.Count > 0)
                {
                    Console.WriteLine("Estudiantes retrieved:");

                    foreach (var estudiante in estudiantes)
                    {
                        Console.WriteLine($"{estudiante.FirstName} {estudiante.LastName}");
                    }

                    List<string> estudiantesNames = estudiantes.Select(e => $"{e.FirstName} {e.LastName}").ToList();

                    PickerEstudiante.ItemsSource = estudiantesNames;



                }
                else
                {
                    await DisplayAlert("Aviso", "No se encontraron estudiantes asociados al usuario.", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los estudiantes: {ex.Message}");
                await DisplayAlert("Error", $"Ocurrió un error al cargar los estudiantes: {ex.Message}", "OK");
            }

            }

        }

        private void BtnReporte_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (userRepo == null)
                {
                    await DisplayAlert("Error", "El repositorio de usuarios no está inicializado.", "Aceptar");
                    return;
                }

                string email = EntryCorreoTutor.Text;

                if (string.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Error", "El campo de correo electrónico es obligatorio", "Aceptar");
                    EntryCorreoTutor.Focus();
                    return;
                }

                var user = await userRepo.GetUserByEmail(email);

                if (user == null)
                {
                    await DisplayAlert("Error", "Usuario no encontrado con el correo proporcionado.", "Aceptar");
                    EntryCorreoTutor.Focus();
                    return;
                }

                string userId = user.IdUser;

                if (EntryCorreoTutor == null || PickerEstudiante == null || PickerTipoAviso == null || EntryMensaje == null)
                {
                    await DisplayAlert("Error", "Uno o más campos de entrada no están inicializados.", "Aceptar");
                    return;
                }

                string selectedTipoAviso = PickerTipoAviso.SelectedItem?.ToString();
                string selectedEstudianteName = PickerEstudiante.SelectedItem?.ToString();

                var estudiantes = await userRepo.GetEstudiantesByUserId(userId);
                var selectedEstudiante = estudiantes?.FirstOrDefault(est => $"{est.FirstName} {est.LastName}" == selectedEstudianteName);
                string selectedEstudianteId = selectedEstudiante?.IdEstudiante;

                if (string.IsNullOrEmpty(EntryCorreoTutor.Text) ||
                    PickerEstudiante.SelectedItem == null ||
                    string.IsNullOrEmpty(EntryMensaje.Text) ||
                    PickerTipoAviso.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Todos los campos son obligatorios", "Aceptar");
                    EntryCorreoTutor.Focus();
                    return;
                }

                Console.WriteLine("Intentando guardar el aviso con los siguientes datos:");
                Console.WriteLine($"Correo Tutor: {EntryCorreoTutor.Text}");
                Console.WriteLine($"Estudiante: {selectedEstudianteName}");
                Console.WriteLine($"Tipo Aviso: {selectedTipoAviso}");
                Console.WriteLine($"IdUser: {SessionDataAviso.IdAviso}");

                var nuevoAviso = new Aviso
                {
                    TipoAviso = selectedTipoAviso,
                    FechaEnvio = DateTime.Now,
                    Mensaje = EntryMensaje.Text,
                    IdUser = userId,
                    IdAviso = SessionDataAviso.IdAviso,
                    IdEstudiante = selectedEstudianteId 
                };

                bool guardado = await userRepo.SaveAviso(nuevoAviso);
                if (guardado)
                {
                    await DisplayAlert("Aviso", "Aviso guardado correctamente", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Aviso", "Error al guardar el aviso", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Type: {ex.GetType().Name}");
                Console.WriteLine($"Error Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                await DisplayAlert("Error", $"Ocurrió un error al guardar el aviso: {ex.Message}", "OK");
            }
        }


    }

}
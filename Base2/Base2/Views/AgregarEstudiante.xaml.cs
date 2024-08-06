using Base2.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.GIFBitmap;




namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarEstudiante : ContentPage
    {
        private string filePath;
        private FBUserRepository userRepo;
        public AgregarEstudiante()
        {
            InitializeComponent();

            // Inicializar userRepo aquí
            userRepo = new FBUserRepository();


            btnGuardarEstudiante.Clicked += BtnGuardarEstudiante_Clicked;
           
            
        }

        //Guardamos la foto


        private async void BtnGuardarEstudiante_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que SessionData.IdUser no sea nulo o vacío
                if (string.IsNullOrEmpty(SessionData.IdUser))
                {
                    await DisplayAlert("Error", "El ID de usuario no está inicializado.", "Aceptar");
                    return;
                }

                if (userRepo == null)
                {
                    await DisplayAlert("Error", "El repositorio de usuarios no está inicializado.", "Aceptar");
                    return;
                }

                // Comprobación de inicialización de componentes de la interfaz de usuario
                if (txtFirstName == null || pickerGender == null || txtLastName == null ||
                    txtAddress == null || txtCity == null || txtCedula == null ||
                    txtEnfermedad == null || txtNombreMedicina == null || txtDescripcion == null ||
                    txtAlergia == null)
                {
                    await DisplayAlert("Error", "Uno o más campos de entrada no están inicializados.", "Aceptar");
                    return;
                }

                // Validamos los campos
                if (string.IsNullOrEmpty(txtFirstName.Text) ||
                    string.IsNullOrEmpty(txtLastName.Text) ||
                    string.IsNullOrEmpty(txtAddress.Text) ||
                    string.IsNullOrEmpty(txtCity.Text) ||
                    string.IsNullOrEmpty(txtCedula.Text) ||
                    string.IsNullOrEmpty(txtEnfermedad.Text) ||
                    string.IsNullOrEmpty(txtNombreMedicina.Text) ||
                    string.IsNullOrEmpty(txtDescripcion.Text) ||
                    string.IsNullOrEmpty(txtAlergia.Text) ||
                    pickerGender.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Todos los campos son obligatorios", "Aceptar");
                    txtFirstName.Focus();
                    return;
                }

                // Asignar imagen de perfil basada en el género
                string selectedGender = pickerGender.SelectedItem.ToString();
                if (selectedGender == "Niña")
                {
                    filePath = "ImgPerfilNiña.jpg";
                }
                else if (selectedGender == "Niño")
                {
                    filePath = "ImgPerfilNiño.jpg";
                }
                else
                {
                    filePath = string.Empty; // O alguna imagen predeterminada si es necesario.
                }

                // Debugging: muestra los valores que estás intentando guardar
                Console.WriteLine("Intentando guardar el estudiante con los siguientes datos:");
                Console.WriteLine($"Nombre: {txtFirstName.Text}");
                Console.WriteLine($"Apellido: {txtLastName.Text}");
                Console.WriteLine($"Fecha de Nacimiento: {datePickerDOB.Date}");
                Console.WriteLine($"Cédula: {txtCedula.Text}");
                Console.WriteLine($"Dirección: {txtAddress.Text}");
                Console.WriteLine($"Ciudad: {txtCity.Text}");
                Console.WriteLine($"Género: {selectedGender}");
                Console.WriteLine($"FotoPerfil: {filePath}");
                Console.WriteLine($"Enfermedad: {txtEnfermedad.Text}");
                Console.WriteLine($"Nombre de Medicina: {txtNombreMedicina.Text}");
                Console.WriteLine($"Descripción: {txtDescripcion.Text}");
                Console.WriteLine($"Alergia: {txtAlergia.Text}");
                Console.WriteLine($"IdUser: {SessionData.IdUser}");

                // Creamos el objeto estudiante
                var nuevoEstudiante = new Estudiante
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    FechaNacimiento = datePickerDOB.Date,
                    Cedula = txtCedula.Text,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    Genero = selectedGender,
                    FotoPerfil = filePath,
                    Enfermedad = txtEnfermedad.Text,
                    NombreMedicina = txtNombreMedicina.Text,
                    Descripcion = txtDescripcion.Text,
                    Alergia = txtAlergia.Text,
                    IdUser = SessionData.IdUser // Mantener como string
                };

                // Guardamos el estudiante en la bd
                bool guardado = await userRepo.SaveEstudiante(nuevoEstudiante);
                if (guardado)
                {
                    await DisplayAlert("Estudiante", "Estudiante guardado correctamente", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Estudiante", "Error al guardar el estudiante", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Type: {ex.GetType().Name}");
                Console.WriteLine($"Error Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                await DisplayAlert("Error", $"Ocurrió un error al guardar el estudiante: {ex.Message}", "OK");
            }
        }
    }
}

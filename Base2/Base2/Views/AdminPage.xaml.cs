using Base2.models;
using Firebase.Auth.Repository;
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
	public partial class AdminPage : ContentPage
	{

        private FBUserRepository _userRepository;
        public AdminPage()
        {
            InitializeComponent();
            _userRepository = new FBUserRepository();
            ShowViewCommand = new Command<string>(ShowView);
            ToggleMenuCommand = new Command(ToggleMenu);
            
            btnCrearAdmin.Clicked += BtnCrearAdmin_Clicked;
            btnCrearTutor.Clicked += BtnCrearTutor_Clicked;
            btnCrearDocente.Clicked += BtnCrearDocente_Clicked;
            btnCrearNotificacion.Clicked += BtnCrearNotificacion_Clicked;
            btnCerrar.Clicked += BtnCerrar_Clicked; 
            BindingContext = this;
            
        }

        private async void BtnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void BtnCrearNotificacion_Clicked(object sender, EventArgs e)
        {
            var nuevaNotificacion = new Notificacion
            {
                Titulo = Titulo.Text,
                Mensaje = Mensaje.Text,
                Fecha = FechaEnvio.Date,
                Leida = false
            };

            var result = await _userRepository.SaveNotificacion(nuevaNotificacion);
            if (result)
            {

                await DisplayAlert("Éxito", "Notificación guardada exitosamente", "OK");
                Titulo.Text = "";
                Mensaje.Text = "";
                

            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar la notificación", "OK");
            }
        }

        private async void BtnCrearDocente_Clicked(object sender, EventArgs e)
        {
            string FirstName = txtFirstNameDocente.Text;
            string LastName = txtLastNameDocente.Text;
            string Email = txtEmailDocente.Text;
            string Password = txtPasswordDocente.Text;
            string Phone = txtTelefonoDocente.Text;
            string Address = txtDireccionDocente.Text;
            string City = txtCityDocente.Text;
            DateTime BirthDate = datePickerDocente.Date;
            string Gender = pickerGenderDocente.SelectedItem?.ToString();

            // Validación de campos
            if (string.IsNullOrEmpty(FirstName) ||
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(Phone) ||
                string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(City) ||
                string.IsNullOrEmpty(Gender))
            {
                await DisplayAlert("Registro", "Por favor llene todos los campos", "OK");
                return;
            }

            if (Password.Length < 6)
            {
                await DisplayAlert("Registro", "La contraseña debe tener al menos 6 caracteres", "OK");
                return;
            }

            if (!Email.Contains("@"))
            {
                await DisplayAlert("Registro", "Correo no válido", "OK");
                return;
            }

            // Calcular la edad
            int age = CalculateAge(BirthDate);

            // Determinar la imagen de perfil según el género
            string profileImage = Gender == "Male" ? "ImgPerfilHombre.jpg" : "ImgPerfilMujer.png";

            // Todos los campos están llenos y válidos, guardar en la base de datos
            try
            {
                var newUser = new Usuario
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,
                    Phone = Phone,
                    Address = Address,
                    City = City,
                    Genero = Gender,
                    FechaNacimiento = BirthDate,
                    Edad = age,
                    FotoPerfil = profileImage,
                    IdRol = 3 
                };

                bool isSaved = await _userRepository.Save(newUser);
                if (isSaved)
                {
                    await DisplayAlert("Success", "User registered successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "User registration failed", "OK");
                }
                await Navigation.PushAsync(new AdminPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error: " + ex.Message, "OK");
            }
        }

        private async void BtnCrearTutor_Clicked(object sender, EventArgs e)
        {
            string FirstName = txtFirstNameTutor.Text;
            string LastName = txtLastNameTutor.Text;
            string Email = txtEmailTutor.Text;
            string Password = txtPasswordTutor.Text;
            string Phone = txtTelefonoTutor.Text;
            string Address = txtDireccionTutor.Text;
            string City = txtCityTutor.Text;
            DateTime BirthDate = datePickerDOB.Date;
            string Gender = pickerGenderTutor.SelectedItem?.ToString();

            // Validación de campos
            if (string.IsNullOrEmpty(FirstName) ||
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(Phone) ||
                string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(City) ||
                string.IsNullOrEmpty(Gender))
            {
                await DisplayAlert("Registro", "Por favor llene todos los campos", "OK");
                return;
            }

            if (Password.Length < 6)
            {
                await DisplayAlert("Registro", "La contraseña debe tener al menos 6 caracteres", "OK");
                return;
            }

            if (!Email.Contains("@"))
            {
                await DisplayAlert("Registro", "Correo no válido", "OK");
                return;
            }

            // Calcular la edad
            int age = CalculateAge(BirthDate);

            // Determinar la imagen de perfil según el género
            string profileImage = Gender == "Male" ? "ImgPerfilHombre.jpg" : "ImgPerfilMujer.png";

            // Todos los campos están llenos y válidos, guardar en la base de datos
            try
            {
                var newUser = new Usuario
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password,
                    Phone = Phone,
                    Address = Address,
                    City = City,
                    Genero = Gender,
                    FechaNacimiento = BirthDate,
                    Edad = age,
                    FotoPerfil = profileImage, 
                    IdRol = 2 // Asigna el ID del rol "Padre"
                };

                bool isSaved = await _userRepository.Save(newUser);
                if (isSaved)
                {
                    await DisplayAlert("Success", "User registered successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "User registration failed", "OK");
                }
                await Navigation.PushAsync(new AdminPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error: " + ex.Message, "OK");
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }



        private async void BtnCrearAdmin_Clicked(object sender, EventArgs e)
        {
            string FirstName = txtFirstName.Text;
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            string Gender = pickerGender.SelectedItem?.ToString();


            // Validación de campos
            if (string.IsNullOrEmpty(FirstName) ||
              
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Gender) ||
                string.IsNullOrEmpty(Password))

            {
                await DisplayAlert("Registro", "Por favor llene todos los campos", "OK");
                return;
            }

            if (Password.Length < 6)
            {
                await DisplayAlert("Registro", "La contraseña debe tener al menos 6 caracteres", "OK");
                return;
            }

            if (!Email.Contains("@"))
            {
                await DisplayAlert("Registro", "Correo no válido", "OK");
                return;
            }



            // Todos los campos están llenos y válidos, guardar en la base de datos
            try
            {
                var newUser = new Usuario
                {
                    FirstName = FirstName,
                    Email = Email,
                    Password = Password,
                    Genero = Gender,
                    IdRol = 1// Asigna el ID del rol "Admin"
                };

                bool isSaved = await _userRepository.Save(newUser);
                if (isSaved)
                {
                    await DisplayAlert("Success", "User registered successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "User registration failed", "OK");
                }
                await Navigation.PushAsync(new AdminPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error: " + ex.Message, "OK");
            }
        }






        public Command<string> ShowViewCommand { get; }
        public Command ToggleMenuCommand { get; }


        private void ShowView(string viewName)
        {
            // Ocultar todas las vistas
            Role1View.IsVisible = false;
            Role2View.IsVisible = false;
            Role3View.IsVisible = false;
            NotificationView.IsVisible = false;

            // Mostrar la vista seleccionada
            switch (viewName)
            {
                case "Role1View":
                    Role1View.IsVisible = true;
                    break;
                case "Role2View":
                    Role2View.IsVisible = true;
                    break;
                case "Role3View":
                    Role3View.IsVisible = true;
                    break;
                case "NotificationView":
                    NotificationView.IsVisible = true;
                    break;
            }
        }
        private void ToggleMenu()
        {
            // Alterna la visibilidad del menú
            MenuStackLayout.IsVisible = !MenuStackLayout.IsVisible;
        }

    }
}
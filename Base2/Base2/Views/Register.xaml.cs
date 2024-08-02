using Base2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private FBUserRepository _userRepository;
        public Register()
        {
            InitializeComponent();
            btnRegister.Clicked += BtnRegister_Clicked;
            btnLogin.Clicked += BtnLogin_Clicked;
            _userRepository = new FBUserRepository();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string Email = txtEmail.Text;
            string Password = txtPassword.Text;
            string Phone = txtPhone.Text;
            string Address = txtAddress.Text;
            string City = txtCity.Text;
            DateTime BirthDate = datePickerDOB.Date;
            string Gender = pickerGender.SelectedItem?.ToString();

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
                    FotoPerfil = string.Empty,
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
                await Navigation.PushAsync(new Login());
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
    }
}
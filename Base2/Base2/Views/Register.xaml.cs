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
        public Register()
        {
            InitializeComponent();
            btnRegister.Clicked += BtnRegister_Clicked;
            btnLogin.Clicked += BtnLogin_Clicked;
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

            // Validación de campos
            if (string.IsNullOrEmpty(FirstName) ||
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(Phone) ||
                string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(City))
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
                UserRepository.Instancia.AddNewUser(FirstName, LastName, Email, Password, Phone, Address, City);

                await DisplayAlert("Registro", "Registro Exitoso", "OK");

                // Limpiar campos
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";

                // Navegar a la página de inicio de sesión
                await Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error: " + ex.Message, "OK");
            }
        }
    }
}
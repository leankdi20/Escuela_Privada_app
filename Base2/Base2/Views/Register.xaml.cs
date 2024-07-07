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
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Registro", "Por favor llene todos los campos", "OK");
                return;
            }
            if (password.Length < 6)
            {
                await DisplayAlert("Registro", "La contraseña debe tener al menos 6 caracteres", "OK");
                return;
            }
            if (!email.Contains("@"))
            {
                await DisplayAlert("Registro", "Correo no valido", "OK");
                return;
            }
            if (!string.IsNullOrEmpty(firstName) &&
                !string.IsNullOrEmpty(lastName) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(password))
            {
                // Todos los campos están llenos, guardar en el arreglo
                string[] userInfo = { firstName, lastName, email, password };

                // Aquí puedes agregar la lógica adicional, como guardar el arreglo en una base de datos o llamar a un servicio web

                DisplayAlert("Registro", "Registro Exitoso", "OK");
                txtEmail.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPassword.Text = "";
                Navigation.PushAsync(new Login());

                // Navegar a otra página si es necesario
                // await Navigation.PushAsync(new SomeOtherPage());
            }
            await DisplayAlert("Registro", "Registro Exitoso", "OK");
        }
    }
}
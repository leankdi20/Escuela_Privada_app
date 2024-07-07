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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegistrar.Clicked += BtnRegistrar_Clicked;

        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string User = txtUser.Text;
            string Pass = txtPass.Text;


            if (Pass == "L123" && User == "Leandro@mail.com")
            {
                string Welcome = $"Bienvenido {User}";
                await DisplayAlert(Welcome, "Login Success", "OK");
                txtUser.Text = "";
                txtPass.Text= "";
                await Navigation.PushAsync(new MenuPrincipal());
            }
            else
            {
                DisplayAlert("Login", "Login Failed", "OK");
            }
        }
    }
}
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
        private List<LogIn> log;
        public Login()
        {
            InitializeComponent();
            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegistrar.Clicked += BtnRegistrar_Clicked;

            //defino login quemado de prueba

            log = new List<LogIn>
            {
                new LogIn { Name = "Leandro", Email = "leandro@mail.com", Password = "L123" },
            };

        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string email = txtUser.Text;
            string Pass = txtPass.Text;
     

            var user = log.FirstOrDefault(u => u.Email == email && u.Password == Pass);

            if (user != null)
            {
                string Welcome = $"Bienvenido {user.Name}";
                await DisplayAlert(Welcome, "Login Success", "OK");
                txtUser.Text = "";
                txtPass.Text = "";
                await Navigation.PushAsync(new MenuPrincipal(user.Name));
            }
            else
            {
                await DisplayAlert("Login", "Login Failed", "OK");
            }

        }
    }
}
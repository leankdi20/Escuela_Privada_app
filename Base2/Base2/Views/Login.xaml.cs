using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base2.models;
using Base2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

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
            btnMostrarUser.Clicked += BtnMostrarUser_Clicked;



        }

        private void BtnMostrarUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MostrarUsuarios());
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string email = txtUser.Text;
            string Pass = txtPass.Text;
     
            var user =  UserRepository.Instancia.GetUserByEmailAndPassword(email, Pass);
           

            if (user != null)
            {
                string Welcome = $"Bienvenido {user.FirstName}";
                await DisplayAlert(Welcome, "Login Success", "OK");
                txtUser.Text = "";
                txtPass.Text = "";
                await Navigation.PushAsync(new MenuPrincipal(user.FirstName, user.Email));
            }
            else
            {
                await DisplayAlert("Login", "Login Failed", "OK");
            }

        }
      

    }
}
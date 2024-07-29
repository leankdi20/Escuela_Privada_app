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
using System.Linq.Expressions;


namespace Base2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

   
    public partial class Login : ContentPage
    {
        private List<LogIn> log;
        private FBUserRepository userRepo;
        public Login()
        {
            InitializeComponent();
            userRepo = new FBUserRepository();
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
            string email = txtemail.Text;
            string Pass = txtPass.Text;
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Pass))
                {
                    await DisplayAlert("Login", "Please enter both email and password", "OK");
                    return;
                }

                var user = await userRepo.AuthenticateUser(email, Pass);

                if (user != null)
                {
                    string welcomeMessage = $"Bienvenido {user.FirstName}";
                    await DisplayAlert("Login Success", welcomeMessage, "OK");

                    // Limpiar los campos de texto
                    txtemail.Text = "";
                    txtPass.Text = "";

                    SessionData.UserName = user.FirstName;
                    SessionData.Email = user.Email;

                    // Llevar al menú principal
                    await Navigation.PushAsync(new MenuPrincipal());
                }
                else
                {
                    await DisplayAlert("Login", "Login Failed", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login", ex.Message, "OK");
            }
        }
    }
}
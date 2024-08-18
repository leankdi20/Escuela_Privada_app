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

                Console.WriteLine($"Intentando autenticar usuario: {email}");
                var user = await userRepo.AuthenticateUser(email, Pass);

                if (user != null)
                {
                    Console.WriteLine($"Usuario autenticado: {user.FirstName}, Rol: {user.IdRol}");
                    string welcomeMessage = $"Bienvenido {user.FirstName}";
                    await DisplayAlert("Login Success", welcomeMessage, "OK");

                    // Limpiar los campos de texto
                    txtemail.Text = "";
                    txtPass.Text = "";

                    // Guardar datos en SessionData
                    SessionData.IdUser = user.IdUser;
                    SessionData.UserName = user.FirstName;
                    SessionData.Email = user.Email;
                    SessionData.Genero = user.Genero;
                    SessionData.Phone = user.Phone;
                    SessionData.Address = user.Address;
                    SessionData.City = user.City;
                    SessionData.FotoPerfil = user.FotoPerfil;
                    SessionData.FechaNacimiento = user.FechaNacimiento;
                    SessionData.Edad = user.Edad;

                    // Verificar el rol del usuario y navegar a la vista correspondiente
                    if (user.IdRol == 1)
                    {
                        // Navegar a una vista específica para usuarios con IdRol == 1
                        await Navigation.PushAsync(new AdminPage());
                        Console.WriteLine("Navegando a AdminView");
                    }
                    else if (user.IdRol == 2)
                    {
                        // Navegar al menú principal
                        await Navigation.PushAsync(new MenuPrincipal());
                        Console.WriteLine("Navegando a MenuPrincipal");
                    }
                    else if (user.IdRol == 3)
                    {
                        // Navegar a una vista específica para usuarios con IdRol == 3
                        await Navigation.PushAsync(new MenuPrincipalDocente());
                        Console.WriteLine("Navegando a TeacherView");
                    }
                    else
                    {
                        await DisplayAlert("Login", "Usuario no encontrado", "OK");
                    }
                }
                else
                {
                    Console.WriteLine("Login Failed: Usuario no encontrado.");
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
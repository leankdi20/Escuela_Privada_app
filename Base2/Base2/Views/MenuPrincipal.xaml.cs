using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base2.models;
using Base2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; }
        public Usuario usuario { get; set; }
        private FBUserRepository userRepo;

        public MenuPrincipal()
        {
            InitializeComponent();
            userRepo = new FBUserRepository();
            CargarDatosUsuario();
            //Email = email;
            
           


            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { ImageSource = "escuela1.jpg", Title = "Escuela Frente" },
                new CarouselItem { ImageSource = "escuela2.jpeg", Title = "Escuela parque" },
                new CarouselItem { ImageSource = "escuela3.jpeg", Title = "Escuela Sport" }
            };

            BindingContext = this;

            btnAdd.Clicked += BtnAdd_Clicked;
            BtnNotificaciones.Clicked += BtnNotificaciones_Clicked;
           // btnAnuncio.Clicked += BtnAnuncio_Clicked;

        }

        async void BtnNotificaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AvisosPadre());
        }

        private async void BtnAnuncio_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Anuncio", "Anuncio de la escuela", "OK");
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarEstudiante());
        }


        private async void CargarDatosUsuario()
        {
            try
            {
                var user = await userRepo.GetUserById(SessionData.IdUser);

                if (user != null)
                {
                    // Asignar los datos del usuario a las etiquetas
                    
                    lblname.Text = "¡Bienvenido " + user.FirstName + "!" ?? string.Empty;

                }
                else
                {
                    await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al cargar los datos: {ex.Message}\nDetalles: {ex.StackTrace}", "OK");
            }
        }

    }
}
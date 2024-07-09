using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; }
        public MenuPrincipal(string name)
        {
            InitializeComponent();
            lblname.Text = "¡Bienvenido " + name + "!";

            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { ImageSource = "escuela1.jpg", Title = "Escuela Frente" },
                new CarouselItem { ImageSource = "escuela2.jpeg", Title = "Escuela parque" },
                new CarouselItem { ImageSource = "escuela3.jpeg", Title = "Escuela Sport" }
            };

            BindingContext = this;

            btnAdd.Clicked += BtnAdd_Clicked;
            btnAnuncio.Clicked += BtnAnuncio_Clicked;

            btnHome.Clicked += BtnHome_Clicked;
            btnEstudiante.Clicked += BtnEstudiante_Clicked;
            btnNovedades.Clicked += BtnNovedades_Clicked;
            btnPerfil.Clicked += BtnPerfil_Clicked;


            
        }

        private async void BtnAnuncio_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Anuncio", "Anuncio de la escuela", "OK");
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Agregar", "Agregar estudiante", "OK");
        }

        private async void BtnPerfil_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Perfil", "Perfil del usuario", "OK");
        }

        private async void BtnNovedades_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Novedades", "Novedades de la escuela", "OK");
        }

        private async void BtnEstudiante_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Estudiante", "Información del estudiante", "OK");
        }

        private async void BtnHome_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Home", "Página principal", "OK");
        }
    }
}
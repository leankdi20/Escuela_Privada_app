using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base2.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; }
        public Usuario usuario { get; set; }
        string firstname;
        string Email;
        public MenuPrincipal(string name, string email)
        {
            InitializeComponent();

            firstname = name;
            Email = email;
            lblname.Text = "¡Bienvenido " + firstname + "!";
           


            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { ImageSource = "escuela1.jpg", Title = "Escuela Frente" },
                new CarouselItem { ImageSource = "escuela2.jpeg", Title = "Escuela parque" },
                new CarouselItem { ImageSource = "escuela3.jpeg", Title = "Escuela Sport" }
            };

            BindingContext = this;

            btnAdd.Clicked += BtnAdd_Clicked;
            btnAnuncio.Clicked += BtnAnuncio_Clicked;

        }

        private async void BtnAnuncio_Clicked(object sender, EventArgs e)
        {
           await DisplayAlert("Anuncio", "Anuncio de la escuela", "OK");
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Agregar", "Agregar estudiante", "OK");
        }

      
    }
}
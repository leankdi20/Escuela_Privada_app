using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base2.models;
using Base2.Views;
using Firebase.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfesorMenuPrincipal : ContentPage
    {
        public ProfesorMenuPrincipal()
        {
            InitializeComponent();
            BtnReporte.Clicked += BtnReporte_Clicked;
            BtnAviso.Clicked += BtnAviso_Clicked;


        }
        public Usuario usuario { get; set; }
        private FBUserRepository userRepo;
        async void BtnAviso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPrincipalDocente());
        }

        async void BtnReporte_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerEstudiantes());
        }

      

    }


}

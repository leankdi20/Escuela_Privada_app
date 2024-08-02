using Base2.models;
using Base2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Perfil : ContentPage
	{
		public Perfil ()
		{
			InitializeComponent ();
            lblName.Text = SessionData.UserName;
            lblEmail.Text = SessionData.Email;
            btnInfoPersonal.Clicked += BtnInfoPersonal_Clicked;
            btnNotificaciones.Clicked += BtnNotificaciones_Clicked;
            btnCerrar.Clicked += BtnCerrar_Clicked;
		}

        private void BtnCerrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private async void BtnNotificaciones_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Notificaciones", "Notificaciones de la escuela", "OK");
        }

        private async void BtnInfoPersonal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InformacionPersonal());
            //await DisplayAlert("Info Personal", "Notificaciones de la escuela", "OK");
        }
    }
}
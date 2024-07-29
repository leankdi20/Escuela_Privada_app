using Base2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionPersonal : ContentPage
    {
        public InformacionPersonal()
        {
            InitializeComponent();

            txtNombre.Text = SessionData.UserName;
            txtEmail.Text = SessionData.Email;
        }

        private async void OnProfileSettingsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Profile Settings", "Navigate to profile settings", "OK");
        }

        private async void OnPrivacyClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Privacy", "Navigate to privacy settings", "OK");
        }

        private async void OnNotificationsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Notifications", "Navigate to notification settings", "OK");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Base2.models;


namespace Base2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MostrarUsuarios : ContentPage
	{
		public MostrarUsuarios ()
		{
			InitializeComponent ();
            LoadUsers();
            

        }

        private void LoadUsers()
        {
            try
            {
               // IEnumerable<Usuario> users = UserRepository.Instancia.GetAllUsers();
               //  UserListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error al cargar los datos: " + ex.Message, "OK");
            }
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedUser = e.SelectedItem as Usuario;
                DisplayAlert("Usuario Seleccionado", $"{selectedUser.FirstName} {selectedUser.LastName}", "OK");
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
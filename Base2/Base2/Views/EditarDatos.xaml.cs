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
    public partial class EditarDatos : TabbedPage
    {

        private FBUserRepository userRepo;
        private string filePath;

        public EditarDatos()
        {
            InitializeComponent();
            userRepo = new FBUserRepository();

            CargarDatosUsuario();
            btnGuardarCambios.Clicked += BtnGuardarCambios_Clicked;
            lblID.Text = SessionData.IdUser;
        }





        private async void BtnGuardarCambios_Clicked(object sender, EventArgs e)
        {

            string userId = lblID.Text;  // Obtiene el ID mostrado en la vista
            Console.WriteLine($"ID del usuario desde la vista: {userId}");

            var user = await userRepo.GetUserById(SessionData.IdUser);
            if (user != null)
            {
                Console.WriteLine($"ID del usuario después de obtenerlo: {user.IdUser}");

                // Verifica el ID antes de actualizar
                user.IdUser = SessionData.IdUser;  // Asegura que el ID se mantenga

                Console.WriteLine($"ID del usuario antes de la actualización: {user.IdUser}");


                //  Asegurar de que el ID se mantiene intacto
                //user.IdUser = userId;
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.Email = txtEmail.Text;
                user.Phone = txtPhone.Text;
                user.Address = txtAddress.Text;
                user.City = txtCity.Text;
                user.FechaNacimiento = datePickerDOB.Date;
                user.Edad = int.Parse(txtEdad.Text);
                user.Genero = pickerGender.SelectedItem.ToString();
                


                bool isUpdated = await userRepo.UpdateUser(user);
                if (isUpdated)
                {
                    await DisplayAlert("Success", "Datos actualizados correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Error al actualizar los datos", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
            }
        }

        private async void CargarDatosUsuario()
        {
            
            var user = await userRepo.GetUserById(SessionData.IdUser);

            if (user != null)
            {
                // Asignar los datos del usuario a los campos de la interfaz
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtAddress.Text = user.Address;
                txtCity.Text = user.City;
                datePickerDOB.Date = user.FechaNacimiento ?? DateTime.Today;
                txtEdad.Text = user.Edad.ToString();
                pickerGender.SelectedItem = user.Genero;


            }
            else
            {
                await DisplayAlert("Error", "No se pudieron cargar los datos del usuario.", "OK");
            }
        }





    }
}
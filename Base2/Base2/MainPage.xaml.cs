using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Base2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btn_ok.Clicked += Btn_ok_Clicked;
        }

        private void Btn_ok_Clicked(object sender, EventArgs e)
        {
            lbl03.Text = "Leandro Emanuel Varela";

            lbl01.Text = "Hola" + txt_01.Text;

            valores.Text = dp.Date.ToString() + "" + SValor.Value + "";


            if (rbCafe.IsChecked) valores.Text = "Bebida Cafe";

            if (rbChocolate.IsChecked) valores.Text = "Bebida Chocolate";

            if (rbAg.IsChecked) valores.Text = "Bebida Agua";



        }
    }
}

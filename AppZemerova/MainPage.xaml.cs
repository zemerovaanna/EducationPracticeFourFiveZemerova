using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppZemerova
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (name.Text != "" && name.Text != null)
            {
                if (password.Text != "" && password.Text != null)
                {
                    if(name.Text != "" && password.Text != "")
                    {
                        Navigation.PushAsync(new Calculator(name.Text));
                    }
                }
            }
        }
    }
}
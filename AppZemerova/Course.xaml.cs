using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppZemerova
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Course :ContentPage
    {
        public Course ()
        {
            InitializeComponent( );
        }

        private void USDChanged (object sender, TextChangedEventArgs e)
        {
            bool good = false;
            foreach (char c in usdEntry.Text)
            {
                if (!char.IsDigit(c))
                {
                    good = false;
                    break;
                }
                else
                {
                    good = true;
                }
            }

            if ( usdEntry.Text != "" && good == true)
            {
                eurLabel.Text = (double.Parse(usdEntry.Text) * 1.075).ToString( );
            }
        }
    }
}
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
    public partial class Calculator : ContentPage
    {
        public Calculator(string name)
        {
            InitializeComponent();

            if (name != "" || name != null)
            {
                txtwelcome.Text = $"{name}";
            }
            else
            {
                txtwelcome.Text = $"Welcome!!!";
            }

        }

        private void ButtonCourseClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Course());
        }

        private void SliderValue(object sender, ValueChangedEventArgs e)
        {
            bool good = false;
            foreach (char c in EntryLoanAmount.Text)
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

            if (good == true)
            {

                LabelSlider.Text = $"{Slider.Value}%";
                if (EntryLoanAmount.Text != "" && EntryTermMonth.Text != "" && int.Parse(EntryLoanAmount.Text) != 0)
                {
                    if (PickerPayment.SelectedIndex != -1)
                    {
                        Calculation(EntryLoanAmount.Text, EntryTermMonth.Text, PickerPayment.SelectedIndex, Slider.Value);
                    }
                    else
                    {
                        PickerPayment.SelectedIndex = 1;
                    }
                }
                else
                {
                    LabelEveryMonthPay.Text = "Ежемесячный платеж: ...";
                    LabelTotalAmount.Text = "Общая сумма: ...";
                    LabelOverpayment.Text = "Переплата: ...";
                }
            }
        }


        private void Calculation(string EntryLoanAmount, string EntryTermMonth, int PickerPayment, double Slider)
        {
            bool good = false;
            foreach (char c in EntryTermMonth)
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

            bool good2 = false;
            foreach (char c in EntryLoanAmount)
            {
                if (!char.IsDigit(c))
                {
                    good2 = false;
                    break;
                }
                else
                {
                    good2 = true;
                }
            }
            if (good == true && good2 == true)
            {

                if (Convert.ToDouble(EntryTermMonth) != 0 && Convert.ToDouble(EntryLoanAmount) != 0)
                {
                    switch (PickerPayment)
                    {
                        case 0:
                            {
                                double EveryMonthPay = (Convert.ToDouble(EntryLoanAmount) + Convert.ToDouble(EntryLoanAmount) * Slider / 100) / Convert.ToDouble(EntryTermMonth);
                                LabelEveryMonthPay.Text = $"Ежемесячный платеж: {((Convert.ToDouble(EntryLoanAmount) + Convert.ToDouble(EntryLoanAmount) * Slider / 100) / Convert.ToDouble(EntryTermMonth))}";
                                LabelTotalAmount.Text = $"Общая сумма: {EveryMonthPay * Convert.ToDouble(EntryTermMonth)}";
                                LabelOverpayment.Text = $"Переплата: {Convert.ToDouble(EntryLoanAmount) - Convert.ToDouble(EntryTermMonth)}";
                            }
                            break;
                        case 1:
                            {
                                double EveryMonthPay = Convert.ToDouble(EntryLoanAmount) * (Slider + (Slider / (Math.Pow((1 + Slider), (Convert.ToDouble(EntryTermMonth)) - 1))));
                                LabelEveryMonthPay.Text = $"Ежемесячный платеж: {Math.Round(EveryMonthPay, 2)}";
                                LabelTotalAmount.Text = $"Общая сумма: {Math.Round(EveryMonthPay * (Convert.ToDouble(EntryTermMonth)), 2)}";
                                LabelOverpayment.Text = $"Переплата: {Convert.ToDouble(EntryLoanAmount) - Convert.ToDouble(EntryTermMonth)}";
                            }
                            break;
                        default:
                            {
                                LabelEveryMonthPay.Text = "Ежемесячный платеж:...";
                                LabelTotalAmount.Text = "Общая сумма:...";
                                LabelOverpayment.Text = "Переплата:...";
                            }
                            break;
                    }
                }
                else
                {
                    LabelEveryMonthPay.Text = "Ежемесячный платеж:Oшибка";
                    LabelTotalAmount.Text = "Общая сумма:Oшибка";
                    LabelOverpayment.Text = "Переплата:Oшибка";
                }
            }
            else
            {
                LabelEveryMonthPay.Text = "Ежемесячный платеж:Oшибка";
                LabelTotalAmount.Text = "Общая сумма:Oшибка";
                LabelOverpayment.Text = "Переплата:Oшибка";
            }
        }

        private void PickerPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool good = false;
            foreach (char c in EntryLoanAmount.Text)
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

            if (good == true)
            {
                LabelSlider.Text = $"{Slider.Value}%";
                if (EntryLoanAmount.Text != "" && EntryTermMonth.Text != "" && int.Parse(EntryLoanAmount.Text) != 0)
                {
                    if (PickerPayment.SelectedIndex != -1)
                    {
                        Calculation(EntryLoanAmount.Text, EntryTermMonth.Text, PickerPayment.SelectedIndex, Slider.Value);
                    }
                    else
                    {
                        PickerPayment.SelectedIndex = 1;
                    }
                }
                else
                {
                    LabelEveryMonthPay.Text = "Ежемесячный платеж: ...";
                    LabelTotalAmount.Text = "Общая сумма: ...";
                    LabelOverpayment.Text = "Переплата: ...";
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_Lembrete.Models;
using Prism.Commands;
using Xamarin.Forms.Xaml;
using System.Globalization;
using App_Lembrete.Views;

namespace App_Lembrete.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void ActionGoConsultarCep(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TerceiraPage());
        }
        public void ActionGoLembretes(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PrimeiraPage());
        }
    }
}
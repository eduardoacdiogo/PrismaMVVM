using Xamarin.Forms;
using App_Lembrete.Models;
using System.Collections.Generic;
using System;
using Prism.Commands;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using App_Lembrete.Views;

namespace App_Lembrete.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrimeiraPage : ContentPage
    {
        public PrimeiraPage()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-BR");

            string Data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture);

            DataHoje.Text = string.Format(Data, "de");

            CarregarLembretes();
        }
        public void ActionGoSegundaPage(object sender, EventArgs args)

        {
            Navigation.PushAsync(new SegundaPage());
        }


        private void CarregarLembretes()
        {
            SLLembretes.Children.Clear();
            List<Lembrete> Lista = new GerenciadorLembrete().Listagem();

            int i = 0;
            foreach (Lembrete lembrete in Lista)
            {
                LinhaStackLayout(lembrete, i);
                i++;
            }
        }

        private void LinhaStackLayout(Lembrete lembrete, int index)
        {
            Image Lixeira = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Resources/lixeira.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Lixeira.Source = ImageSource.FromFile("lixeira.png");
            }
            TapGestureRecognizer LixeiraTap = new TapGestureRecognizer();

            LixeiraTap.Tapped += delegate
            {
                new GerenciadorLembrete().Deletar(index);
                CarregarLembretes();
            };

            Lixeira.GestureRecognizers.Add(LixeiraTap);

            View StackCentral = null;

            if (lembrete.DataFinalizacao == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = lembrete.Titulo };
            }
            else
            {
                StackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = lembrete.Titulo, TextColor = Color.Gray });
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizado em " + lembrete.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h", TextColor = Color.Gray, FontSize = 10 });
            }

            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Resources/naofeito.png") };

            if (Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("naofeito.png");
            }

            if (lembrete.DataFinalizacao != null)
            {
                Check.Source = ImageSource.FromFile("Resources/feito.png");

                if (Device.RuntimePlatform == Device.UWP)
                {
                    Check.Source = ImageSource.FromFile("feito.png");
                }
            }

            TapGestureRecognizer CheckTap = new TapGestureRecognizer();

            CheckTap.Tapped += delegate

            {
                new GerenciadorLembrete().Finalizar(index, lembrete);
                CarregarLembretes();
            };

            Check.GestureRecognizers.Add(CheckTap);

            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(Check);

            Linha.Children.Add(StackCentral);

            Linha.Children.Add(Lixeira);

            SLLembretes.Children.Add(Linha);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_ListaDeTarefas.Views;
using System.Globalization;
using App_ListaDeTarefas.Modelos;
using Prism.Services;
using Prism.Navigation;
using Prism.Commands;

namespace App_ListaDeTarefas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public DelegateCommand ClickNavigationCommand { get; set; }

        INavigationService _navigationService;

        private IPageDialogService _dialogService;
        public MainPage(INavigationService navigationService, IPageDialogService dialogService)
        {
            InitializeComponent();

            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);

            _dialogService = dialogService;

            _navigationService = navigationService;

            CultureInfo culture = new CultureInfo("pt-BR");

            string Data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", culture);
                       
            DataHoje.Text = string.Format(Data, "de");
                       
            CarregarTarefas();
        }

        private void ExecuteClickNavigationCommand()
        {
            _navigationService.NavigateAsync("SecondPage");
        }

        /*public void ActionGoSecondPage(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SecondPage());
        }*/

        private void CarregarTarefas()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> Lista = new GerenciadorTarefa().Listagem();

            int i = 0;

            foreach (Tarefa tarefa in Lista)
            {
                LinhaStackLayout(tarefa, i);
                i++;
            }
        }
        public void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };

            if (Device.RuntimePlatform == Device.UWP)
            {
                Delete.Source = ImageSource.FromFile("Resources/Delete.png");
            }

            TapGestureRecognizer DeleteTap = new TapGestureRecognizer();

            DeleteTap.Tapped += delegate
            {
                new GerenciadorTarefa().Deletar(index);

                CarregarTarefas();
            };

            Delete.GestureRecognizers.Add(DeleteTap);

            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("p" + tarefa.Prioridade + ".png") };

            if (Device.RuntimePlatform == Device.UWP)
            {
                Prioridade.Source = ImageSource.FromFile("Resources/p" + tarefa.Prioridade + ".png");
            }

            View StackCentral = null;

            if (tarefa.DataFinalizacao == null)
            {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                StackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };

                ((StackLayout)StackCentral).Children.Add(new Label() { Text = tarefa.Nome, TextColor = Color.Gray });

                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizado em " + tarefa.DataFinalizacao.ToString("dd/MM/yyyy - hh:mm") + "h", TextColor = Color.Gray, FontSize = 10 });
            }

            Image Check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png") };

            if (Device.RuntimePlatform == Device.UWP)
            {
                Check.Source = ImageSource.FromFile("CheckOff.png");
            }
            if (tarefa.DataFinalizacao != null)
            {
                Check.Source = ImageSource.FromFile("CheckOn.png");

                if (Device.RuntimePlatform == Device.UWP)
                {
                    Check.Source = ImageSource.FromFile("Resources/CheckOn.png");
                }
            }

            TapGestureRecognizer CheckTap = new TapGestureRecognizer();

            CheckTap.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(index, tarefa);
                CarregarTarefas();
            };
            Check.GestureRecognizers.Add(CheckTap);

            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(Check);

            Linha.Children.Add(StackCentral);

            Linha.Children.Add(Prioridade);

            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
        }
    }
}
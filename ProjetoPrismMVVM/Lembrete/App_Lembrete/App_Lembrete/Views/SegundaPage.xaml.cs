using Xamarin.Forms;
using App_Lembrete.Views;
using App_Lembrete.Models;
using System.Collections.Generic;
using System;
using Prism.Commands;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Prism.Services;
using Prism.Navigation;

namespace App_Lembrete.Views
{
    public partial class SegundaPage : ContentPage
    {
        //private IPageDialogService _dialogService;
        public SegundaPage()
        {
            InitializeComponent();
        }
        public void ActionGoSalvar(object sender, EventArgs args)
        {
            //bool ErroExiste = true;

            /*if (Dados(TxtNome.Text.Trim()))
            {*/
                try
                {
                    Lembrete lembrete = new Lembrete();

                    if (!(TxtNome.Text.Trim().Length > 0))
                    {
                        DisplayAlert("ERRO", "Titulo não preenchido", "OK");
                    }
                    else
                    {
                        if (!(TxtDescricao.Text.Trim().Length > 0))
                        {
                            lembrete.Descricao = " ";
                        }
                        if (!(dataDia.Text.Trim().Length > 0))
                        {
                            lembrete.Dia = " ";
                            lembrete.Mes = " ";
                        }

                        lembrete.Titulo = TxtNome.Text.Trim();
                        lembrete.Descricao = TxtDescricao.Text.Trim();
                        lembrete.Dia = dataDia.Text.Trim();
                        lembrete.Mes = dataMes.Text.Trim();

                        new GerenciadorLembrete().Salvar(lembrete);

                        App.Current.MainPage = new NavigationPage(new PrimeiraPage());
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            //}
        }
        /*private bool Dados(string TxtNome)
        {
            bool ErroExiste = true;

            if (!(TxtNome.Trim().Length > 0))
            { 
                ErroExiste = false;
                DisplayAlert("ERRO", "Titulo não preenchido", "OK");
            }
            return ErroExiste;
        }*/    
        
    }
}

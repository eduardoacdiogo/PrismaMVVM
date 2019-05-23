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
            bool ErroExiste = false;
            if (!(TxtNome.Text.Trim().Length > 0))
            {                
                ErroExiste = true;
                DisplayAlert("ERRO", "Titulo não preenchido", "OK");
            }
            if (ErroExiste == false)
            {
                //Salva esses dados.

                Lembrete lembrete = new Lembrete();
                if(!(TxtDescricao.Text.Trim().Length > 0))
                {
                    lembrete.Descricao = " ";
                }
                if (!(dataDia.Text.Trim().Length > 0))
                {
                    lembrete.Dia = "0";
                    lembrete.Mes = "0";
                    lembrete.Ano = "0";
                }
                lembrete.Titulo = TxtNome.Text.Trim();
                lembrete.Descricao = TxtDescricao.Text.Trim();
                lembrete.Dia = dataDia.Text.Trim();
                lembrete.Mes = dataMes.Text.Trim();
                lembrete.Ano = dataAno.Text.Trim();

                new GerenciadorLembrete().Salvar(lembrete);

                App.Current.MainPage = new NavigationPage(new PrimeiraPage());
            }
        }
    }
}

using Prism.Services;
using System;
using Xamarin.Forms;
using App_ListaDeTarefas.Modelos;
using Prism.Commands;
using Prism.Navigation;

namespace App_ListaDeTarefas.Views
{
    public partial class SecondPage : ContentPage
    {
        #region Command
        public DelegateCommand ClickNavigationCommand { get; set; }
        INavigationService _navigationService;
        #endregion
        private IPageDialogService _dialogService;
        private byte Prioridade { get; set; }
        public SecondPage(IPageDialogService dialogService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
            _dialogService = dialogService;
        }
        private void ExecuteClickNavigationCommand()
        {
            _navigationService.NavigateAsync("MainPage");
        }
        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var Stacks = SLPrioridades.Children;
            foreach (var Linha in Stacks)
            {
                Label lblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            String Prioridade = Source.File.ToString().Replace("Resources/", "").Replace(".png", "");

            this.Prioridade = byte.Parse(Prioridade);
            //TxtNome.Text = Prioridade;
        }
        public void SalvarAction(object sender, EventArgs args)
        {
            bool ErroExiste = false;
            //_dialogService = dialogService;

            if (!(TxtNome.Text.Trim().Length > 0))
            {
                _dialogService.DisplayAlertAsync("ERRO", "Sem Texto", "OK");
                ErroExiste = true;
            }
            if (!(this.Prioridade > 0))
            {
                _dialogService.DisplayAlertAsync("ERRO", "Marque uma prioridade", "OK");
                ErroExiste = true;

            }
            if (ErroExiste == false)
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = TxtNome.Text.Trim();
                tarefa.Prioridade = this.Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);

                ExecuteClickNavigationCommand();
                //App.Current.MainPage = new NavigationPage(new MainPage());
            }
        }
    }
}

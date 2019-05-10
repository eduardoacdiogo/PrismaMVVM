using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using App_CEP_PrimeiraEntrega.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Services;

namespace App_CEP_PrimeiraEntrega.ViewModel
{
    public class MainPageViewModel : BindableBase
    {
        #region Global
        INavigationService _navigationService;
        private IPageDialogService _dialogService;
        #endregion

        #region Binding
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string CEP;
        public string Cep
        {
            get { return CEP; }
            set { SetProperty(ref CEP, value); }
        }

        private string resultado;
        public string RESULTADO
        {
            get { return resultado; }
            set { SetProperty(ref resultado, value); }
        }
        #endregion

        #region Command
        public DelegateCommand ClickNavigationCommand { get; set; }
        #endregion
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            Title = "Buscar CEP";
            CEP = "Digite o CEP";

            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
        }

        private void ExecuteClickNavigationCommand()
        {
            string cep = Cep.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEP.BuscarEnderecoViaCEP(cep);

                    RESULTADO = string.Format("Endereco: {2} de {3}, {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);

                    if (end != null)
                    {
                        RESULTADO = string.Format("Endereco: {2} de {3}, {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        _dialogService.DisplayAlertAsync("ERRO", "CEP não foi encontrado: " + cep, "OK");
                        //DisplayAlert("ERRO", "CEP não foi encontrado: " + cep, "OK");
                    }

                }
                catch (Exception e)
                {
                    _dialogService.DisplayAlertAsync("ERRO CRÍTICO", e.Message, "OK");
                   // DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                //Erro
                _dialogService.DisplayAlertAsync("ERRO", "CEP inválido! O CEP deve obter 8 digitos", "OK");
                //DisplayAlert("ERRO", "CEP inválido! O CEP deve obter 8 digitos", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                //Erro
                _dialogService.DisplayAlertAsync("ERRO", "CEP inválido! O CEP deve obter apenas números", "OK");
                //DisplayAlert("ERRO", "CEP inválido! O CEP deve obter apenas números", "OK");
                valido = false;
            }
            return valido;
        }   
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using App_Lembrete.Models;

namespace App_Lembrete.ViewModels
{
    public class TerceiraPageViewModel : BindableBase
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

        public TerceiraPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
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
                    }
                }
                catch (Exception e)
                {
                    _dialogService.DisplayAlertAsync("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                _dialogService.DisplayAlertAsync("ERRO", "CEP inválido! O CEP deve obter 8 digitos", "OK");
                valido = false;
            }
            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                _dialogService.DisplayAlertAsync("ERRO", "CEP inválido! O CEP deve obter apenas números", "OK");
                valido = false;
            }
            return valido;
        }
    }
}

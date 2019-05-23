using App_Lembrete.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Lembrete.ViewModels
{
    public class PrimeiraPageViewModel : BindableBase
    {
        #region Bindin

        #endregion

        #region Global 
        INavigationService _navigationService;
        #endregion

        #region Command
        public DelegateCommand ClickNavigationCommand { get; set; }
        #endregion

        public PrimeiraPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
        }
        /*private void ExecuteClickNavigationCommand()
        {
            _navigationService.NavigateAsync("SegondaPage");
        }*/
    }
}

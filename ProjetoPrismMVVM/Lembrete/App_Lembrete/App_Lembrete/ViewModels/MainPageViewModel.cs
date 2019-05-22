using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using NavigationParameters = Prism.Navigation.NavigationParameters;
using App_Lembrete.Models;

namespace App_Lembrete.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Global 
        INavigationService _navigationService;
        #endregion

        #region Command
        public DelegateCommand ClickNavigationCommand { get; set; }
        #endregion

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Bem Vindo ao Nosso APP";
            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
        }

        public void ExecuteClickNavigationCommand()
        {
            _navigationService.NavigateAsync("PrimeiraPage");
        }
    }
}

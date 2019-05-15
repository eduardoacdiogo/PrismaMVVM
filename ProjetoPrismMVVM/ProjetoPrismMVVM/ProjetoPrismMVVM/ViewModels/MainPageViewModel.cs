using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetoPrismMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoPrismMVVM.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        #region Global
        INavigationService _navigationService;
        #endregion

        #region Binding

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        #endregion

        #region Command
        public DelegateCommand ClickNavigationCommand { get; set; }

        #endregion

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "MainPage";
            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
        }

        private void ExecuteClickNavigationCommand()
        { 
            Pessoa p = new Pessoa
            {
                ID = 1,
                Name = "Nome"
            };
            var item = new NavigationParameters()
            {
                { "itemNav", p }
            };
            _navigationService.NavigateAsync("SecondPage",item);
        }
    }
}

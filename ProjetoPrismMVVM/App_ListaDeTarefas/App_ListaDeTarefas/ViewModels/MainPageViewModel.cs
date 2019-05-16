using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_ListaDeTarefas.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        #region Global
        INavigationService _navigationService;

        #endregion

        #region Binding
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion

        #region Command
            public DelegateCommand ClickNavigationCommand { get; set; }
        #endregion
        
        public MainPageViewModel(INavigationService navigationService)
        {
            Title = "Lista de Tarefas";
            _navigationService = navigationService;
            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
        }

        private void ExecuteClickNavigationCommand()
        {
            _navigationService.NavigateAsync("SecondPage");
        }
    }
}

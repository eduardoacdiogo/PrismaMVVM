using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Lembrete.ViewModels
{
    public class SegundaPageViewModel : BindableBase
    {
        INavigationService _navigationService;
        public SegundaPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

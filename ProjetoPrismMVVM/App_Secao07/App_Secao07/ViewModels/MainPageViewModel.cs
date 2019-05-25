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
using App_Secao07.Layouts;
using App_Secao07.Views;

using System.Threading.Tasks;

namespace App_Secao07.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Tipos de Layouts";
        }
    }
}

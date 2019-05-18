using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_ListaDeTarefas.Modelos;
using Prism.Navigation.Xaml;

namespace App_ListaDeTarefas.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }

            set { SetProperty(ref _title, value); }
        }
        public MainPageViewModel(INavigationService navigationService)
         {
            Title = "Main Page";
         }
    }
}
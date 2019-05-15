using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetoPrismMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPrismMVVM.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware
    {
        private Pessoa p;
        public Pessoa P
        {
            get { return p; }
            set {SetProperty(ref p, value); }
        }

        public SecondPageViewModel()
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("itemNav"))
            {
                P = (Pessoa)parameters["itemNav"];
            }
        }
    }
}

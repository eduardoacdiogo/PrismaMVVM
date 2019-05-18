using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text;
using Prism.Navigation;
using App_ListaDeTarefas.Modelos;
using System.Globalization;
using Prism.Services;

namespace App_ListaDeTarefas.ViewModels
{
    public class SecondPageViewModel : BindableBase //ContentPage

    {

        #region Binding

        private string title;

        public string Title

        {

            get { return title; }

            set { SetProperty(ref title, value); }

        }

        private string slprioridades;

        public string SLPrioridades

        {

            get { return slprioridades; }

            set { SetProperty(ref slprioridades, value); }

        }

        private string txtnome;

        public string TxtNome

        {

            get { return txtnome; }

            set { SetProperty(ref txtnome, value); }

        }

        #endregion

        public SecondPageViewModel()

        {

            Title = "Cadastramento";

        }
    }
}



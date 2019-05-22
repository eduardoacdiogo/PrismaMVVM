using Xamarin.Forms;
using App_Lembrete.Models;
using System.Collections.Generic;
using System;

namespace App_Lembrete.Views
{
    public partial class PrimeiraPage : ContentPage
    {
        #region Command

        #endregion
        public PrimeiraPage()
        {
            InitializeComponent();

            CarregarLembretes();
        }


        private void CarregarLembretes()
        {
            SLLembretes.Children.Clear();
            List<Lembrete> Lista = new GerenciadorLembrete().Listagem();

            int i = 0;
            foreach (Lembrete lembrete in Lista)
            {
                LinhaStackLayout(lembrete, i);
                i++;
            }
        }

        private void LinhaStackLayout(Lembrete lembrete, int index)
        {
            throw new NotImplementedException();
        }
    }
}

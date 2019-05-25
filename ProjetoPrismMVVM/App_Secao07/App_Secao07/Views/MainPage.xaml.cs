using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_Secao07.Layouts.Absolute;
using App_Secao07.Layouts.Grid;
using App_Secao07.Layouts.Relative;
using App_Secao07.Layouts.Scroll;
using App_Secao07.Layouts.Stack;
using App_Secao07.Views;
using Prism.Commands;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace App_Secao07.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void ActionGoAbsolute(object sender, EventArgs args)
        {
            Navigation.PushAsync(new App_Secao07.Layouts.Absolute.AbsolutePage());
        }
        public void ActionGoGrid(object sender, EventArgs args)
        {
            Navigation.PushAsync(new GridPage());
        }
        public void ActionGoRelative(object sender, EventArgs args)
        {
            Navigation.PushAsync(new RelativePage());
        }
        public void ActionGoScroll(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SrollPage());
        }
        public void ActionGoStack(object sender, EventArgs args)
        {
            Navigation.PushAsync(new StackPage());
        }
    }
}
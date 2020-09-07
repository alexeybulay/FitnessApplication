using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndTrainPage : ContentPage
    {
        private int Count;
        public EndTrainPage(int _Count)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            btn.BackgroundColor = Color.FromRgba(255, 255, 140, 80);
            Count = _Count;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Count)
            {
                case 1:
                {
                    this.BindingContext = new ProcessTrainViewModel(1, "GrudAndBiceps");
                    break;
                }
                case 2:
                {
                    this.BindingContext = new ProcessTrainViewModel(1, "Press", "Press");
                    break;
                }
                case 3:
                {
                    this.BindingContext = new ProcessTrainViewModel(1, "NogiAndPlechi", "NogiAndPlechi", "NogiAndPlechi");
                    break;
                }
            }
        }
    }
}
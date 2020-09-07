using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Media;
using App3.View;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;


namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); // указывает, есть ли у этого элемента панель навигации
            buttonn1.Clicked += Buttonn1_Clicked;
            buttonn1.BackgroundColor = Color.FromRgba(1, 1, 1, 0);
        }

        private async void Buttonn1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage2());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Speech.Tts;
using App3.DataAccess;
using App3.Model;
using App3.ViewModel;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessTrain : ContentPage
    {
        private readonly int _trainID;
        private readonly int Count;
        public ProcessTrain(int trainID, int _Count)
        {
            InitializeComponent();
            Count = _Count;
            _trainID = trainID;
        }

        public ProcessTrain(int trainID)
        {
            InitializeComponent();
            _trainID = trainID;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Count)
            {
                case 1:
                {
                    this.BindingContext = new ProcessTrainViewModel(_trainID, "GrudAndBiceps");
                        break;
                }
                case 2:
                {
                    this.BindingContext = new ProcessTrainViewModel(_trainID, "Press","Press");
                        break;
                }
                case 3:
                {
                    this.BindingContext = new ProcessTrainViewModel(_trainID, "NogiAndPlechi", "NogiAndPlechi", "NogiAndPlechi");
                        break;
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushPopupAsync(new ExitInTrain());
            Navigation.PopAllPopupAsync();
            Navigation.PushPopupAsync(new ExitInTrain());
            return true;
        }
    }
}
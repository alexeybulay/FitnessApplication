using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App3.ViewModel;
using Java.Sql;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private ProcessTrainViewModel processTrainViewModel;
        private readonly int _exerciseID;
        public int _secundes = 5;
        private readonly int Count;

        public TimerPage()
        {
            InitializeComponent();
        }

        public TimerPage(int exerciseID, int _Count)
        {
            InitializeComponent();
            btnIncrement.Clicked += (s, e) =>
            {
                _secundes += 20;
                labelTimer.Text = _secundes.ToString();
            };
            Count = _Count;
            Device.StartTimer(TimeSpan.FromSeconds(1),
                OnTimeTick
            );
            _exerciseID = exerciseID;
        }
        bool OnTimeTick()
        {
            _secundes -= 1;
            labelTimer.Text = _secundes.ToString();
            if (labelTimer.Text == "0" )
            {
                NewPage();
                return false;
            }
            return true;
        }


        async Task NewPage()
        {
            switch (Count)
            {
                case 1:
                {
                    await Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 1), false);
                    break;
                }
                case 2:
                {
                    await Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 2), false);

                    break;
                }
                case 3:
                {
                    await Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 3), false);

                    break;
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Go();
        }

        void Go()
        {
            switch (Count)
            {
                case 1:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID,"GrudAndBiceps");
                        break;
                }
                case 2:
                {
                        processTrainViewModel = new ProcessTrainViewModel(_exerciseID, "Press","Press");
                        break;
                }
                case 3:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID, "NogiAndPlechi", "NogiAndPlechi", "NogiAndPlechi");
                    break;
                }
            }
            this.BindingContext = processTrainViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushPopupAsync(new ExitInTrain());
            Navigation.PopAllPopupAsync();
            Navigation.PushPopupAsync(new ExitInTrain());
            return true;
        }
        //async void SpeakTextAsync()
        //{
        //    await TextToSpeech.SpeakAsync($"Отдых {_secundes} секунд", new SpeechOptions
        //    {
        //        Volume = 75f
        //    });
        //}
    }
}
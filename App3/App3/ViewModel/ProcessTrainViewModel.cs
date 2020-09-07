using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App3.DataAccess;
using App3.Model;
using App3.View;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
    //олд
namespace App3.ViewModel
{
    public class ProcessTrainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region PrivateProperty
        private int id;
        public int trainPressLength;
        private string imagePath;
        private string nameExercise;
        private int count;
        private DateTime timeStartTrain;
        private DateTime timeEndTrain;
        private TimeSpan timeResult;
        private readonly TimerPage timerPage;
        private readonly int _trainID;
        #endregion

        #region PublicProperty
        public string Text { get; set; }
        public string NameTitle { get; set; }

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public int TrainPressLength
        {
            get => trainPressLength;
            set
            {
                trainPressLength = value;
                OnPropertyChanged("TrainPressLength");
            }
        }
        public string ImagePath
        {
            get => imagePath;

            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        public string NameExercise
        {
            get => nameExercise;

            set
            {
                nameExercise = value;
                OnPropertyChanged("NameExercise");
            }
        }
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public DateTime TimeStartTrain
        {
            get => timeStartTrain;
            set
            {
                timeStartTrain = value;
                OnPropertyChanged("TimeStartTrain");
            }
        } 
        public DateTime TimeEndTrain
        {
            get => timeEndTrain;
            set
            {
                timeEndTrain = value;
                OnPropertyChanged("TimeEndTrain");
            }
        }  
        public TimeSpan TimeResult
        {
            get => timeResult;
            set
            {
                timeResult = value;
                OnPropertyChanged("TimeResult");
            }
        }

        #endregion

        #region Generics
        private ObservableCollection<TrainList.Press> pressList { get; set; }
        private ObservableCollection<TrainList.GrudAndBiceps> grudAndBicepsList { get; set; }
        private ObservableCollection<TrainList.NogiAndPlechi> nogiAndPlechiList { get; set; }
        public TrainListDbContext _TrainListDbContext { get; set; }
        public ObservableCollection<TrainList.Press> PressList
        {
            get => pressList;
            set => pressList = value;
        }
        public ObservableCollection<TrainList.GrudAndBiceps> GrudAndBicepsList
        {
            get => grudAndBicepsList;
            set => grudAndBicepsList = value;
        }  
        public ObservableCollection<TrainList.NogiAndPlechi> NogiAndPlechiList
        {
            get => nogiAndPlechiList;
            set => nogiAndPlechiList = value;
        }
        #endregion

        #region Command
        public ICommand NextExercise { get; set; }
        public ICommand GoToNextExercise { get; set; }
        public ICommand IncrementPause { get; set; }
        public ICommand ExitInTrain { get; set; }
        #endregion

        #region TrainGrudAndBiceps
        public ProcessTrainViewModel(int trainID,string s)
        {
            _trainID = trainID;
            _trainID++;
            timerPage = new TimerPage(_trainID, 4);
            _TrainListDbContext = new TrainListDbContext();
            var trainGrudAndBiceps = _TrainListDbContext.GrudAndBicepsesDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.GrudAndBicepsesDbSet.Count();
            ID = trainGrudAndBiceps.GrudAndBicepsID;
            ImagePath = trainGrudAndBiceps.ImagePath;
            NameExercise = trainGrudAndBiceps.NameExercise;
                //  Count = trainGrudAndBiceps.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            GrudAndBicepsList = new ObservableCollection<TrainList.GrudAndBiceps>(
                _TrainListDbContext.GrudAndBicepsesDbSet.Where(n => n.GrudAndBicepsID == trainID));
            if (_trainID == 1)
            {
                timeStartTrain = DateTime.Now;
                timeStartTrain.ToString("t");
            }
            if (_trainID > trainPressLength)
            {
                timeEndTrain = DateTime.Now;
                timeEndTrain.ToString("t");
                timeResult = timeEndTrain - timeStartTrain;
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EndTrainPage(1), false);
                    });

            }
            else
            {
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushModalAsync(new TimerPage(_trainID, 1), false);
                    });
            }
            GoToNextExercise = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProcessTrain(trainID,1), false);
                });
            IncrementPause = new Command(
                () => timerPage._secundes += 20
                );
            ExitInTrain = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAllPopupAsync();
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage2());
                }
                );
        }
        #endregion

        #region TrainPress
        public ProcessTrainViewModel(int trainID, string s, string ss)
        {
            timerPage = new TimerPage();
            _trainID = trainID;
            _trainID++; 
            _TrainListDbContext = new TrainListDbContext();
            var trainPress = _TrainListDbContext.PressDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.PressDbSet.Count();
            ID = trainPress.PressID;
            ImagePath = trainPress.ImagePath;
            NameExercise = trainPress.NameExercise;
          //  Count = trainPress.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            PressList = new ObservableCollection<TrainList.Press>(
                _TrainListDbContext.PressDbSet.Where(n => n.PressID == trainID));
            if (_trainID == 1)
            {
                timeStartTrain = DateTime.Now;
                timeStartTrain.ToString("t");
            }
            if (_trainID > trainPressLength)
            {
                timeEndTrain = DateTime.Now;
                timeEndTrain.ToString("t");
                timeResult = timeEndTrain - timeStartTrain;
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EndTrainPage(2), false);
                    });

            }
            else
            {
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushModalAsync(new TimerPage(_trainID, 2), false);
                    });
            }
            GoToNextExercise = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProcessTrain(trainID, 2),false);
                });
            IncrementPause = new Command(
                () =>timerPage._secundes = 1000
                );
            ExitInTrain = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAllPopupAsync();
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage2());
                }
                );
        }
        #endregion

        #region TrainNogiAndPlechi
        public ProcessTrainViewModel(int trainID, string s, string ss, string sss)
        {
            _trainID = trainID;
            _trainID++;
            _TrainListDbContext = new TrainListDbContext();
            var trainNogiAndPlechi = _TrainListDbContext.NogiAndPlechiDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.NogiAndPlechiDbSet.Count();
            ID = trainNogiAndPlechi.NogiAndPlechiID;
            ImagePath = trainNogiAndPlechi.ImagePath;
            NameExercise = trainNogiAndPlechi.NameExercise;
           // Count = trainNogiAndPlechi.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            NogiAndPlechiList = new ObservableCollection<TrainList.NogiAndPlechi>(
                _TrainListDbContext.NogiAndPlechiDbSet.Where(n => n.NogiAndPlechiID == trainID));
            if (_trainID == 1)
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), OnClick);
            }
            if (_trainID > trainPressLength)
            {
                
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EndTrainPage(3), false);
                    });

            }
            else
            {
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushModalAsync(new TimerPage(_trainID, 3), false);
                    });
            }
            GoToNextExercise = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProcessTrain(trainID, 3), false);
                });
            IncrementPause = new Command(
                () => timerPage._secundes = 1000
                );
            ExitInTrain = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAllPopupAsync();
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage2());
                }
                );
        }

        private bool OnClick()
        {
            //if (a == 60)
            //{
            //    b += 1;
            //    a = 0;
            //    return true;
            //}
            //else if (b == 60)
            //{
            //    c += 1;
            //    b = 0;
            //    a = 0;
            //    return true;
            //}
            return true;

        }

        #endregion

        #region TrainSpinaAndTriceps
        public ProcessTrainViewModel(int trainID, string s, string ss, string sss, string ssss)
        {
            _trainID = trainID;
            _trainID++;
            _TrainListDbContext = new TrainListDbContext();
            var spinaAndTriceps = _TrainListDbContext.SpinaAndTricepsDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.SpinaAndTricepsDbSet.Count();
            ID = spinaAndTriceps.SpinaAndTricepsID;
            ImagePath = spinaAndTriceps.ImagePath;
            NameExercise = spinaAndTriceps.NameExercise;
           // Count = spinaAndTriceps.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            NogiAndPlechiList = new ObservableCollection<TrainList.NogiAndPlechi>(
                _TrainListDbContext.NogiAndPlechiDbSet.Where(n => n.NogiAndPlechiID == trainID));
            if (_trainID == 1)
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), OnClick);
            }
            if (_trainID > trainPressLength)
            {

                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EndTrainPage(4), false);
                    });

            }
            else
            {
                NextExercise = new Command(
                    async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushModalAsync(new TimerPage(_trainID, 4), false);
                    });
            }
            GoToNextExercise = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProcessTrain(trainID, 4), false);
                });
            IncrementPause = new Command(
                () => timerPage._secundes = 1000
                );
            ExitInTrain = new Command(
                async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAllPopupAsync();
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage2());
                }
                );
        }
        #endregion
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using App3.DataAccess;
using App3.Model;
using App3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainListPage : ContentPage
    {
        private TrainListViewModel _trainListViewModel;
        const string one = "Грудь и бицепс";
        const string two = "Пресс";
        const string three = "Ноги и плечи";
        const string fourth = "Спина и трицепс";
        public int Count { get; set; }
        public TrainListPage(int _Count)
        {
            InitializeComponent();
            Count = _Count;
            mylist.ItemTapped += (s, e) => { ((ListView) s).SelectedItem = null; };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _trainListViewModel = new TrainListViewModel(Count);
            switch (Count)
            {
                case 1:
                {
                    Title = one;
                    mylist.ItemsSource = _trainListViewModel.GrudAndBicepsList;
                        #region AddedParametersGrudAndBiceps
                        //using (var _TrainListDbContext = new TrainListDbContext())
                        //{
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() {ImagePath = "firstBiceps.gif", NameExercise = "Подъем на бицепс"}
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() {ImagePath = "firstGrud.gif", NameExercise = "Подъем на бицепс(?)"}
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "secondBiceps.gif", NameExercise = "Подъем гантели с упором на колено" }
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "secondGrud.gif", NameExercise = "Тяга гантели из за головы лежа" }
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "thrirdBiceps.gif", NameExercise = "Подъем гантелей сидя с отрицательным наклоном" }
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "thrirdGrud.gif", NameExercise = "Жим гантелей лежа на скамье" }
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "fourthBiceps.gif", NameExercise = "Молот" }
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "fourthGrud.gif", NameExercise = "Отжимания" }
                        //    );
                        //    _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                        //        new TrainList.GrudAndBiceps() { ImagePath = "sixthGrud.gif", NameExercise = "Подъём гантелей над головой сидя на скамье" }
                        //    );
                        //    _TrainListDbContext.SaveChanges();
                        //}
                        #endregion
                        break;
                }
                case 2:
                {
                    Title = two;
                    mylist.ItemsSource = _trainListViewModel.PressList;
                        #region AddedParametersPress
                        //using (var _TrainListDbContext = new TrainListDbContext())
                        //{
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() {ImagePath = "firstPress.gif", NameExercise = "Подъем туловища на пресс"}
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() {ImagePath = "secondPress.gif", NameExercise = "Сгибания на пресс"}
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = thrirdPress.gif", NameExercise = "Подъём туловища к прямым ногам на пресс" }
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "fourthPress.gif", NameExercise = "Обратный пресс" }
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "fivePress.gif", NameExercise = "Подтягивание локтей к коленям" }
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "sixthPress.gif", NameExercise = "Сворачивание туловища" }
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "sevensPress.gif", NameExercise = "Повороты торса с отягощением на пресс"}
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "eightPress.gif", NameExercise = "Диагональный подъём туловища" }
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "ninesPress.gif", NameExercise = "Альтернативные пятки" }
                        //    );
                        //    _TrainListDbContext.PressDbSet.Add(
                        //        new TrainList.Press() { ImagePath = "tensPress.gif", NameExercise = "Поочередный подъём ног на пресс" }
                        //    );
                        //    _TrainListDbContext.SaveChanges();
                        //}
                        #endregion
                        break;
                }
                case 3:
                {
                    Title = three;
                    mylist.ItemsSource = _trainListViewModel.NogiAndPlechiList;
                        #region AddedParametersNogiAndPlechi
                        //using (var _TrainListDbContext = new TrainListDbContext())
                        //{
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() {ImagePath = "firstNogi.gif", NameExercise = "Перекаты"}
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() {ImagePath = "firstPlechi.gif", NameExercise = "Подъем гантелей над головой"}
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "secondNogi.gif", NameExercise = "Приседание Пистолет" }
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "thrirdPlechi.gif", NameExercise = "Подъём гантелей через стороны" }
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "thrirdNogi.gif", NameExercise = "Приседание со штангой" }
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "fourthPlechi.gif", NameExercise = "Тяга гантелей в наклоне" }
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "fourthNogi.gif", NameExercise = "Приседание с гантелями" }
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "sixthPlechi.gif", NameExercise = "Поочередный подъём гантелей над головой" }
                        //    );
                        //    _TrainListDbContext.NogiAndPlechiDbSet.Add(
                        //        new TrainList.NogiAndPlechi() { ImagePath = "secondPlechi.gif", NameExercise = "Шраги" }
                        //    );
                        //    _TrainListDbContext.SaveChanges();
                        //}
                        #endregion
                        break;
                }
                case 4:
                {
                    Title = fourth;
                    mylist.ItemsSource = _trainListViewModel.SpinaAndTricepsList;
                    #region AddedParametersSpinaAndTriceps
                    //using (var _TrainListDbContext = new TrainListDbContext())
                    //{
                    //    _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() {ImagePath = "firstSpina.gif", NameExercise = "Подъем на бицепс"}
                    //    );
                    //    _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() {ImagePath = "firstTriceps.gif", NameExercise = "Подъем на бицепс"}
                    //    );
                    //     _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() { ImagePath = "secondSpina.gif", NameExercise = "Подъем гантели с упором на колено" }
                    //    );
                    //     _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() { ImagePath = "secondTriceps.gif", NameExercise = "Тяга гантели из за головы лежа" }
                    //    );
                    //    _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() { ImagePath = "thrirdSpina.gif", NameExercise = "Подъем гантелей сидя с отрицательным наклоном" }
                    //    );
                    //    _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() { ImagePath = "thrirdTriceps.gif", NameExercise = "Жим гантелей лежа на скамье" }
                    //    );
                    //    _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                    //        new TrainList.SpinaAndTriceps() { ImagePath = "fourthSpina.gif", NameExercise = "Молот" }
                    //    );
                    // }
                    #endregion
                        break;
                }
                default:
                {
                    break;
                }
            }

            this.BindingContext = _trainListViewModel;
        }
    }
}
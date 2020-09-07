using Xamarin.Forms;
using Easing = Xamarin.Forms.Easing;

namespace App3
{
    public class SplashImage : ContentPage
    {
        Image splashImage; // название для нашей картинки-приветствия
        public SplashImage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "start.jpg",
                Aspect = Aspect.Fill

            };
            sub.Children.Add(splashImage);

            this.Content = sub;

            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.3, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        protected override async void OnAppearing()
        {
            await splashImage.ScaleTo(1.07, 3000, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new MainPage2()
            {
                BarBackgroundColor = Color.White
            });
        }
    }
}

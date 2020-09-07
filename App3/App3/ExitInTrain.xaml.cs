using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.View;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExitInTrain : PopupPage
    {
        public ExitInTrain()
        {
            InitializeComponent();
            No.Clicked += (s, e) =>
            {
                Navigation.PopAllPopupAsync();
            };
        }
    }
}
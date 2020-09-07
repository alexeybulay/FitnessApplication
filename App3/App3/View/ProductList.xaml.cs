using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App7.DataAccess;
using App7.Model;
using App7.ViewModel;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
        public ProductList()
        {
            InitializeComponent();
            listProduct.ItemTapped += ListProduct_ItemTapped;
            listProduct.ItemSelected += (s, e) => { ((ListView) s).SelectedItem = null; };
        }

        private async void ListProduct_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = (Product) e.Item;
            await Navigation.PushAsync(new ProductInfo(product.ProductId), true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ProductListViewModel();
            
        }
    }
}
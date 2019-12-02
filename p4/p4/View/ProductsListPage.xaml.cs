using Newtonsoft.Json;
using p4.Model;
using p4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace p4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsListPage : ContentPage
    {
        public ProductsListPage()
        {
            InitializeComponent();
            //GetProducts();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listViewProducts.ItemsSource = await App.TodoManager.GetTasksAsync();
        }


        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage(true)
            {
                BindingContext = new Product
                {
                    ID = Guid.NewGuid().ToString()
                }
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ProductPage
            {
                BindingContext = e.SelectedItem as Product
            });
        }

        /*
        private async void GetProducts()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://autenticacion-c42d3.firebaseio.com/productos.json");
            var products = JsonConvert.DeserializeObject<List<WSResult1>>(response);

            listViewProducts.ItemsSource = products;

        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage(true)
            {
                BindingContext = new Product
                {
                    ID = Guid.NewGuid().ToString()
                }
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ProductPage
            {
                BindingContext = e.SelectedItem as Product
            });
        }
        */

    }
}
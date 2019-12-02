using Newtonsoft.Json;
using p4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace p4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {


        bool isNewItem;
        public ProductPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (Product)BindingContext;
            await App.TodoManager.SaveTaskAsync(todoItem, isNewItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (Product)BindingContext;
            await App.TodoManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        /*
        bool isNewProduct;
        public ProductPage(bool isNew = false)
        {
            InitializeComponent();
            isNewProduct = isNew;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                codigo = Convert.ToInt32(EntCodigo.Text),
                precio = Convert.ToDouble(EntPrecio.Text),
                descripcion = EntDescripcion.Text,
                vendido = Switch.IsToggled
            };

            var cod = product.codigo.ToString();
            var json = JsonConvert.SerializeObject(product);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            if (isNewProduct == false)
            {
                var result = await client.PostAsync("https://autenticacion-c42d3.firebaseio.com/productos.json", content);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    await DisplayAlert("Hey", "Se ha guardado el registro", "Aceptar");
                }
            } else
            {
                var result = await client.PutAsync(string.Concat("https://autenticacion-c42d3.firebaseio.com/productos/", cod,".json"), content);

            }

        }


        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var result = await client.DeleteAsync(string.Concat("https://autenticacion-c42d3.firebaseio.com/productos/", EntCodigo.Text, ".json"));
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        */


    }
}
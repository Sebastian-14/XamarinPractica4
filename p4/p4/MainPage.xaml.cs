using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace p4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //traerDatos();
            GetProducts();
        }

        private async void GetProducts()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://autenticacion-c42d3.firebaseio.com/productos.json");
            var products = JsonConvert.DeserializeObject<List<WSResult1>>(response);

            ProductsListView.ItemsSource = products;

        }

        /*
        private async void BtnCallWS_Click(object sender, EventArgs e)
        {
            WSClient client = new WSClient();
            //var result = await client.Get<WSResult>("https://jsonplaceholder.typicode.com/posts/1");
            var result1 = await client.Get<WSResult1>("https://autenticacion-c42d3.firebaseio.com/productos.json");
            if (result1 != null)
            {
                
                lblId.Text = $"{result.id}";
                lblTitle.Text = result.title;
                lblBody.Text = result.body;
                

                lblCodigo.Text = $"{result1.codigo}";
                lblDescripcion.Text = $"{result1.descripcion}";
                lblPrecio.Text = $"{result1.precio}";


            }
        }
    */

        /*

    private async void traerDatos()
    {
        WSClient client = new WSClient();
        //var result = await client.Get<WSResult>("https://jsonplaceholder.typicode.com/posts/1");
        var result1 = await client.Get<WSResult1>("https://autenticacion-c42d3.firebaseio.com/productos.json");
        if (result1 != null)
        {

            lblId.Text = $"{result.id}";
            lblTitle.Text = result.title;
            lblBody.Text = result.body;


            lblCodigo.Text = $"{result1.codigo}";
            lblDescripcion.Text = $"{result1.descripcion}";
            lblPrecio.Text = $"{result1.precio}";


        }
    }

    private async void insertarDato()
    {
        WSClient client = new WSClient();

    }

    */
    }
}

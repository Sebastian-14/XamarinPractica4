using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using p4.Model;
using Newtonsoft.Json;

namespace p4.Data
{
    public class RestService: IRestService
    {
        HttpClient _client;

        public List<Product> Products { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Product>> RefreshDataAsync()
        {
            Products = new List<Product>();

            var uri = new Uri(Constants.ProductosUrl);
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Products;
        }

        public async Task SaveProductAsync(Product item, bool isNewItem)
        {
            var uri = new Uri("https://testapinode-02-12.herokuapp.com/productos/");

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    var uri1 = new Uri(string.Concat("https://testapinode-02-12.herokuapp.com/productos/", item.codigo));
                    response = await _client.PutAsync(uri1, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteProductAsync(string id)
        {
            var uri = new Uri(string.Concat("https://testapinode-02-12.herokuapp.com/productos/", id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

    }
}

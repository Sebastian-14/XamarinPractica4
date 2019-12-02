using p4.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace p4.Data
{
    public class ProductManager
    {
        IRestService restService;

        public ProductManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Product>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Product item, bool isNewItem = false)
        {
            return restService.SaveProductAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(Product item)
        {
            return restService.DeleteProductAsync(item.codigo.ToString());
        }
    }
}

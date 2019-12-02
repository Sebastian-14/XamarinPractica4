using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using p4.Model;

namespace p4.Data
{
    public interface IRestService
    {
        Task<List<Product>> RefreshDataAsync();

        Task SaveProductAsync(Product item, bool isNewItem);

        Task DeleteProductAsync(string id);
    }
}

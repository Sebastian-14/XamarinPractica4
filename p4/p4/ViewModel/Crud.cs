using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using p4.Model;
using p4.Data;

namespace p4.ViewModel
{
    class Crud: ViewModelBase
    {

        List<Product> lista;
        bool isNew;
        //Product _product;


        Product _product;
        public Product product
        {
            get { return _product; }
            set
            {
                if (_product != value)
                {
                    _product = value;
                    OnPropertyChanged();
                }
            }
        }




        public Crud()
        {
            //var todoItem = Product();

            AddProduct = new Command<String>(execute: async (string pressed) =>
            {
                //var result = Metods.HTTPAsync("https://autenticacion-c42d3.firebaseio.com/productos.json", "GET");
            });
        }

        /*
        public CrudViewModel()
        {
            GetProducts = new Command<String>(execute: async (string pressed) =>
            {
                var res = await App.TodoManager.GetTasksAsync();
                lista.Add(res);
            });
        }
        */

        public ICommand GetProducts { protected set; get; }

        public ICommand AddProduct { protected set; get; }

    }

}

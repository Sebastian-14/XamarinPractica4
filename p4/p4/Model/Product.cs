using System;
using System.Collections.Generic;
using System.Text;

namespace p4.Model
{
    public class Product
    {
        public string ID { get; set; }
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public bool vendido { get; set; }
    }
}

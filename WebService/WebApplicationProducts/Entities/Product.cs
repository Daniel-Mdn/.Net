using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Interfaces;

namespace WebApplicationProducts.Entities
{
    public class Product : IProduct
    {

        private int _id;
        private string _name;
        private int _stock;
        private float _precio;
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public int Stock
        {
            get => _stock;
            set => _stock = value;
        }
        public float Precio { get => _precio; set => _precio = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
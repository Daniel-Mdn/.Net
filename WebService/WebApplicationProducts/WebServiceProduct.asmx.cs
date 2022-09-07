using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplicationProducts.Entities;
using Newtonsoft.Json;

namespace WebApplicationProducts
{
    /// <summary>
    /// Descripción breve de WebServiceProduct
    /// </summary>
     


    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceProduct : System.Web.Services.WebService
    {

        List<Product> list = new List<Product>
            {
               new Product{ Id=1, Name= "Prod1", Stock= 20, Precio= 150},
               new Product{ Id=2, Name= "Prod2", Stock= 50, Precio= 100},
               new Product{ Id=3, Name= "Prod3", Stock= 30, Precio= 400},
               new Product{ Id=4, Name= "Prod4", Stock= 40, Precio= 300},


            };

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }


        [WebMethod]
        public string getProducts()
        {

            string json= JsonConvert.SerializeObject(list, Formatting.Indented);
            return json;
        }


        [WebMethod]
        public string addProducts(Product prod)
        {
            list.Add(prod);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            return json;
        }
    }
}

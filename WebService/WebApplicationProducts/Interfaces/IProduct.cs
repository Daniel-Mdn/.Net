using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationProducts.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }

        string Name { get; set; }
        int Stock { get; set; }
        float Precio{ get; set; }    }
}

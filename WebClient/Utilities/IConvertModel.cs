using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopClient.Model;
using WebshopClient.ProductServiceReference;

namespace WebshopClient.Utilities
{
    interface IConvertModel
    {
        Product ConvertFromServiceProduct(ServiceProduct serviceProduct);
        ServiceProduct ConvertToServiceProduct(Product webshopProduct);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopClient.Model;
using WebshopClient.OrderServiceReference;

namespace WebshopClient.Utilities
{
    interface IConvertProductLine
    {
        ProductLine ConvertFromServiceProductLine(ServiceProductLine serviceProductLine);
        ServiceProductLine ConvertToServiceProductLine(ProductLine webshopProductLine);
    }
}

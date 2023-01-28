using ShopBridge.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Core.Entities.Products
{

    [Table("ProductInformation", Schema = "Inventory")]
    public class ProductModel:Base<int>
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int OpeningQuantity { get; set; }
        public int ThreshholdValue { get; set; }
    }
}

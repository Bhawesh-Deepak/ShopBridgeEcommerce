using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Api.ModelDTO
{
    public class ProductModelDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product name is required !")]
        public string ProductName { get; set; }

        public int CreatedBy { get; set; }
        [Required(ErrorMessage ="Product Code is required !")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage ="Product Descriptio is required !")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage ="Product Price is required !")]
        public decimal Price { get; set; }
        public int OpeningQuantity { get; set; }
        public int ThreshholdValue { get; set; }
    }
}

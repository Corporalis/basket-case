using System.Collections.Generic;

namespace BasketCase.Models
{
    public class BasketValidation
    {
        public BasketValidation()
        {
            Products = new List<Product>();
            GiftVouchers = new List<string>();
        }

        public List<Product> Products { get; }
        public List<string> GiftVouchers { get; }
        public string OfferVoucher { get; set; }
    }
}
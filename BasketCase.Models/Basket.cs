using System.Collections.Generic;
using System.Linq;

namespace BasketCase.Models
{
    public class Basket
    {
        public Basket()
        {
            Products = new List<Product>();
            GiftVouchers = new List<string>();
            Discounts = new List<Discount>();
            Messages = new List<string>();

        }
        public List<Product> Products { get; }
        public List<string> GiftVouchers { get; }
        public string OfferVoucher { get; set; }
        public List<Discount> Discounts { get; }
        public List<string> Messages { get; }

        public decimal Total
        {
            get
            {
                var productTotal = Products.Sum(p => p.Value);
                var discountTotal = Discounts.Sum(d => d.Value);
                return productTotal - discountTotal;
            }
        }
    }
}
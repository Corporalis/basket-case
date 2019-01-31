using System;
using System.Linq;
using BasketCase.Models;

namespace BasketCase.Discounts
{
    public class HeadGearOfferVoucherVisitor : DiscountVisitor
    {
        private const string VoucherCode = "123-HGR";
        public HeadGearOfferVoucherVisitor() : base(
            basket =>
            {
                return basket.OfferVoucher == VoucherCode;
            },
            basket =>
            {
                return  basket.Products.Any(p => p.Category == "headgear");
            },
            basket =>
            {
                var value = basket.Products.Where(p => p.Category == "headgear").Sum(p => p.Value);
                basket.Discounts.Add(new Discount(Math.Min(value, 5M)));
            },
            basket =>
            {
                basket.Messages.Add($"There are no products in your basket applicable to voucher {VoucherCode}");
            })
        {
        }
    }
}
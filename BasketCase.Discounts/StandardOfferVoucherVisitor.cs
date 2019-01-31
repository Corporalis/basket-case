using System.Linq;
using BasketCase.Models;

namespace BasketCase.Discounts
{
    public class StandardOfferVoucherVisitor : DiscountVisitor
    {
        private const string VoucherCode = "123-STD";
        private static decimal _total;
        public StandardOfferVoucherVisitor() : base(
            basket =>
            {
                return basket.OfferVoucher == VoucherCode;
            },
            basket =>
            {
                _total = basket.Products.Where(p => p.Category != "giftvoucher").Sum(p => p.Value);
                return  _total >= 50M;
            },
            basket =>
            {
                basket.Discounts.Add(new Discount(5M));
            },
            basket =>
            {
                var amount = 50M - _total;
                basket.Messages.Add($"You have not reached the spend threshold for voucher {VoucherCode}. Spend another £{amount} to recieve £5.00 discount from your basket total.");
            })
        {
        }
    }
}
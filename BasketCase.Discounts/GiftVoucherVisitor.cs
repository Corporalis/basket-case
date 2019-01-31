using System.Linq;
using BasketCase.Models;

namespace BasketCase.Discounts
{
    public class GiftVoucherVisitor : DiscountVisitor
    {
        private const string VoucherCode = "123-GFT";
        private static decimal _total;
        private static decimal _voucherAmount = 5M;
        public GiftVoucherVisitor() : base(
            basket =>
            {
                return basket.GiftVouchers.Contains(VoucherCode);
            },
            basket =>
            {
                // should validate that there have been any other gift cards applied
                _total = basket.Products.Where(p => p.Category != "giftvoucher").Sum(p => p.Value);
                return _total >= _voucherAmount;

            },
            basket =>
            {
                basket.Discounts.Add(new Discount(5M));
            },
            basket =>
            {
                var amount = 50M - _total;
                basket.Messages.Add($"You have not reached the spend threshold for voucher {VoucherCode}. Spend another £{amount} to recieve £{_voucherAmount} discount from your basket total.");

            })
        {
        }
    }
}
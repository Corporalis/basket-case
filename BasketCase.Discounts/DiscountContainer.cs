using System.Collections.Generic;
using BasketCase.Models;

namespace BasketCase.Discounts
{
    public class DiscountContainer : IDiscountContainer
    {
        private readonly IList<IDiscountVisitor> _visitors = new List<IDiscountVisitor>();
        public DiscountContainer()
        {
            // these could be loaded from a persistence layer, you could have 3 types, 1 gift voucher, 1 offer voucher with no category and
            // an offer one with a category. These have been added here for demo simplicity
            _visitors.Add(new StandardOfferVoucherVisitor());
            _visitors.Add(new HeadGearOfferVoucherVisitor());
            _visitors.Add(new GiftVoucherVisitor());
        }
        public void Accept(Basket basket)
        {
            foreach (var visitor in _visitors)
            {
                visitor.Visit(basket);
            }
        }
    }
}
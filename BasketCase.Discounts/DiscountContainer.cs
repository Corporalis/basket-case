using System.Collections.Generic;
using BasketCase.Models;

namespace BasketCase.Discounts
{
    public class DiscountContainer : IDiscountContainer
    {
        private readonly IList<IDiscountVisitor> _visitors = new List<IDiscountVisitor>();
        public DiscountContainer()
        {
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
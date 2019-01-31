using System;
using BasketCase.Models;

namespace BasketCase.Discounts
{
    public abstract class DiscountVisitor : IDiscountVisitor
    {
        private readonly Func<Basket, bool> _match;
        private readonly Func<Basket, bool> _condition;
        private readonly Action<Basket> _failureAction;
        private readonly Action<Basket> _action;

        protected DiscountVisitor(Func<Basket, bool> match, Func<Basket, bool> condition, Action<Basket> action, Action<Basket> failureAction)
        {
            _match = match;
            _condition = condition;
            _action = action;
            _failureAction = failureAction;

        }
        public void Visit(Basket basket)
        {
            if (!_match.Invoke(basket))
            {
                return;
            }

            if (_condition.Invoke(basket))
            {
                _action.Invoke(basket);
            }
            else
            {
                _failureAction.Invoke(basket);
            }

        }
    }
}
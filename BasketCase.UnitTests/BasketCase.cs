using BasketCase.Discounts;
using BasketCase.Models;
using Should;
using TechTalk.SpecFlow;

namespace BasketCase.UnitTests
{
    [Binding]
    public sealed class BasketCase
    {
        private Basket _basket;
        private Basket _output;
        private readonly IDiscountContainer _discountContainer;
        public BasketCase()
        {
            _discountContainer = new DiscountContainer();
        }


        [Given(@"a basket")]
        public void GivenABasket()
        {
            _basket = new Basket();
        }

        [Given(@"and a hat is added to the basket")]
        public void GivenAndAHatIsAddedToTheBasket()
        {
            _basket.Products.Add(new Product
            {
                Name = "Hat",
                Value = 10.50M
            });
        }

        [Given(@"and a jumper is added to the basket")]
        public void GivenAndAJumperIsAddedToTheBasket()
        {
            _basket.Products.Add(new Product
            {
                Name = "Jumper",
                Value = 54.65M
            });
        }

        [Given(@"and gift voucher is applied")]
        public void GivenAndGiftVoucherIsApplied()
        {
            _basket.GiftVouchers.Add("123-GFT");
        }

        [When(@"a discount is applied")]
        public void WhenADiscountIsApplied()
        {
            _output = _basket;
            _discountContainer.Accept(_output);
        }


        [Then(@"the gift voucher should be successfully applied")]
        public void ThenTheGiftVoucherShouldBeSuccessfullyApplied()
        {
            _output.ShouldNotBeNull();
            _output.Total.ShouldEqual((10.50M + 54.65M) - 5M);
        }


    }
}

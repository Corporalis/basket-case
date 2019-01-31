using System.Linq;
using BasketCase.Discounts;
using BasketCase.Models;
using Should;
using TechTalk.SpecFlow;

namespace BasketCase.UnitTests
{
    [Binding]
    public sealed class BasketCaseSteps
    {
        private Basket _basket;
        private Basket _output;
        private readonly IDiscountContainer _discountContainer;
        public BasketCaseSteps()
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

        [Given(@"and an expensive hat is added to the basket")]
        public void GivenAndAnExpensiveHatIsAddedToTheBasket()
        {
            _basket.Products.Add(new Product
            {
                Name = "Hat",
                Value = 25.00M
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

        [Given(@"and a cheap jumper is added to the basket")]
        public void GivenAndACheapJumperIsAddedToTheBasket()
        {
            _basket.Products.Add(new Product
            {
                Name = "Jumper",
                Value = 26.00M
            });
        }

        [Given(@"and a head light is added to the basket")]
        public void GivenAndAHeadLightIsAddedToTheBasket()
        {
            _basket.Products.Add(new Product
            {
                Name = "Head Light",
                Value = 3.50M,
                Category = "headgear"
            });
        }

        [Given(@"and a gift voucher is added to the basket")]
        public void GivenAndAGiftVoucherIsAddedToTheBasket()
        {
            _basket.Products.Add(new Product
            {
                Name = "Gift Voucher",
                Value = 30.00M,
                Category = "giftvoucher"
            });
        }


        [Given(@"and gift voucher is applied")]
        public void GivenAndGiftVoucherIsApplied()
        {
            _basket.GiftVouchers.Add("123-GFT");
        }

        [Given(@"and head gear offer voucher is applied")]
        public void GivenAndHeadGearOfferVoucherIsApplied()
        {
            _basket.OfferVoucher ="123-HGR";
        }

        [Given(@"and standard offer voucher is applied")]
        public void GivenAndStandardOfferVoucherIsApplied()
        {
            _basket.OfferVoucher ="123-STD";
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
            _output.Total.ShouldEqual(60.15M);
            _output.Discounts.Count.ShouldEqual(1);
            _output.Discounts.First().Value.ShouldEqual(5M);

        }

        [Then(@"the head gear offer voucher is not applied")]
        public void ThenTheHeadGearOfferVoucherIsNotApplied()
        {
            _output.ShouldNotBeNull();
            _output.Total.ShouldEqual(51.00M);
            _output.Discounts.Any().ShouldBeFalse();
        }

        [Then(@"the head gear offer voucher is applied")]
        public void ThenTheHeadGearOfferVoucherIsApplied()
        {
            _output.ShouldNotBeNull();
            _output.Total.ShouldEqual(51.00M);
            _output.Discounts.Count.ShouldEqual(1);
            _output.Discounts.First().Value.ShouldEqual(3.50M);
        }

        [Then(@"both vouchers are applied")]
        public void ThenBothVouchersAreApplied()
        {
            _output.ShouldNotBeNull();
            _output.Total.ShouldEqual(41.00M);
            _output.Discounts.Count.ShouldEqual(2);
            _output.Discounts.First().Value.ShouldEqual(5.00M);
            _output.Discounts.ElementAt(1).Value.ShouldEqual(5.00M);
        }

        [Then(@"the offer voucher condition has not been met")]
        public void ThenTheOfferVoucherConditionHasNotBeenMet()
        {
            _output.ShouldNotBeNull();
            _output.Total.ShouldEqual(55.00M);
            _output.Discounts.Any().ShouldBeFalse();
            var applicableSpend = _output.Total - _output.Products.Where(p => p.Category == "giftvoucher").Sum(p => p.Value);
            var amount = 50.01M - applicableSpend;
            _output.Messages.First().ShouldEqual($"You have not reached the spend threshold for voucher {_output.OfferVoucher}. Spend another £{amount} to receive £5.00 discount from your basket total.");
        }

    }
}

Feature: BasketCase
	In order to avoid silly mistakes
	As a basket handler
	I want to calculate appropriate discounts

Scenario: A gift voucher is supplied for appropriate products
	Given a basket
	And and a hat is added to the basket
	And and a jumper is added to the basket
	And and gift voucher is applied
	When a discount is applied
	Then the gift voucher should be successfully applied

Scenario: An offer voucher is applied to invalid products
	Given a basket
	And and an expensive hat is added to the basket
	And and a cheap jumper is added to the basket
	And and head gear offer voucher is applied
	When a discount is applied
	Then the head gear offer voucher is not applied

Scenario: An offer voucher is applied to valid products
	Given a basket
	And and an expensive hat is added to the basket
	And and a cheap jumper is added to the basket
	And and a head light is added to the basket
	And and head gear offer voucher is applied
	When a discount is applied
	Then the head gear offer voucher is applied

Scenario: An offer and a gift voucher is applied to valid products
	Given a basket
	And and an expensive hat is added to the basket
	And and a cheap jumper is added to the basket
	And and standard offer voucher is applied
	And and gift voucher is applied
	When a discount is applied
	Then both vouchers are applied

Scenario: An offer voucher is applied to products containing a gift voucher
	Given a basket
	And and an expensive hat is added to the basket
	And and a gift voucher is added to the basket
	And and standard offer voucher is applied
	When a discount is applied
	Then the offer voucher condition has not been met
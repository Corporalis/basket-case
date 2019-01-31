Feature: BasketCase
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: An applicable products a gift voucher is applied
	Given a basket
	And and a hat is added to the basket
	And and a jumper is added to the basket
	And and gift voucher is applied
	When a discount is applied
	Then the gift voucher should be successfully applied

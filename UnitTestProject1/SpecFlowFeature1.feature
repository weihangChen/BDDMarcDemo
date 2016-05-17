Feature: SpecFlowFeature1
	product discount test cases

@mytag


Scenario: NoProductNoDiscountTest
	Given a new calculation
	When apply discount rule
	Then total price should be 0


Scenario: ProductExistNoDiscountTest
	Given a new calculation
	Given the following "Products" exist
		| ProductName | Color    | Price |
		| Jacket      | Yellow   | 200   |
		| Belt        | Yellow   | 50    |
		| TShirt      | Red      | 100   |
	When apply discount rule
	Then total price should be 350


Scenario: DiscountCalTest
	Given a new calculation
	Given the following "Products" exist
		| ProductName | Color    | Price |
		| Jacket      | Yellow   | 200   |
		| Belt        | Yellow   | 50    |
		| TShirt      | Red      | 100   |
    Given the following "ColorDiscountRules" exist
		| Discount    | Color |
		| 0.9         | Red   |
	Given the following "ProductTypeDiscountRules" exist
		| Discount    | ProductName |
		| 0.8         | TShirt      |
			
	When apply discount rule
	Then total price should be 322

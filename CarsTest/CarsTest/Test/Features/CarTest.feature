Feature: CarsTest
	Collect and saving base trim info of two random cars
	Compare them on Side by Side Page
	Info on page should be equal to saved info


@mytag
Scenario Outline: Comparison of two cars
	Given Browser navigate to '<url>' page
	When Select random car by '<Make>' and '<Model>' and '<Year>' for searching
	Then Try navigate to Trim Comparsion or find another car by '<Make>' and '<Model>' and '<Year>' on '<url>' page
	And Saving parametres '<MAKE>' and '<MODEL>' and '<YEAR>' of First Car
	When Browser navigate to '<url>' page
	Then Select another car by '<Make>' and '<Model>' and '<Year>' for searching
	And Try navigate to Trim Comparsion or find another car by '<Make>' and '<Model>' and '<Year>' on '<url>' page
	And Saving parametres '<MAKE>' and '<MODEL>' and '<YEAR>' of Second Car
	Then From page '<url>' navigate to Side_by_Side Comparisons page
	And Add parametres '<Make>' and '<Model>' and '<Year>' of Cars
	And Compare parametres from page to saved parametres
	Examples: 
	| Make | Model | Year | url                   | MAKE | MODEL | YEAR |
	| make | model | year | https://www.cars.com/ | Make | Model | Year |
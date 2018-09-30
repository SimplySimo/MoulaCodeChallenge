Feature: CustomerCreation

Scenario Outline: Create new customer successfully
Given I am on the add new Customer page
And I have a new customer to insert
When I enter the details
And I select create
Then A success message is shown
Examples: 
| field | action  | expected |
| all   | Correct |      a    |


Scenario Outline: check field validation
Given I am on the add new Customer page
And I have a new customer to insert
When I insert an <input> value into <field>
And I select create and expect no action
Then I expect the <expected> error message for <field>
Examples: 
| field     | input    | expected                            |
| firstname |          | Field can't be empty                |
| lastname  |          | Field can't be empty                |
| email     | matt.com | Please enter a valid email address. |



